using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.DTOs
{
    public class MascotaDTO
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Origen { get; set; }
        public string Descripcion { get; set; }
        public string Comportamiento { get; set; }
        public string Alimentacion { get; set; }
        public string CuidadosEspeciales { get; set; }
        public string EnfermedadesComunes { get; set; }
        public string UrlImage { get; set; }
        public bool Estado { get; set; }
        public bool Sincronizado { get; set; }

        public string UsuarioId { get; set; }

        // 🔄 Conversión a Modelo del Core
        public Core.Models.MascotaModel ToModel() => new()
        {
            Id = this.Id,
            Nombre = this.Nombre,
            Especie = this.Especie,
            Origen = this.Origen,
            Descripcion = this.Descripcion,
            Comportamiento = this.Comportamiento,
            Alimentacion = this.Alimentacion,
            CuidadosEspeciales = this.CuidadosEspeciales,
            EnfermedadesComunes = this.EnfermedadesComunes,
            UrlImage = this.UrlImage,
            Estado = this.Estado,
            Sincronizado = this.Sincronizado,
            UsuarioId = this.UsuarioId

        };

        // 🔄 Conversión desde Modelo del Core
        public static MascotaDTO FromModel(Core.Models.MascotaModel model) => new()
        {
            Id = model.Id,
            Nombre = model.Nombre,
            Especie = model.Especie,
            Origen = model.Origen,
            Descripcion = model.Descripcion,
            Comportamiento = model.Comportamiento,
            Alimentacion = model.Alimentacion,
            CuidadosEspeciales = model.CuidadosEspeciales,
            EnfermedadesComunes = model.EnfermedadesComunes,
            UrlImage = model.UrlImage,
            Estado = model.Estado,
            Sincronizado = model.Sincronizado,
            UsuarioId = model.UsuarioId

        };
    }
}
