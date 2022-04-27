using System.Collections.Generic;


namespace Clase_3_MVC.Entidades
{
    public class ListaEquipos
    {

        private static List<Equipo> _equipos = new List<Equipo>()
        {
                new Equipo{Id = 1, Nombre = "River Plate", Pais ="Argentina" },
                new Equipo{Id = 2, Nombre = "Boca Juniors", Pais ="Argentina" },
                new Equipo{Id = 3, Nombre = "Racing", Pais ="Argentina"},
                new Equipo{Id = 4, Nombre = "San Lorenzo", Pais ="Argentina" },
                new Equipo{Id = 5, Nombre = "Barcelona", Pais ="España" },
                new Equipo{Id = 6, Nombre = "Real Madrid", Pais ="España" },
                new Equipo{Id = 7, Nombre = "Lanus", Pais ="Argentina" },
                new Equipo{Id = 8, Nombre = "Liverpool", Pais ="Inglaterra" },
                new Equipo{Id = 9, Nombre = "PSG", Pais ="Francia" },
                new Equipo{Id = 10, Nombre = "Inter", Pais ="Italia" },
                new Equipo{Id = 11, Nombre = "Juventus", Pais ="Italia" },
                new Equipo{Id = 12, Nombre = "Bayern Munich", Pais ="Alemania" },
                new Equipo{Id = 13, Nombre = "Colo Colo", Pais ="Brazil" },
                new Equipo{Id = 14, Nombre = "Manchester United", Pais ="Inglaterra" }




        };

        public List<Equipo> GetEquipos() { 
            return _equipos;
        }


        
    }
}
