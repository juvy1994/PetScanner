using Microsoft.Extensions.Logging;
using PS.Core.Interfaces;
using PS.Infrastructure.Data;
using PS.Infrastructure.Repositories;
using PS.UI.Maui.Services;
using SQLite;

namespace PS.UI.Maui
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
            // Configurar SQLite
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "pet_scan.db");
            var dbContext = new SQLiteDbContext(dbPath);

            builder.Services.AddSingleton(new SQLiteConnection(dbPath));

            // Repositorios
            builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddSingleton<IMascotaRepository, MascotaRepository>();

            // Servicios Firebase
            builder.Services.AddSingleton<IUsuarioFirebaseService, UsuarioFirebaseService>();
            builder.Services.AddSingleton<IMascotaFirebaseService, MascotaFirebaseService>();

            // Servicio de sincronización
            builder.Services.AddSingleton<SyncService>();

            // ViewModels y Views (los agregaremos más adelante)
            //builder.Services.AddSingleton<UsuarioViewModel>();
            //builder.Services.AddSingleton<UsuarioPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
