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
    public class UsuarioRepository : BaseRepository<UsuarioDTO>, IUsuarioRepository
    {
        public UsuarioRepository(SQLiteAsyncConnection connection) : base(connection)
        {
        }

        public async Task<int> AddAsync(UsuarioModel entity)
        {
            var dto = UsuarioDTO.FromModel(entity);
            return await base.AddAsync(dto);
        }

        public async Task<int> DeleteAsync(UsuarioModel entity)
        {
            var dto = UsuarioDTO.FromModel(entity);
            return await base.DeleteAsync(dto);
        }

        public async Task<int> UpdateAsync(UsuarioModel entity)
        {
            var dto = UsuarioDTO.FromModel(entity);
            return await base.UpdateAsync(dto);
        }

        async Task<List<UsuarioModel>> IBaseRepository<UsuarioModel>.GetAllAsync()
        {
            var dtos = await base.GetAllAsync();
            return dtos.Select(dto => dto.ToModel()).ToList();
        }

        async Task<UsuarioModel> IBaseRepository<UsuarioModel>.GetByIdAsync(string id)
        {
            var dto = await base.GetByIdAsync(id);
            return dto?.ToModel();
        }
    }
}
