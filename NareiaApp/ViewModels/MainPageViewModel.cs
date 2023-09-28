using NareiaApp.Abstractions.Models;
using NareiaApp.Abstractions.Services;
using NareiaApp.Abstractions.ViewModels;
using NareiaApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NareiaApp.ViewModels
{
    public class MainPageViewModel : IMainPageViewModel //: INotifyPropertyChanged
    {
        #region Fields

        private readonly IFeedService _feedService;

        private bool isBusy;

        #endregion

        #region Properties

        //public event PropertyChangedEventHandler PropertyChanged;

        public ObservableRangeCollection<IFeedItem> ItemsSource { get; set; }

        public IAsyncCommand DailyCommand =>
            new AsyncCommand(GetDailyItemsAsync);

        public IAsyncCommand FavoritesCommand =>
            new AsyncCommand(GetFavoriteItemsAsync);

        //public bool IsBusy
        //{
        //    get => isBusy;
        //    set
        //    {
        //        isBusy = value;
        //        OnPropertyChanged(nameof(IsBusy));
        //    }
        //}

        #endregion

        #region Constructors

        public MainPageViewModel(IFeedService feedService)
        {
            _feedService = feedService;

            ItemsSource = new ObservableRangeCollection<IFeedItem>();
        }

        #endregion

        #region Public Methods

        public async Task GetDailyItemsAsync()
        {
            var dailyFeed = await _feedService.GetDailyFeedAsync().ConfigureAwait(false);
            MainThread.BeginInvokeOnMainThread(() => ItemsSource.AddRange(dailyFeed));
        }

        public Task GetFavoriteItemsAsync()
        {
            ItemsSource.ReplaceRange(new List<IFeedItem>());
            return Task.CompletedTask;
        }

        #endregion

        //private void OnPropertyChanged(string propertyName)
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null)
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
