using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Models
{
    public class MascotaModel
    {
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
        public string EnfermedadNombre { get; set; }
        public string EnfermedadDescripcion { get; set; }
        public string EnfermedadPrevencion { get; set; }
        public string UrlImage { get; set; }
        public bool Estado { get; set; }
        public bool Sincronizado { get; set; }

        public string UsuarioId { get; set; }
    }
}
