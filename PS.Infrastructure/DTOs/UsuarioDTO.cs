using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.DTOs
{
    public class UsuarioDTO
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public bool Sincronizado { get; set; }

        public Core.Models.UsuarioModel ToModel() => new()
        {
            Id = this.Id,
            Nombre = this.Nombre,
            Estado = this.Estado,
            Sincronizado = this.Sincronizado
        };

        public static UsuarioDTO FromModel(Core.Models.UsuarioModel model) => new()
        {
            Id = model.Id,
            Nombre = model.Nombre,
            Estado = model.Estado,
            Sincronizado = model.Sincronizado
        };

    }
}
