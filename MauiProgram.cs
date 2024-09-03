using Microsoft.Extensions.DependencyInjection;
using MauiAppSalud.Services;
using MauiAppSalud.Controllers;
using MauiAppSalud.Interfaces;
using Microsoft.Extensions.Logging;
using MauiAppSalud.ViewModels;
using MauiAppSalud.Views;

namespace MauiAppSalud
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

            //Servicios e Interfaces
            builder.Services.AddSingleton<IEjecutorSql, SrvEjecutorSql>();
            builder.Services.AddSingleton<IProfesional, SrvProfesional>();
            builder.Services.AddTransient<ProfesionalController>();
            builder.Services.AddSingleton <IUsuario,SrvUsuario >();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
