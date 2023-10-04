using CommunityToolkit.Maui.Alerts;
using NareiaApp.Data.Models;
using NareiaApp.Extensions;
using NareiaApp.Presentation.ViewModels;

namespace NareiaApp.Views.Pages;

public partial class IdeasPage : ContentPage
{
    public IdeasPage()
	{
		InitializeComponent();
    }

    #region Events

    private void OnFloatingButtonClick(object sender, EventArgs e)
    {
        if (!(sender is ImageButton ib))
            return;

        StartClickAnimationAsync(ib).SafeFireAndForget();
    }

    private async void OnBookmarkClicked(object sender, EventArgs e)
    {
        if (!(sender is ImageButton imageButton)) return;

        var parameter = imageButton.CommandParameter as FeedItem;

        await imageButton.ScaleTo(0.8, 150);
        await imageButton.ScaleTo(1, 150);

        (BindingContext as MainPageViewModel).BookmarkCommand.Execute(parameter);

        await Toast.Make("Your favorites has been updated.").Show();
    }

    #endregion

    #region Private Methods

    private async Task StartClickAnimationAsync(ImageButton ib)
    {
        await Task.WhenAll(
            ib.RotateYTo(360, 800),
            ib.TranslateTo(0, -64, 800, Easing.BounceIn)
        );

        await Task.WhenAll(
            ib.RotateYTo(720, 800),
            ib.TranslateTo(0, 0, 800, Easing.BounceOut)
        );
    }

    #endregion
}