using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_3_MVC.Web.Models
{
    public class PartidoViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public EquipoViewModel local { get; set; }
        public EquipoViewModel visitante { get; set; }
        public string resultado { get; set; }
    }
}
