using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using NareiaApp.Abstractions.Repositories;
using NareiaApp.Abstractions.Services;
using NareiaApp.Abstractions.ViewModels;
using NareiaApp.Data.Services;
using NareiaApp.Infrastructure.Abstractions;
using NareiaApp.Infrastructure.Constants;
using NareiaApp.Presentation.ViewModels;
using NareiaApp.Repositories;
using NareiaApp.Views;
using Refit;

namespace NareiaApp;

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
