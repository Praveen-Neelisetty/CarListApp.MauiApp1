using CarListApp.MauiApp1.Services;
using CarListApp.MauiApp1.ViewModels;
using CarListApp.MauiApp1.Views;
using Microsoft.Extensions.Logging;

namespace CarListApp.MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Initialize SQLite Batteries
            SQLitePCL.Batteries_V2.Init();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "cars.db3");

            builder.Services.AddSingleton<CarService>(s => ActivatorUtilities.CreateInstance<CarService>(s, dbPath));

            builder.Services.AddSingleton<CarListViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CarDetailsPage>();
            builder.Services.AddSingleton<CarDetailsPageViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
