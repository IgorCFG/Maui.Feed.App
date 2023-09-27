using NareiaApp.Abstractions.Models;
using NareiaApp.Abstractions.Repositories;
using NareiaApp.Abstractions.Services;

namespace NareiaApp.Services
{
    public class FeedService : IFeedService
    {
        #region Fields

        private readonly IFeedRepository _feedRepository;

        #endregion

        #region Constructors

        public FeedService(IFeedRepository feedRepository) 
        {
            _feedRepository = feedRepository;
        }

        #endregion

        #region IFeedService

        public Task<IEnumerable<IFeedItem>> GetDailyFeedAsync()
        {
            return _feedRepository.GetDailyFeedAsync();
        }

        #endregion
    }
}
