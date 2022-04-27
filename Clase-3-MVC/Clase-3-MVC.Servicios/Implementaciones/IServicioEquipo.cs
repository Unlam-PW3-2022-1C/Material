
using Clase_3_MVC.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Clase_3_MVC.Servicios
{
    public class IServicioEquipo : ServicioEquipo
    {
        static ListaEquipos equipos = new ListaEquipos();
        List<Equipo> ListaEQ = equipos.GetEquipos();

        public void AgregarEquipo(Equipo equipoNuevo)
        {
            int id = ObtenerIdMasUno();

            equipoNuevo.Id = id;

            ListaEQ.Add(equipoNuevo);
        }

        public Equipo DevolverEquipo(string nombre)
        {
            foreach (Equipo equipo in ListaEQ)
            {
                if (equipo.Nombre == nombre)
                {

                    return equipo;
                }
            }
            return null;
        }

        public Equipo DevolverEquipo(int id)
        {
            return ListaEQ.Find(o => o.Id == id);
        }

        public Equipo Editar(int id, Equipo equipoNuevo)
        {
            Equipo equipoActual = DevolverEquipo(id);
            equipoActual.Nombre = equipoNuevo.Nombre;
            equipoActual.Pais = equipoNuevo.Pais;

            return equipoActual;
        }

        public List<string> ObtenerPaises()
        {
            List<string> paisesExistentes = new List<string>();

            foreach (Equipo equipo in ListaEQ)
            {

                if (!paisesExistentes.Contains(equipo.Pais))
                {
                    paisesExistentes.Add(equipo.Pais);
                }

            }

            return paisesExistentes;
        }

        public List<Equipo> ObtenerTodos()
        {
            return ListaEQ;
        }

        private int ObtenerIdMasUno()
        {
            return ListaEQ.Max(o => o.Id) + 1; 
            //int idMayor = ListaEQ[0].Id;

            //for (int i = 1; i < ListaEQ.Count; i++)
            //{
            //    if (ListaEQ[i].Id > idMayor)
            //    {
            //        idMayor = ListaEQ[i].Id;
            //    }
            //}
            //idMayor++;
            //return idMayor;
        }
    }
}
