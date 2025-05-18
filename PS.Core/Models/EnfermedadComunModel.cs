using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Models
{
    public class EnfermedadComunModel
    {  
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Prevencion { get; set; }
        public bool Estado { get; set; }
        public bool Sincronizado { get; set; }

        public string MascotaId { get; set; }
    }
}
