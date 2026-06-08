using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Shared.Helper;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.WebApi.Services
{
    public class StoryCleanupBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public StoryCleanupBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();

                var context = scope.ServiceProvider.GetRequiredService<InstagramCloneContext>();

                var expiredStories = await context.Posts.Where(x =>
                x.IsStory &&
                x.DeletedAt == null &&
                x.ExpiresAt <= DateTimeHelper.UtcNow())
                .ToListAsync(stoppingToken);

                foreach (var story in expiredStories)
                {
                    story.DeletedAt = DateTimeHelper.UtcNow();
                }

                if (expiredStories.Any())
                {
                    await context.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }
    }
}
