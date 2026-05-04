using Insta.Application.Models.DTOs;
using Insta.Application.Models.Requests.User;
using Insta.Application.Models.Requests.Users;
using Insta.Application.Responses;
namespace Insta.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<GenericResponse<UserDto>> Create(CreateUserRequest model);
        public Task<GenericResponse<UserDto>> Update(Guid UserId, UpdateUserRequest model);
        public GenericResponse<List<UserDto>> Get(FilterUserRequest model);
        public Task<GenericResponse<UserDto>> Get(Guid UserId);
        public Task<GenericResponse<bool>> ChangePassword(Guid Id, ChangePasswordInstagramRequest model);
        public Task<GenericResponse<string>> LoginUser(LoginUserRequest model);
    }
}










