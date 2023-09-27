using NareiaApp.Abstractions.Models;
using NareiaApp.Abstractions.Repositories;

namespace NareiaApp.Repositories
{
    public interface IApiFeedRepository : IFeedRepository
    {
        public new Task<IEnumerable<IFeedItem>> GetDailyFeed();
    }
}
