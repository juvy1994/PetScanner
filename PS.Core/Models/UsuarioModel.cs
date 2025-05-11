using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Models
{
    public class UsuarioModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public bool Sincronizado { get; set; }
    }
}
