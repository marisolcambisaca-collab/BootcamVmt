using Insta.Application.Helper;
using Insta.Application.Interfaces.Services;
using Insta.Application.Models.DTOs;
using Insta.Application.Models.Requests.User;
using Insta.Application.Models.Requests.Users;
using Insta.Application.Responses;

namespace Insta.Application.Services
{

    public class UserService : IUserService
    {


        // var users = queryable
        //   .Skip((model.Page - 1 ) * model.PageSize )
        //  .Take(model.PageSize)
        // .ToList();
        public Task<GenericResponse<bool>> ChangePassword(Guid Id, ChangePasswordInstagramRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<UserDto>> Create(CreateUserRequest model)
        {
            var user = new UserDto
            {
                IdUser = Guid.NewGuid(),
                NameUser = model.NameUser,
                Email = model.Email,
                TypeUserId = model.TypeUserId,
                Visibility = model.Visibility,
                CreatedAt = DateTime.UtcNow
            };

            return Task.FromResult(ResponseHelper.Create(user));
        }


        public GenericResponse<List<UserDto>> Get(FilterUserRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<UserDto>> Get(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<string>> LoginUser(LoginUserRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<UserDto>> Update(Guid UserId, UpdateUserRequest model)
        {
            throw new NotImplementedException();
        }
    }
}


