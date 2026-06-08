using InstagramClone.Domain.Database.SqlServer.Entities;
using InstagramClone.Shared.Constants;
using InstagramClone.Shared.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InstagramClone.Application.Helpers
{
    public static class TokenHelper
    {
        public static string Create(User user, IConfiguration configuration)
        {
            var issuer = Environment.GetEnvironmentVariable(ConfigurationConstants.JWT_ISSUER)
                ?? configuration[ConfigurationConstants.JWT_ISSUER]
                ?? throw new Exception(ResponseConstants.ConfigurationPropertyNotFound(ConfigurationConstants.JWT_ISSUER));
            //frontend, destinatarios del token
            var audience = Environment.GetEnvironmentVariable(ConfigurationConstants.JWT_AUDIENCE)
                ?? configuration[ConfigurationConstants.JWT_AUDIENCE]
                ?? throw new Exception(ResponseConstants.ConfigurationPropertyNotFound(ConfigurationConstants.JWT_AUDIENCE));
            //clave privada para crear tokens
            var privateKey = Environment.GetEnvironmentVariable(ConfigurationConstants.JWT_PRIVATE_KEY)
                ?? configuration[ConfigurationConstants.JWT_PRIVATE_KEY]
                ?? throw new Exception(ResponseConstants.ConfigurationPropertyNotFound(ConfigurationConstants.JWT_PRIVATE_KEY));
            //fecha de expiracion del token
            var expirationInMinutes = Environment.GetEnvironmentVariable(ConfigurationConstants.JWT_EXPIRATION_IN_MINUTES)
                ?? configuration[ConfigurationConstants.JWT_EXPIRATION_IN_MINUTES]
                ?? "10";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTimeHelper.UtcNow();
            var expiration = now.AddMinutes(Convert.ToDouble(expirationInMinutes));


            var claims = new[]
            {
                new Claim(ClaimTypes.Role, user.TypeUserId.ToString().ToUpper()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimsConstants.User_ID, user.IdUser.ToString())
            };


            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: expiration,
                signingCredentials: signingCredentials,
                claims: claims
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
