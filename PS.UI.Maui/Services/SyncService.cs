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
        private readonly IEnfermedadComunRepository _enfermedadComunRepository;

        private readonly IUsuarioFirebaseService _usuarioFirebaseService;
        private readonly IMascotaFirebaseService _mascotaFirebaseService;
        private readonly IEnfermedadComunFirebaseService _enfermedadComunFirebaseService;


        public SyncService(
            IUsuarioRepository usuarioRepository,
            IMascotaRepository mascotaRepository,
            IUsuarioFirebaseService usuarioFirebaseService,
            IMascotaFirebaseService mascotaFirebaseService,
            IEnfermedadComunRepository enfermedadComunRepository,
            IEnfermedadComunFirebaseService enfermeadadComunFirebaseService)
        {
            _usuarioRepository = usuarioRepository;
            _mascotaRepository = mascotaRepository;
            _usuarioFirebaseService = usuarioFirebaseService;
            _mascotaFirebaseService = mascotaFirebaseService;
            _enfermedadComunRepository = enfermedadComunRepository;
            _enfermedadComunFirebaseService = enfermeadadComunFirebaseService;
        }

        public async Task SincronizarUsuariosAsync()
        {
            if (!await ConnectivityInternet()) return;

            var locales = await _usuarioRepository.GetAllAsync();
            var noSincronizados = locales.Where(u => !u.Sincronizado).ToList();

            foreach (var usuario in noSincronizados)
            {
                await _usuarioFirebaseService.SaveAsync(usuario);

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
                await _mascotaFirebaseService.SaveAsync(mascota);

                mascota.Sincronizado = true;
                await _mascotaRepository.UpdateAsync(mascota);
            }
        }

        public async Task SincronizarEnfermedadComunAsync()
        {
            if (!await ConnectivityInternet()) return;

            var locales = await _enfermedadComunRepository.GetAllAsync();
            var noSincronizadas = locales.Where(e => !e.Sincronizado).ToList();


            foreach (var enfermedadComun in noSincronizadas)
            {
                await _enfermedadComunFirebaseService.SaveAsync(enfermedadComun);

                enfermedadComun.Sincronizado = true;
                await _enfermedadComunRepository.UpdateAsync(enfermedadComun);
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

        public async Task SincronizarTodoAsync()
        {
            await SincronizarUsuariosAsync();
            await SincronizarMascotasAsync();
            await SincronizarEnfermedadComunAsync();
        }
    }
}
