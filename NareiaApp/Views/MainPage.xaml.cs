using NareiaApp.Abstractions.ViewModels;
using NareiaApp.ViewModels;

namespace NareiaApp.Views;

public partial class MainPage : TabbedPage
{
    public MainPage(IMainPageViewModel mainPageViewModel)
	{
        InitializeComponent();
        BindingContext = mainPageViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        
        await (BindingContext as MainPageViewModel).GetDailyItemsAsync();
    }
}

