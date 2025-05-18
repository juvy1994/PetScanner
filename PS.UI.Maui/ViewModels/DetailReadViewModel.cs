using PS.Core.Interfaces;
using PS.Core.Models;
using PS.Infrastructure.Repositories.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.UI.Maui.ViewModels
{
    public class DetailReadViewModel
    {
        private readonly IEnfermedadComunRepository _enfermedadComunRepository;

        public DetailReadViewModel(IEnfermedadComunRepository enfermedadComunRepository) {
            _enfermedadComunRepository = enfermedadComunRepository;
        }

        public async Task<List<EnfermedadComunModel>> GetByIdMascota(string mascotaId)
        {
            var enfermedadComun = await _enfermedadComunRepository.GetByMascotaIdAsync(mascotaId);
            return enfermedadComun;
        }
    }
}
