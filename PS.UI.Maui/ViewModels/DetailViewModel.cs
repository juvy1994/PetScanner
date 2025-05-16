using PS.Core.Interfaces;
using PS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.UI.Maui.ViewModels
{
    public class DetailViewModel
    {
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IMascotaFirebaseService _firebaseService;

        public Action<string>? MostrarAlerta { get; set; }


        public DetailViewModel(IMascotaRepository mascotaRepository, IMascotaFirebaseService firebaseService)
        {
            _mascotaRepository = mascotaRepository;
            _firebaseService = firebaseService;
        }

        public async Task GuardarMascotaAsync(MascotaModel mascota)
        {
            await _mascotaRepository.AddAsync(mascota);

            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                await _firebaseService.SaveMascotaAsync(mascota);

                mascota.Sincronizado = true;
                await _mascotaRepository.UpdateAsync(mascota);
            }
            else
            {
                MostrarAlerta?.Invoke("No hay conexión a Internet.");
            }
        }
    }
}
