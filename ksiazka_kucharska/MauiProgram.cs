using ksiazka_kucharska.Service;
using ksiazka_kucharska.Views;
using Microsoft.Extensions.Logging;

namespace ksiazka_kucharska
{
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
            builder.Services.AddSingleton<RecipeService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<FavoritesPage>();
#endif

            return builder.Build();
        }
    }
}
