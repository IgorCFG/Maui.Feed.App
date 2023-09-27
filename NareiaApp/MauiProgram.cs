using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using NareiaApp.Abstractions.Repositories;
using NareiaApp.Abstractions.Services;
using NareiaApp.Abstractions.ViewModels;
using NareiaApp.Repositories;
using NareiaApp.Services;
using NareiaApp.ViewModels;
using NareiaApp.Views;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    public static MauiAppBuilder RegisterDependencies(this MauiAppBuilder mauiAppBuilder)
    {
#if DEBUG
        mauiAppBuilder.Services.AddScoped<IFeedRepository, MockFeedRepository>();
#else
        mauiAppBuilder.Services.AddScoped<IFeedRepository ,IApiFeedRepository>();
#endif

        mauiAppBuilder.Services.AddScoped<IFeedService, FeedService>();

		mauiAppBuilder.Services.AddScoped<MainPage>();
		mauiAppBuilder.Services.AddScoped<IMainPageViewModel, MainPageViewModel>();

        return mauiAppBuilder;
    }
}
