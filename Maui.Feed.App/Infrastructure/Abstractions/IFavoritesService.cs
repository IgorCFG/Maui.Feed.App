#nullable enable

using Maui.Feed.App.Data.Models;

namespace Maui.Feed.App.Infrastructure.Abstractions
{
    public interface IFavoritesService
    {
        FeedCollection? GetFavorites();
        Task AddOrRemoveFavoriteAsync(FeedItem item, Func<Task> onFavoritesChanged);
    }
}
