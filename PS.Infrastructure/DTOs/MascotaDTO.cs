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
        public string CaracteristicasFisicasTamano { get; set; }
        public string CaracteristicasFisicasPeso { get; set; }
        public string CaracteristicasFisicasEsperanzaVida { get; set; }
        public string CaracteristicasFisicasPelaje { get; set; }
        public string AlimentacionTipoRecomendada { get; set; }
        public string AlimentacionPorciones { get; set; }
        public string AlimentacionFrecuencia { get; set; }
        public string CuidadosEspecialesEjercicio { get; set; }
        public string CuidadosEspecialesSocializacion { get; set; }
        public string RutaImagenLocal { get; set; }
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
            CaracteristicasFisicasTamano = this.CaracteristicasFisicasTamano,
            CaracteristicasFisicasPeso = this.CaracteristicasFisicasPeso,
            CaracteristicasFisicasEsperanzaVida = this.CaracteristicasFisicasEsperanzaVida,
            CaracteristicasFisicasPelaje = this.CaracteristicasFisicasPelaje,
            AlimentacionTipoRecomendada = this.AlimentacionTipoRecomendada,
            AlimentacionPorciones = this.AlimentacionPorciones,
            AlimentacionFrecuencia = this.AlimentacionFrecuencia,
            CuidadosEspecialesEjercicio = this.CuidadosEspecialesEjercicio,
            CuidadosEspecialesSocializacion = this.CuidadosEspecialesSocializacion,
            RutaImagenLocal = this.RutaImagenLocal,
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
            CaracteristicasFisicasTamano = model.CaracteristicasFisicasTamano,
            CaracteristicasFisicasPeso = model.CaracteristicasFisicasPeso,
            CaracteristicasFisicasEsperanzaVida = model.CaracteristicasFisicasEsperanzaVida,
            CaracteristicasFisicasPelaje = model.CaracteristicasFisicasPelaje,
            AlimentacionTipoRecomendada = model.AlimentacionTipoRecomendada,
            AlimentacionPorciones = model.AlimentacionPorciones,
            AlimentacionFrecuencia = model.AlimentacionFrecuencia,
            CuidadosEspecialesEjercicio = model.CuidadosEspecialesEjercicio,
            CuidadosEspecialesSocializacion = model.CuidadosEspecialesSocializacion,
            RutaImagenLocal = model.RutaImagenLocal,
            UrlImage = model.UrlImage,
            Estado = model.Estado,
            Sincronizado = model.Sincronizado,
            UsuarioId = model.UsuarioId

        };
    }
}
