﻿using Firebase.Database;
using Microsoft.Extensions.Logging;
using PS.Core.Interfaces;
using PS.Infrastructure.Data;
using PS.Infrastructure.Repositories.Firebase;
using PS.Infrastructure.Repositories.SQLite;
using PS.UI.Maui.Services;
using PS.UI.Maui.ViewModels;
using PS.UI.Maui.Views;
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
            builder.Services.AddSingleton(new SQLiteAsyncConnection(dbPath));
            builder.Services.AddSingleton(s => new FirebaseClient(FirebaseConfig.BaseUrl));

            // Repositorios
            builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddSingleton<IMascotaRepository, MascotaRepository>();
            builder.Services.AddSingleton<IEnfermedadComunRepository, EnfermedadComunRepository>();

            // Servicios Firebase
            builder.Services.AddSingleton<IUsuarioFirebaseService, UsuarioFirebaseService>();
            builder.Services.AddSingleton<IMascotaFirebaseService, MascotaFirebaseService>();
            builder.Services.AddSingleton<IEnfermedadComunFirebaseService,  EnfermedadComunFirebaseService>();

            // Servicio de sincronización
            builder.Services.AddSingleton<SyncService>();

            // ViewModels y Views (los agregaremos más adelante)
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<LoadPage>();
            builder.Services.AddTransient<WaitingPage>();
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailReadPage>();
            builder.Services.AddTransient<HistoryPage>();

            builder.Services.AddTransient<DetailViewModel>();
            builder.Services.AddTransient<DetailReadViewModel>();
            builder.Services.AddTransient<HistoryViewModel>();
            builder.Services.AddTransient<WaitingViewModel>();

            builder.Services.AddSingleton<HttpClienteService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
