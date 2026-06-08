using InstagramClone.Domain.Database.SqlServer.Entities;

namespace InstagramClone.Domain.Interfaces.Repositories
{
    public interface ITypeUserRepository
    {
        Task<TypeUser?> Get(string NameType);
    }
}
