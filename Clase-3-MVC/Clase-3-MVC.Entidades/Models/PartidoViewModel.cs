using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_3_MVC.Entidades.Models

{
    public class PartidoViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }

        public bool BuscarPorFecha(PartidoViewModel partido, int dia, int mes, int anio)
        {
            if(partido.Fecha.Day == dia && partido.Fecha.Month == mes && partido.Fecha.Year == anio)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
