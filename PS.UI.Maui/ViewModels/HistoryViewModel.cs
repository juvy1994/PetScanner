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

        private readonly IEnfermedadComunRepository _enfermedadComunRepository;
        private readonly IEnfermedadComunFirebaseService _enfermedadComunFirebaseService;

        public HistoryViewModel(IMascotaRepository mascotaRepository, IMascotaFirebaseService mascotaFirebaseService, 
            IEnfermedadComunRepository enfermedadComunRepository, IEnfermedadComunFirebaseService enfermedadComunFirebaseService)
        {
            _mascotaRepository = mascotaRepository;
            _mascotaFirebaseService = mascotaFirebaseService;

            _enfermedadComunRepository = enfermedadComunRepository;
            _enfermedadComunFirebaseService = enfermedadComunFirebaseService;
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


                var enfermedades = await _enfermedadComunRepository.GetByMascotaIdAsync(mascotaModel.Id);
                

                foreach (var enf in enfermedades) {

                    var listEnfermedades = new EnfermedadComunModel
                    {
                        Id = enf.Id,
                        Nombre = enf.Nombre,
                        Descripcion = enf.Descripcion,
                        Prevencion = enf.Prevencion,
                        Estado = enf.Estado,
                        Sincronizado = enf.Sincronizado
                    };
                    await _enfermedadComunFirebaseService.DeleteAsync(enf.Id);
                    await _enfermedadComunRepository.DeleteAsync(listEnfermedades);
                }

                await _mascotaRepository.DeleteAsync(mascotaModel);
                await _mascotaFirebaseService.DeleteAsync(mascotaModel.Id);

                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
