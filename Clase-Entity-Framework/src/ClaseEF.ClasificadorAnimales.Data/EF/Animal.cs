using System;
using System.Collections.Generic;

#nullable disable

namespace ClaseEF.ClasificadorAnimales.Data.EF
{
    public partial class Animal
    {
        public int IdAnimal { get; set; }
        public string NombreEspecie { get; set; }
        public double PesoPromedio { get; set; }
        public int EdadPromedio { get; set; }
        public int IdTipoAnimal { get; set; }

        public virtual TipoAnimal IdTipoAnimalNavigation { get; set; }
    }
}
