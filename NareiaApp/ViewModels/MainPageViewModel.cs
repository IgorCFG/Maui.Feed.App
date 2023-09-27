using NareiaApp.Abstractions.Models;
using NareiaApp.Abstractions.Services;
using NareiaApp.Abstractions.ViewModels;
using System.Collections.ObjectModel;

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

        public ObservableCollection<IFeedItem> ItemsSource { get; set; }

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

            ItemsSource = new ObservableCollection<IFeedItem>();
        }

        #endregion

        #region Public Methods

        public async Task GetFeedItemsAsync()
        {
            var dailyFeed = await _feedService.GetDailyFeedAsync().ConfigureAwait(false);

            for (int i = 0; i < dailyFeed.Count(); i++)
            {
                ItemsSource.Add(dailyFeed.ElementAt(i));
            }
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
