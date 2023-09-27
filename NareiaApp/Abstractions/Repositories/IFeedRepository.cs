using NareiaApp.Abstractions.Models;

namespace NareiaApp.Abstractions.Repositories
{
    public interface IFeedRepository
    {
        Task<IEnumerable<IFeedItem>> GetDailyFeedAsync();
    }
}
