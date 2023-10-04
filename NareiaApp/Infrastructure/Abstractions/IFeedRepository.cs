using NareiaApp.Data.Models;
using Refit;

namespace NareiaApp.Abstractions.Repositories
{
    public interface IFeedRepository
    {
#if MOCK
        Task<FeedCollection> GetDailyFeedAsync();
#else
        [Get("/IgorCFG/NareiaApp/main/NareiaApp/Resources/Raw/feed.json")]
        Task<FeedCollection> GetDailyFeedAsync();
#endif
    }
}
