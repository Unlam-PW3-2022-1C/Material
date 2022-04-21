using Clase_3_MVC.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Clase_3_MVC.Web.Servicio
{
    public class ServicioEquipo : IServicioEquipo
    {
        static Equipos equipos = new Equipos();
        List<EquipoViewModel> ListaEQ = equipos.GetEquipos();

        public ServicioEquipo()
        {
        }

       

        public void AgregarEquipo(EquipoViewModel equipoNuevo)
        {
            int id = ObtenerIdMasUno();

            equipoNuevo.Id = id;

            ListaEQ.Add(equipoNuevo);
        }

        public EquipoViewModel DevolverEquipo(string nombre)
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

        public EquipoViewModel DevolverEquipo(int id)
        {
            return ListaEQ.Find(o => o.Id == id);
        }

        public EquipoViewModel Editar(int id, EquipoViewModel equipoNuevo)
        {
            EquipoViewModel equipoActual = DevolverEquipo(id);
            equipoActual.Nombre = equipoNuevo.Nombre;
            equipoActual.Pais = equipoNuevo.Pais;

            return equipoActual;
        }

        public void EliminarEquipo(int id)
        {

            ListaEQ.Remove(DevolverEquipo(id));
            Partidos partidos = new Partidos();
            List<PartidoViewModel> listPartidos = partidos.GetPartidos();
            for (int i = 0; i < listPartidos.Count; i++) {

                if (listPartidos[i].Local.Id == id || listPartidos[i].Visitante.Id == id) {
                    listPartidos.Remove(listPartidos[i]);
                    
                }
            }

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

        public List<EquipoViewModel> ObtenerTodos()
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
