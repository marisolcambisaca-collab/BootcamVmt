using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Domain.Interfaces.Repositories;

namespace InstagramClone.Infrastructure.Persistence.SqlServer.Repositories
{
    public class UnitOfWork(InstagramCloneContext context) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
