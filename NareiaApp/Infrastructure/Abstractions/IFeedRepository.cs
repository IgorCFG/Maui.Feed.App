using Maui.Feed.App.Data.Models;
using Refit;

namespace Maui.Feed.App.Abstractions.Repositories
{
    public interface IFeedRepository
    {
#if MOCK
        Task<FeedCollection> GetDailyFeedAsync();
#else
        [Get("/IgorCFG/Maui.Feed.App/main/Maui.Feed.App/Resources/Raw/feed.json")]
        Task<FeedCollection> GetDailyFeedAsync();
#endif
    }
}
