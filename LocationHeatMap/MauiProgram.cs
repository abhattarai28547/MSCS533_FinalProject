using Microsoft.Extensions.Logging;
using Microsoft.Maui.Essentials;


namespace LocationHeatMap;

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
			})
			.UseMauiMaps();

		var dbPath = Path.Combine(FileSystem.AppDataDirectory, "locations.db");
		builder.Services.AddSingleton(new DatabaseHelper(dbPath));
		builder.Services.AddSingleton<LocationService>();



#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
