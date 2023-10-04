#nullable enable

using NareiaApp.Data.Models;

namespace NareiaApp.Abstractions.Services
{
    public interface IFeedService
    {
        Task<IEnumerable<FeedItem>?> GetDailyFeedAsync();
    }
}
