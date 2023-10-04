using CommunityToolkit.Maui.Views;
using NareiaApp.Abstractions.ViewModels;
using NareiaApp.Extensions;
using NareiaApp.Presentation.ViewModels;
using NareiaApp.Presentation.Views.Custom;

namespace NareiaApp.Views;

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

