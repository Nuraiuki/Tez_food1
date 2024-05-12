using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using xx.Services;
using xx.ViewModels;
using xx.Pages;



namespace xx;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();
#endif
		AddDrinksServices(builder.Services);


        return builder.Build();
	}


	private static IServiceCollection
		AddDrinksServices(IServiceCollection services)

	{

		services.AddSingleton<DrinkService>();

		services.AddSingleton<HomePage>().AddSingleton<HomeViewModel>();

		services.AddTransientWithShellRoute<AllDrinkPage, AllDrinkViewModel>(nameof(AllDrinkPage));
        services.AddTransientWithShellRoute<DetailPage, DetailsViewModel>(nameof(DetailPage));
		services.AddSingleton<CartViewModel>();
		services.AddTransient<CartPage>();
        return services;
	}
}

