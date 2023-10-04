using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using Maui.Feed.App.Abstractions.Repositories;
using Maui.Feed.App.Abstractions.Services;
using Maui.Feed.App.Abstractions.ViewModels;
using Maui.Feed.App.Data.Services;
using Maui.Feed.App.Infrastructure.Abstractions;
using Maui.Feed.App.Infrastructure.Constants;
using Maui.Feed.App.Presentation.ViewModels;
using Maui.Feed.App.Repositories;
using Maui.Feed.App.Views;
using Refit;

namespace Maui.Feed.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseFFImageLoading()
            .UseMauiCommunityToolkit()
            .RegisterDependencies()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Lato-Regular.ttf", "Lato");
                fonts.AddFont("Lato-Bold.ttf", "LatoBold");
            });

#if MOCK
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    public static MauiAppBuilder RegisterDependencies(this MauiAppBuilder mauiAppBuilder)
    {

#if MOCK
        mauiAppBuilder.Services.AddSingleton<IFeedRepository, MockFeedRepository>();
#else
        var apiData = RestService.For<IFeedRepository>(Constants.BASE_URL);

		mauiAppBuilder.Services.AddSingleton(apiData);
#endif

        mauiAppBuilder.Services.AddSingleton<IFeedService, FeedService>();
        mauiAppBuilder.Services.AddSingleton<IFavoritesService, FavoritesService>();
        mauiAppBuilder.Services.AddSingleton<IPreferencesService, PreferencesService>();

		mauiAppBuilder.Services.AddScoped<MainPage>();
		mauiAppBuilder.Services.AddScoped<IMainPageViewModel, MainPageViewModel>();

        return mauiAppBuilder;
    }
}
