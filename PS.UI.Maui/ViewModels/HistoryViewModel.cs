using PS.Core.Interfaces;
using PS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.UI.Maui.ViewModels
{
    public class HistoryViewModel
    {
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IMascotaFirebaseService _mascotaFirebaseService;

        public HistoryViewModel(IMascotaRepository mascotaRepository, IMascotaFirebaseService firebaseService)
        {

            _mascotaRepository = mascotaRepository;
            _mascotaFirebaseService = firebaseService;
        }

        public async Task<List<MascotaModel>> GetByIdUsuario(string usuarioId)
        {

            var mascotas = await _mascotaRepository.GetByUsuarioIdAsync(usuarioId);
            return mascotas;
        }

        public async Task<int> EliminarMascotaAsync(MascotaModel mascotaModel)
        {
            try
            {
                if (mascotaModel == null || string.IsNullOrEmpty(mascotaModel.Id))
                    return 0;

                await _mascotaRepository.DeleteAsync(mascotaModel);
                await _mascotaFirebaseService.DeleteMascotaAsync(mascotaModel.Id);

                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
