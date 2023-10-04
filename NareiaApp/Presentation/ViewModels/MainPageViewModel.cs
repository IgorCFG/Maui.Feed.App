#nullable enable

using Maui.Feed.App.Abstractions.Models;
using Maui.Feed.App.Abstractions.Services;
using Maui.Feed.App.Abstractions.ViewModels;
using Maui.Feed.App.Collections;
using Maui.Feed.App.Data.Models;
using Maui.Feed.App.Infrastructure.Abstractions;
using Maui.Feed.App.Presentation.Enums;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Maui.Feed.App.Presentation.ViewModels
{
    public class MainPageViewModel : IMainPageViewModel
    {
        #region Fields

        private readonly IFeedService _feedService;
        private readonly IFavoritesService _favoritesService;

        private bool isBusy;
        private bool isLoadingFakeData;
        private int tab;

        #endregion

        #region Properties

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableRangeCollection<FeedItem> ItemsSource { get; set; }

        public IAsyncCommand DailyCommand =>
            new AsyncCommand(LoadDailyTabAsync, (x) => !IsBusy);

        public IAsyncCommand FavoritesCommand =>
            new AsyncCommand(LoadFavoriteTabAsync, (x) => !IsBusy);

        public ICommand LoadFakeDataCommand =>
            new Command(LoadFakeDataCommandExecute);

        public ICommand BookmarkCommand =>
            new Command<FeedItem>(BookmarkCommandExecute);

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public bool IsLoadingFakeData
        {
            get => isLoadingFakeData;
            set
            {
                isLoadingFakeData = value;
                OnPropertyChanged(nameof(IsLoadingFakeData));
            }
        }

        public int Tab
        {
            get => tab;
            set
            {
                tab = value;
                OnPropertyChanged(nameof(Tab));
            }
        }

        #endregion

        #region Constructors

        public MainPageViewModel(
            IFeedService feedService,
            IFavoritesService favoritesService)
        {
            _feedService = feedService;
            _favoritesService = favoritesService;

            ItemsSource = new ObservableRangeCollection<FeedItem>();
        }

        #endregion

        #region Public Methods

        public Task InitializeAsync()
        {
            return LoadDailyTabAsync();
        }

        #endregion

        #region Private Methods

        private async Task LoadDailyTabAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                Tab = (int)IdeasTab.Daily;

                var dailyFeed = await _feedService.GetDailyFeedAsync().ConfigureAwait(false);

                // just to fake a loading animation (remove for performance)
                await Task.Delay(500);

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ItemsSource.ReplaceRange(dailyFeed);
                    IsBusy = false;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR - MainPageViewModel.LoadDailyTabAsync]: {ex.Message}");
            }
        }

        private async Task LoadFavoriteTabAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                Tab = (int)IdeasTab.Favorites;

                var favorites = _favoritesService.GetFavorites()?.Items ?? new List<FeedItem>();

                // just to fake a loading animation (remove for performance)
                await Task.Delay(500);

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ItemsSource.ReplaceRange(favorites);
                    IsBusy = false;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR - MainPageViewModel.LoadFavoriteTabAsync]: {ex.Message}");
            }
        }

        private void LoadFakeDataCommandExecute()
        {
            if (IsLoadingFakeData || !IsDailyTab()) return;

            try
            {
                IsLoadingFakeData = true;

                var item1 = ItemsSource.ElementAt(0);
                var item2 = ItemsSource.ElementAt(1);
                var item3 = ItemsSource.ElementAt(2);

                var fakeCollection = new List<FeedItem>()
                {
                    item2,
                    item1,
                    item2,
                    item3,
                    item1,
                    item3,
                };

                ItemsSource.AddRange(fakeCollection);
                IsLoadingFakeData = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR - MainPageViewModel.LoadFakeData]: {ex.Message}");
            }
        }

        private void BookmarkCommandExecute(FeedItem item)
        {
            try
            {
                _favoritesService.AddOrRemoveFavoriteAsync(item, OnFavoritesChanged);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR - MainPageViewModel.BookmarkCommandExecute]: {ex.Message}");
            }
        }

        private Task OnFavoritesChanged()
        {
            if (IsDailyTab())
                return Task.CompletedTask;

            return LoadFavoriteTabAsync();
        }

        private bool IsDailyTab()
        {
            return Tab == (int)IdeasTab.Daily;
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
