using CommunityToolkit.Maui;
using ComunidadVecinal.MVVM.ViewModels;
using ComunidadVecinal.MVVM.Views;
using Microsoft.Extensions.Logging;

namespace ComunidadVecinal
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "Icons");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //Services y Helpers
            
            //Pages
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddTransient<Inicio>();
            builder.Services.AddTransient<TurnoLimpieza>();


            //ViewModels
            //builder.Services.AddSingleton<AppShellViewModel>();
            builder.Services.AddTransient<TurnoLimpiezaViewModel>();

            return builder.Build();
        }
    }
}
