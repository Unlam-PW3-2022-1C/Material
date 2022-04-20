using System.Collections.Generic;

namespace Clase_3_MVC.Web.Models
{
    public class Equipos
    {

        private static List<EquipoViewModel> _equipos = new List<EquipoViewModel>()
        {
                new EquipoViewModel{Id = 1, Nombre = "River Plate", Pais ="Argentina" },
                new EquipoViewModel{Id = 2, Nombre = "Boca Juniors", Pais ="Argentina" },
                new EquipoViewModel{Id = 3, Nombre = "Racing", Pais ="Argentina"},
                new EquipoViewModel{Id = 4, Nombre = "San Lorenzo", Pais ="Argentina" },
                new EquipoViewModel{Id = 5, Nombre = "Barcelona", Pais ="España" },
                new EquipoViewModel{Id = 6, Nombre = "Real Madrid", Pais ="España" },
                new EquipoViewModel{Id = 7, Nombre = "Lanus", Pais ="Argentina" },
                new EquipoViewModel{Id = 8, Nombre = "Liverpool", Pais ="Inglaterra" },
                new EquipoViewModel{Id = 8, Nombre = "PSG", Pais ="Francia" },
                new EquipoViewModel{Id = 8, Nombre = "Inter", Pais ="Italia" },
                new EquipoViewModel{Id = 8, Nombre = "Juventus", Pais ="Italia" },
                new EquipoViewModel{Id = 8, Nombre = "Bayern Munich", Pais ="Alemania" },
                new EquipoViewModel{Id = 8, Nombre = "Colo Colo", Pais ="Brazil" },
                new EquipoViewModel{Id = 8, Nombre = "Manchester United", Pais ="Inglaterra" }




        };

        public List<EquipoViewModel> getEquipos() { 
            return _equipos;
        }


        
    }
}
