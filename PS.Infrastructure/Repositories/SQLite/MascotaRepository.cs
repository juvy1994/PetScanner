using PS.Core.Interfaces;
using PS.Core.Models;
using PS.Infrastructure.DTOs;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Repositories.SQLite
{
    public class MascotaRepository : BaseRepository<MascotaDTO>, IMascotaRepository
    {
        public MascotaRepository(SQLiteAsyncConnection connection) : base(connection)
        {
        }

        public async Task<int> AddAsync(MascotaModel entity)
        {
            var dto = MascotaDTO.FromModel(entity);
            return await base.AddAsync(dto);
        }

        public async Task<int> DeleteAsync(MascotaModel entity)
        {
            var dto = MascotaDTO.FromModel(entity);
            return await base.DeleteAsync(dto);
        }

        public async Task<List<MascotaModel>> GetByUsuarioIdAsync(string usuarioId)
        {
            var dtos = await _connection.Table<MascotaDTO>()
                                        .Where(m => m.UsuarioId == usuarioId)
                                        .ToListAsync();

            return dtos.Select(dto => dto.ToModel()).ToList();
        }

        public async Task<int> UpdateAsync(MascotaModel entity)
        {
            var dto = MascotaDTO.FromModel(entity);
            return await base.UpdateAsync(dto);
        }

        async Task<List<MascotaModel>> IBaseRepository<MascotaModel>.GetAllAsync()
        {
            var dtos = await base.GetAllAsync();
            return dtos.Select(dto => dto.ToModel()).ToList();
        }

        async Task<MascotaModel> IBaseRepository<MascotaModel>.GetByIdAsync(string id)
        {
            var dto = await base.GetByIdAsync(id);
            return dto?.ToModel();
        }
    }
}
