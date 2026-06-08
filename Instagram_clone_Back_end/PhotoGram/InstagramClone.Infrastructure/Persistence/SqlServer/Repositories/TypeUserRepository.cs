using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Domain.Database.SqlServer.Entities;
using InstagramClone.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.Infrastructure.Persistence.SqlServer.Repositories
{
    public class TypeUserRepository(InstagramCloneContext context) : ITypeUserRepository
    {
        public async Task<TypeUser?> Get(string NameType)
        {
            try
            {
                return await context.TypeUsers.FirstOrDefaultAsync(x => x.NameType == NameType && x.DeletedAt == null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
