using PS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Interfaces
{
    public interface IMascotaRepository : IBaseRepository<MascotaModel>
    {
        Task<List<MascotaModel>> GetByUsuarioIdAsync(string usuarioId);
    }
}
