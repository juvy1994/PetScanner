using PS.Core.Interfaces;
using PS.Core.Models;
using PS.Infrastructure.DTOs;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Repositories
{
    public class MascotaRepository : BaseRepository<MascotaDTO>, IMascotaRepository
    {
        public MascotaRepository(SQLiteConnection connection) : base(connection)
        {
        }

        public int Add(MascotaModel entity)
        {
            var dto = MascotaDTO.FromModel(entity);
            return base.Add(dto);
        }

        public int Delete(MascotaModel entity)
        {
            var dto = MascotaDTO.FromModel(entity);
            return base.Delete(dto);
        }

        public List<MascotaModel> GetByUsuarioId(string usuarioId)
        {
            var dtos = _connection.Table<MascotaDTO>()
                         .Where(m => m.UsuarioId == usuarioId)
                         .ToList();

            return dtos.Select(dto => dto.ToModel()).ToList();
        }

        public int Update(MascotaModel entity)
        {
            var dto = MascotaDTO.FromModel(entity);
            return base.Update(dto);
        }

        List<MascotaModel> IBaseRepository<MascotaModel>.GetAll()
        {
            return base.GetAll().Select(dto => dto.ToModel()).ToList();
        }

        MascotaModel IBaseRepository<MascotaModel>.GetById(string id)
        {
            var dto = base.GetById(id);
            return dto?.ToModel();
        }
    }
}
