#nullable enable

using Maui.Feed.App.Abstractions.Services;
using Maui.Feed.App.Data.Models;
using Maui.Feed.App.Infrastructure.Abstractions;
using Maui.Feed.App.Infrastructure.Constants;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Maui.Feed.App.Data.Services
{
    public class FavoritesService : IFavoritesService
    {
        #region Fields

        private readonly IPreferencesService _preferencesService;

        #endregion

        #region Constructors

        public FavoritesService(
            IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }

        #endregion

        #region IFavoritesService

        public FeedCollection? GetFavorites()
        {
            try
            {
                var favoritesJson = _preferencesService.Get(Constants.PREFS_FAVORITES, string.Empty);
                var items = JsonConvert.DeserializeObject<FeedCollection>(favoritesJson);

                return items ?? new FeedCollection() { Items = new List<FeedItem>() };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR - FavoritesService.GetFavorites]: {ex.Message}");
                return null;
            }
        }

        public async Task AddOrRemoveFavoriteAsync(FeedItem item, Func<Task> onFavoritesChanged)
        {
            try
            {
                var favorites = GetFavorites();
                if (favorites == null) return;

                var hasItem = favorites.Items.Any(x => x.Id == item.Id);
                if (hasItem)
                {
                    Remove(favorites, item.Id);
                } 
                else
                {
                    Add(favorites, item);
                }

                await onFavoritesChanged.Invoke();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR - FavoritesService.AddFavorite]: {ex.Message}");
            }
        }

        #endregion

        #region Private Methods

        private void Add(FeedCollection favorites, FeedItem item)
        {
            try
            {
                var items = favorites.Items.ToList();

                items.Add(item);

                var collection = new FeedCollection() { Items = items };
                var collectionJson = JsonConvert.SerializeObject(collection);

                _preferencesService.Set(Constants.PREFS_FAVORITES, collectionJson);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR - FavoritesService.Add]: {ex.Message}");
            }
        }

        private void Remove(FeedCollection favorites, int id)
        {
            try
            {
                var items = favorites.Items.Where(x => x.Id != id);

                var collection = new FeedCollection() { Items = items };
                var collectionJson = JsonConvert.SerializeObject(collection);

                _preferencesService.Set(Constants.PREFS_FAVORITES, collectionJson);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR - FavoritesService.Remove]: {ex.Message}");
            }
        }

        #endregion
    }
}
