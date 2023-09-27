using NareiaApp.Abstractions.ViewModels;
using NareiaApp.Models;
using NareiaApp.ViewModels;

namespace NareiaApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage(IMainPageViewModel mainPageViewModel)
	{
        InitializeComponent();
        BindingContext = mainPageViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        
        await (BindingContext as MainPageViewModel).GetFeedItemsAsync();
    }
}

