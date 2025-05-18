using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.DTOs
{
    public class EnfermedadComunDTO
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Prevencion { get; set; }
        public bool Estado { get; set; }
        public bool Sincronizado { get; set; }

        public string MascotaId { get; set; }



        public Core.Models.EnfermedadComunModel ToModel() => new()
        {
            Id = this.Id,
            Nombre = this.Nombre,
            Descripcion = this.Descripcion,
            Prevencion = this.Prevencion,
            Estado = this.Estado,
            Sincronizado = this.Sincronizado,
            MascotaId = this.MascotaId
        };

        public static EnfermedadComunDTO FromModel(Core.Models.EnfermedadComunModel model) => new()
        {
            Id = model.Id,
            Nombre = model.Nombre,
            Descripcion = model.Descripcion,
            Prevencion=model.Prevencion,
            Estado=model.Estado,
            Sincronizado = model.Sincronizado,
            MascotaId = model.MascotaId
        };
    }
}