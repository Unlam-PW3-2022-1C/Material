using Clase_3_MVC.Web.Models;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Services.Implementations
{
    public class EquiposService : IEquiposService
    {
        private static List<EquipoViewModel> _equipos = new List<EquipoViewModel>()
            {
                new EquipoViewModel() { Id =1,  Nombre = "Boca", Pais = "Argentina", Liga = "Primera División de Argentina" },
                new EquipoViewModel() { Id =2,  Nombre = "River", Pais = "Argentina", Liga = "Primera División de Argentina" }
            };
        public IEnumerable<EquipoViewModel> Lista()
        {
            try
            {
                return _equipos;
            }
            catch (System.Exception)
            {
                throw new System.NotImplementedException();
            }
        }
        public void Nuevo(EquipoViewModel nuevoEquipo)
        {
            try
            {
                _equipos.Add(nuevoEquipo);
            }
            catch (System.Exception)
            {
                throw new System.NotImplementedException();
            }

        }
        public EquipoViewModel Encontrar(int id)
        {
            try
            {
                return _equipos.Find(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw new System.NotImplementedException();
            }
        }
        public void Eliminar(int id)
        {
            try
            {
                _equipos.RemoveAll(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw new System.NotImplementedException();
            }

        }
    }
}
