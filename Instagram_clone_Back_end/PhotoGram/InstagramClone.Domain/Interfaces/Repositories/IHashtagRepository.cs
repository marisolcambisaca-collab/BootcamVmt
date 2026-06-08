using InstagramClone.Domain.Database.SqlServer.Entities;

namespace InstagramClone.Domain.Interfaces.Repositories
{
    public interface IHashtagRepository
    {
        public Task Create(Hashtag hashtag);

        public Task<Hashtag?> GetByDescription(string description);
    }
}
