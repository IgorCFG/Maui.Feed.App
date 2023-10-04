#nullable enable

using NareiaApp.Data.Models;

namespace NareiaApp.Infrastructure.Abstractions
{
    public interface IFavoritesService
    {
        FeedCollection? GetFavorites();
        Task AddOrRemoveFavoriteAsync(FeedItem item, Func<Task> onFavoritesChanged);
    }
}
