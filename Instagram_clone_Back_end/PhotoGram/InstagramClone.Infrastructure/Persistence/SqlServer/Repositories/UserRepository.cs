using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Domain.Database.SqlServer.Entities;
using InstagramClone.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.Infrastructure.Persistence.SqlServer.Repositories
{
    public class UserRepository(InstagramCloneContext context) : IUserRepository
    {
        public async Task<User> Create(User user)
        {
            try
            {
                await context.Users.AddAsync(user);
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User?> Get(string email)
        {
            try
            {
                return await context.Users.FirstOrDefaultAsync(x => x.Email == email && x.DeletedAt == null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User?> GetUser(string name)
        {
            try
            {
                return await context.Users.FirstOrDefaultAsync(x => x.NameUser == name && x.DeletedAt == null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User?> GetUserById(Guid UserId)
        {
            try
            {
                return await context.Users.FirstOrDefaultAsync(x => x.IdUser == UserId && x.DeletedAt == null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User?> GetUserUnName(string name)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.UserUnName == name && x.DeletedAt == null);
        }

        public async Task<bool> HasCreated()
        {
            try
            {
                //verifica que la tabla tenga minimo 1 usuario
                return await context.Users.AnyAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> IfExist(string name)
        {
            return await context.Users.AnyAsync(x => x.NameUser == name);
        }
        //metodo para validacion userId en PostId
        public async Task<bool> IfExist(Guid id)
        {
            var exists = await context.Users.AnyAsync(x => x.IdUser == id) ? true : false;

            return exists;
        }

        public async Task<bool> IfExistUserUnname(string name)
        {
            return await context.Users.AnyAsync(x => x.UserUnName == name);
        }

        public IQueryable<User> Queryable()
        {
            try
            {
                return context.Users.Where(x => x.DeletedAt == null).AsQueryable();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
