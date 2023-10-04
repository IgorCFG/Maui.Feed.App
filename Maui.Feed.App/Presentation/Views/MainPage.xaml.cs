using CommunityToolkit.Maui.Views;
using Maui.Feed.App.Abstractions.ViewModels;
using Maui.Feed.App.Extensions;
using Maui.Feed.App.Presentation.ViewModels;
using Maui.Feed.App.Presentation.Views.Custom;

namespace Maui.Feed.App.Views;

public partial class MainPage : TabbedPage
{
    #region Fields

    private readonly IMainPageViewModel _viewModel;

    #endregion

    public MainPage(
        IMainPageViewModel mainPageViewModel)
	{
        InitializeComponent();
        BindingContext = mainPageViewModel;

        _viewModel = mainPageViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        _viewModel.InitializeAsync().SafeFireAndForget();
    }

    private void OnAccountSelectClicked(object sender, EventArgs e)
    {
        var accountPopup = new AccountSelectorPopup()
        {
            VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Start,
            HorizontalOptions = Microsoft.Maui.Primitives.LayoutAlignment.End,
        };

        this.ShowPopup(accountPopup);
    }
}

