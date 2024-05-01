using CommunityToolkit.Maui;
using ComunidadVecinal.Helpers;
using ComunidadVecinal.MVVM.Models;
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
            builder.Services.AddSingleton<BaseRepository<TransaccionModel>>();

            //Pages
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddTransient<Inicio>();
            builder.Services.AddTransient<TurnoLimpieza>();
            builder.Services.AddTransient<Banco>();
            builder.Services.AddTransient<Transaccion>();


            //ViewModels
            //builder.Services.AddSingleton<AppShellViewModel>();
            builder.Services.AddTransient<TurnoLimpiezaViewModel>();
            builder.Services.AddTransient<BancoViewModel>();
            builder.Services.AddTransient<TransaccionViewmodel>();

            return builder.Build();
        }
    }
}
