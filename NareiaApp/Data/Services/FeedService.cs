#nullable enable

using Maui.Feed.App.Abstractions.Repositories;
using Maui.Feed.App.Abstractions.Services;
using Maui.Feed.App.Data.Models;
using System.Diagnostics;

namespace Maui.Feed.App.Data.Services
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

        public async Task<IEnumerable<FeedItem>?> GetDailyFeedAsync()
        {
            try
            {
                var response = await _feedRepository.GetDailyFeedAsync().ConfigureAwait(false);
                return response?.Items;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR - FeedService.GetDailyFeedAsync]: {ex.Message}");
            }

            return null;
        }

        #endregion
    }
}
