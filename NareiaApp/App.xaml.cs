using Maui.Feed.App.Views;

namespace Maui.Feed.App;

public partial class App : Application
{
	public App(MainPage mainPage)
	{
		InitializeComponent();

        MainPage = new NavigationPage(mainPage);
	}
}
