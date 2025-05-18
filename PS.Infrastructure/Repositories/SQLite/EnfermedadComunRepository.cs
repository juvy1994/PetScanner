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
    public class EnfermedadComunRepository : BaseRepository<EnfermedadComunDTO>, IEnfermedadComunRepository
    {
        public EnfermedadComunRepository(SQLiteAsyncConnection connection) : base(connection)
        {
        }

        public async Task<int> AddAsync(EnfermedadComunModel entity)
        {
            var dto = EnfermedadComunDTO.FromModel(entity);
            return await base.AddAsync(dto);
        }

        public async Task<int> DeleteAsync(EnfermedadComunModel entity)
        {
            var dto = EnfermedadComunDTO.FromModel(entity);
            return await base.DeleteAsync(dto); ;
        }

        public async Task<List<EnfermedadComunModel>> GetByMascotaIdAsync(string mascotaId)
        {
            var dtos = await _connection.Table<EnfermedadComunDTO>()
                                        .Where(e => e.MascotaId == mascotaId)
                                        .ToListAsync();

            return dtos.Select(dto => dto.ToModel()).ToList();
        }

        public async Task<int> UpdateAsync(EnfermedadComunModel entity)
        {
            var dto = EnfermedadComunDTO.FromModel(entity);
            return await base.UpdateAsync(dto);
        }

        async Task<List<EnfermedadComunModel>> IBaseRepository<EnfermedadComunModel>.GetAllAsync()
        {
            var dtos = await base.GetAllAsync();
            return dtos.Select(dto => dto.ToModel()).ToList();
        }

        async Task<EnfermedadComunModel> IBaseRepository<EnfermedadComunModel>.GetByIdAsync(string id)
        {
            var dto = await base.GetByIdAsync(id);
            return dto?.ToModel(); ;
        }
    }
}
