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
        public string Descripcion { get; set; }
        public string Comportamiento { get; set; }
        public string Alimentacion { get; set; }
        public string CuidadosEspeciales { get; set; }
        public string EnfermedadesComunes { get; set; }
        public string UrlImage { get; set; }
        public bool Estado { get; set; }
        public bool Sincronizado { get; set; }

        public string UsuarioId { get; set; }
    }
}
