using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClasificadorAnimales.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string NombreEspecie { get; set; }
        public double PesoPromedio { get; set; }
        public int EdadPromedio { get; set; }
    }
}
