using InstagramClone.Application.Models.Requests.Auth;
using InstagramClone.Application.Models.Responses;

namespace InstagramClone.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<GenericResponse<string>> Login(LoginAuthRequest model);
    }
}
