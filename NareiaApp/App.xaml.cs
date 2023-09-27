using NareiaApp.Views;

namespace NareiaApp;

public partial class App : Application
{
	public App(MainPage mainPage)
	{
		InitializeComponent();
        MainPage = mainPage;
	}
}
