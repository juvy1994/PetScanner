using PS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Interfaces
{
    public interface IMascotaFirebaseService : IBaseFirebaseService<MascotaModel>
    {   /*
        Task<List<MascotaModel>> GetMascotasAsync();
        Task SaveMascotaAsync(MascotaModel mascota);
        Task DeleteMascotaAsync(string id);
        */
    }
}
