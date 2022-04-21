using Clase_3_MVC.Web.Models;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Servicio
{
    public class ServicioEquipo : IServicioEquipo
    {
        static Equipos equipos = new Equipos();
        List<EquipoViewModel> ListaEQ = equipos.getEquipos();

        public void AgregarEquipo(EquipoViewModel equipoNuevo)
        {
            int id = ObtenerIdMasUno();

            equipoNuevo.Id = id;

            ListaEQ.Add(equipoNuevo);
        }

        public EquipoViewModel devolverEquipo(string nombre)
        {
            foreach (EquipoViewModel equipo in ListaEQ)
            {
                if (equipo.Nombre == nombre)
                {

                    return equipo;
                }
            }
            return null;
        }

        public List<string> ObtenerPaises()
        {
            List<string> paisesExistentes = new List<string>();

            foreach (EquipoViewModel equipo in ListaEQ)
            {

                if (!paisesExistentes.Contains(equipo.Pais))
                {
                    paisesExistentes.Add(equipo.Pais);

                }


            }

            return paisesExistentes;
        }

        private int ObtenerIdMasUno()
        {


            int idMayor = ListaEQ[0].Id;

            for (int i = 1; i < ListaEQ.Count; i++)
            {
                if (ListaEQ[i].Id > idMayor)
                {
                    idMayor = ListaEQ[i].Id;
                }

            }
            idMayor++;
            return idMayor;
        }
    }
}
