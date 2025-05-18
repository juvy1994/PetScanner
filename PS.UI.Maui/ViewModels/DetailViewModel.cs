using Microsoft.EntityFrameworkCore.Query.Internal;
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
        private readonly IMascotaFirebaseService _mascotaFirebaseService;

        private readonly IEnfermedadComunRepository _enfermedadComunRepository;
        private readonly IEnfermedadComunFirebaseService _enfermedadComunFirebaseService;

        public string rutaImagenLocal;

        public Action<string>? MostrarAlerta { get; set; }


        public DetailViewModel(IMascotaRepository mascotaRepository, IMascotaFirebaseService mascotaFirebaseService,
            IEnfermedadComunRepository enfermedadComunRepository, IEnfermedadComunFirebaseService enfermedadComunFirebaseService)
        {
            _mascotaRepository = mascotaRepository;
            _mascotaFirebaseService = mascotaFirebaseService;

            _enfermedadComunRepository = enfermedadComunRepository;
            _enfermedadComunFirebaseService = enfermedadComunFirebaseService;
        }

        public async Task GuardarMascotaAsync(MascotaModel mascota)
        {
            await _mascotaRepository.AddAsync(mascota);

            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                await _mascotaFirebaseService.SaveAsync(mascota);

                mascota.Sincronizado = true;
                await _mascotaRepository.UpdateAsync(mascota);
            }
            else
            {
                MostrarAlerta?.Invoke("No hay conexión a Internet.");
            }
        }

        public async Task GuardarEnferdadComunAsync(EnfermedadComunModel enfermedadComunModel)
        {
            await _enfermedadComunRepository.AddAsync(enfermedadComunModel);

            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                enfermedadComunModel.Sincronizado = true;
                await _enfermedadComunFirebaseService.SaveAsync(enfermedadComunModel);
            }
            else
            {
                MostrarAlerta?.Invoke("No hay conexión a Internet.");
            }
        }
    }
}
