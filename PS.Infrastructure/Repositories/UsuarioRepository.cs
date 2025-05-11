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
    public class UsuarioRepository : BaseRepository<UsuarioDTO>, IUsuarioRepository
    {
        public UsuarioRepository(SQLiteConnection connection) : base(connection)
        {
        }

        public int Add(UsuarioModel entity)
        {
            var dto = UsuarioDTO.FromModel(entity);
            return base.Add(dto);
        }

        public int Delete(UsuarioModel entity)
        {
            var dto = UsuarioDTO.FromModel(entity);
            return base.Delete(dto);
        }

        public int Update(UsuarioModel entity)
        {
            var dto = UsuarioDTO.FromModel(entity);
            return base.Update(dto);
        }

        List<UsuarioModel> IBaseRepository<UsuarioModel>.GetAll()
        {
            return base.GetAll().Select(dto => dto.ToModel()).ToList();
        }

        UsuarioModel IBaseRepository<UsuarioModel>.GetById(string id)
        {
            var dto = base.GetById(id);
            return dto?.ToModel();
        }
    }
}
