#nullable enable

using Maui.Feed.App.Data.Models;

namespace Maui.Feed.App.Abstractions.Services
{
    public interface IFeedService
    {
        Task<IEnumerable<FeedItem>?> GetDailyFeedAsync();
    }
}
