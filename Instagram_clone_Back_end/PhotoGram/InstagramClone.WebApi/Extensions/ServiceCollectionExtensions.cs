using InstagramClone.Application.Helpers;
using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Services;
using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Domain.Exceptions;
using InstagramClone.Domain.Interfaces.Repositories;
using InstagramClone.Infrastructure.Persistence.SqlServer.Repositories;
using InstagramClone.Shared.Constants;
using InstagramClone.WebApi.Middlewares;
using InstagramClone.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace InstagramClone.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// anade un tipo de conexion a los servicios
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPostService, PostService>();
            //---------------ADICION SERVICIO DE ACTUALIZACION DE HISTORIAS VENCIDAS AUTOMATICO-----------------
            services.AddHostedService<StoryCleanupBackgroundService>();
        }
        /// <summary>
        /// anade un tipo de conexion a los repositorios
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IHashtagRepository, HashtagRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITypeUserRepository, TypeUserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            //---------------------INTEGRACION UOW--------------------------------
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlerMiddleware>();
        }

        public static void AddLogging(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .File(Path.Combine(Directory.GetCurrentDirectory(), "Logs/log.txt"), rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();
        }


        /// <summary>
        /// aqui se almacenan los metodos para la inicializacion del primer usuario al arrancar la app
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public async static Task Initialize(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var scope = provider.CreateAsyncScope();

            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
            await userService.CreateFirstUser();
        }


        /// <summary>
        /// anade todo incluido los servicios y repositorios junto a lo necesario para que la app arranque
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static async Task AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            //-------------------------RESPONSE PERSONALIZADA DE INVALIDOS DEL CONTROLADOR ----------------------------------------------------
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (errorContext) =>
                {
                    var errors = errorContext.ModelState.Values.SelectMany(value => value.Errors.Select(error => error.ErrorMessage)).ToList();
                    var rsp = ResponseHelper.Create(
                        data: ValidationConstants.VALIDATION_MESSAGE,
                        errors: errors,
                        message: ValidationConstants.VALIDATION_MESSAGE);
                    return new BadRequestObjectResult(rsp);
                };
            });
            //-------------------------------------------------------------------------------------------------------------------------------
            services.AddOpenApi();
            //--------------------------------CONEXION BASE DE DATOS----------------------------------------
            /*si no encuentras la base de datos en appsettings(produccion) buscala en los secrets(desarrollo)*/
            var DatabaseConnectionString = Environment.GetEnvironmentVariable(ConfigurationConstants.CONNECTION_STRING_DATABASE)
                ?? configuration[ConfigurationConstants.CONNECTION_STRING_DATABASE];
            /*se hace la conexion con la base de datos*/
            services.AddSqlServer<InstagramCloneContext>(configuration.GetConnectionString(DatabaseConnectionString));
            //------------------------------------------------------------------------
            services.AddRepositories();
            services.AddServices();
            services.AddMiddlewares();
            services.AddLogging();
            //-----------------------CORS-----------------------
            var allowedOrigins = configuration.GetSection(ConfigurationConstants.CORS_ORIGINS).Get<string[]>();//obtenemos los origenes permitidos desde la configuracion
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            //-----------------------AUTENTICACION DEL USUARIO-----------------------
            AddAuth(services, configuration);
            //-----------------------INICIALIZACION DE USUARIO-----------------------
            await Initialize(services);
        }

        public static void AddAuth(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(builder =>
            {
                //aqui necesito el nugget de jwtBearer - validacion de autenticacion base se configura con la autenticacion Jwt
                builder.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //validacion de los token no validos
                builder.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Builder =>
            {
                //verifica si los datos del que hace la solicitud estan
                //nosotros
                var issuer = Environment.GetEnvironmentVariable(ConfigurationConstants.JWT_ISSUER)
                ?? configuration[ConfigurationConstants.JWT_ISSUER]
                ?? throw new Exception(ResponseConstants.ConfigurationPropertyNotFound(ConfigurationConstants.JWT_ISSUER));
                //frontend
                var audience = Environment.GetEnvironmentVariable(ConfigurationConstants.JWT_AUDIENCE)
                ?? configuration[ConfigurationConstants.JWT_AUDIENCE]
                ?? throw new Exception(ResponseConstants.ConfigurationPropertyNotFound(ConfigurationConstants.JWT_AUDIENCE));
                //clave privada para crear tokens
                var privateKey = Environment.GetEnvironmentVariable(ConfigurationConstants.JWT_PRIVATE_KEY)
                ?? configuration[ConfigurationConstants.JWT_PRIVATE_KEY]
                ?? throw new Exception(ResponseConstants.ConfigurationPropertyNotFound(ConfigurationConstants.JWT_PRIVATE_KEY));
                //tiempo de expiracion
                var expirationInMinutes = Environment.GetEnvironmentVariable(ConfigurationConstants.JWT_EXPIRATION_IN_MINUTES)
                ?? configuration[ConfigurationConstants.JWT_EXPIRATION_IN_MINUTES]
                ?? "10";

                //Valida que todos los parametros sean correctos
                Builder.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey)),
                    ClockSkew = TimeSpan.Zero
                };
                Builder.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        throw new UnauthorizedUserException(ResponseConstants.AUTH_TOKEN_NOT_FOUND);
                    }
                };
            });
            services.AddAuthorization();
        }
    }
}
