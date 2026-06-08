using InstagramClone.Application.Models.DTOs;
using InstagramClone.Application.Models.Requests.Users;
using InstagramClone.Application.Models.Responses;

namespace InstagramClone.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<GenericResponse<UserDTO>> Create(CreateUserRequest model);
        public Task<GenericResponse<List<UserDTO>>> GetUser(GetUsersRequest model);
        public Task<GenericResponse<UserDTO?>> GetUserById(Guid UserId);
        //public Task<Generic> DeleteUser()

        public Task CreateFirstUser();
    }
}
