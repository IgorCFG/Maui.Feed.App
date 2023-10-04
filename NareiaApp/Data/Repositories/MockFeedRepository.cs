using NareiaApp.Abstractions.Repositories;
using NareiaApp.Data.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace NareiaApp.Repositories
{
    public class MockFeedRepository : IFeedRepository
    {
        #region IFeedRepository

        public async Task<FeedCollection> GetDailyFeedAsync()
        {
            var mockedFeed = await GetFeedFromAssetAsync();
            return mockedFeed;
        }

        #endregion

        #region Private Methods

        private async Task<FeedCollection> GetFeedFromAssetAsync()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("feed.json");
                using var reader = new StreamReader(stream);

                var json = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<FeedCollection>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR]: {ex.Message}");
            }

            return null;
        }

        #endregion
    }
}
