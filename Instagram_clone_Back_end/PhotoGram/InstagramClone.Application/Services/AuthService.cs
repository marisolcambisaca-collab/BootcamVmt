using InstagramClone.Application.Helpers;
using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.Requests.Auth;
using InstagramClone.Application.Models.Responses;
using InstagramClone.Domain.Exceptions;
using InstagramClone.Domain.Interfaces.Repositories;
using InstagramClone.Shared;
using Microsoft.Extensions.Configuration;

namespace InstagramClone.Application.Services
{
    public class AuthService(IUserRepository userRepository, IConfiguration configuration) : IAuthService
    {
        public async Task<GenericResponse<string>> Login(LoginAuthRequest model)
        {
            var user = await userRepository.Get(model.Email)
                ?? throw new BadRequestException("Usuario o contrasena incorrecta");

            var validatePassword = Hasher.ComparePassword(model.Password, user.Password);
            if (!validatePassword)
            {
                throw new BadRequestException("Usuario o contrasena incorrecta");
            }

            var token = TokenHelper.Create(user, configuration);

            return ResponseHelper.Create(token);
        }
    }
}
