using Microsoft.Extensions.Logging;
using Microcharts.Maui;
using CommunityToolkit.Maui;
using Mopups.Hosting;
using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.Views;

namespace MVPStudio_Creative_Agency;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMicrocharts()
            .UseMauiCommunityToolkit()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Hind-Bold.ttf", "Hind-Bold");
                fonts.AddFont("Hind-Light.ttf", "Hind-Light");
                fonts.AddFont("Hind-Regular.ttf", "Hind-Regular");
                fonts.AddFont("Montserrat-Bold.ttf", "Montserrat-Bold");
                fonts.AddFont("Montserrat-Light.ttf", "Montserrat-Light");
                fonts.AddFont("Montserrat-Regular.ttf", "Montserrat-Regular");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        // registering auth and login pages
        builder.Services.AddTransient<AuthService>();
        builder.Services.AddTransient<LoadingPage>();


        return builder.Build();
    }
    }