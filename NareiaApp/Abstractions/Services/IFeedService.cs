using NareiaApp.Abstractions.Models;

namespace NareiaApp.Abstractions.Services
{
    public interface IFeedService
    {
        Task<IEnumerable<IFeedItem>> GetDailyFeedAsync();
    }
}
