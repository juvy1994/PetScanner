using PS.Core.Interfaces;
using PS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.UI.Maui.Services
{
    public class SyncService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IUsuarioFirebaseService _usuarioFirebaseService;
        private readonly IMascotaFirebaseService _mascotaFirebaseService;

        public SyncService(
            IUsuarioRepository usuarioRepository,
            IMascotaRepository mascotaRepository,
            IUsuarioFirebaseService usuarioFirebaseService,
            IMascotaFirebaseService mascotaFirebaseService)
        {
            _usuarioRepository = usuarioRepository;
            _mascotaRepository = mascotaRepository;
            _usuarioFirebaseService = usuarioFirebaseService;
            _mascotaFirebaseService = mascotaFirebaseService;
        }

        public async Task SincronizarUsuariosAsync()
        {
            if (!await ConnectivityInternet()) return;

            var locales = await _usuarioRepository.GetAllAsync();
            var noSincronizados = locales.Where(u => !u.Sincronizado).ToList();

            foreach (var usuario in noSincronizados)
            {
                await _usuarioFirebaseService.SaveUsuarioAsync(usuario);

                usuario.Sincronizado = true;
                await _usuarioRepository.UpdateAsync(usuario);
            }
        }

        public async Task SincronizarMascotasAsync()
        {
            if (!await ConnectivityInternet()) return;

            var locales = await _mascotaRepository.GetAllAsync();
            var noSincronizadas = locales.Where(m => !m.Sincronizado).ToList();


            foreach (var mascota in noSincronizadas)
            {
                await _mascotaFirebaseService.SaveMascotaAsync(mascota);

                mascota.Sincronizado = true;
                await _mascotaRepository.UpdateAsync(mascota);
            }
        }

        private async Task<bool> ConnectivityInternet()
        {

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Sin conexión", "Necesitas conexión a Internet para sincronizar.", "OK");
                return false;
            }
            return true;
        }
    }
}
