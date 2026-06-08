using InstagramClone.Domain.Database.SqlServer.Entities;

namespace InstagramClone.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User?> GetUser(string name);

        Task<User?> GetUserUnName(string name);
        Task<User?> Get(string email);
        Task<User?> GetUserById(Guid UserId);
        Task<bool> IfExist(string name);
        Task<bool> IfExistUserUnname(string name);
        Task<bool> IfExist(Guid id);
        IQueryable<User> Queryable();
        Task<bool> HasCreated();


    }
}
