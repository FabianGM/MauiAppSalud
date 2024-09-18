using MauiAppSalud.Controllers;
using MauiAppSalud.Interfaces;
using MauiAppSalud.Services;
using Microsoft.Extensions.Logging;

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
            builder.Services.AddSingleton <IUsuario,SrvUsuario>();
            builder.Services.AddSingleton<IFechas, SrvFechas>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
