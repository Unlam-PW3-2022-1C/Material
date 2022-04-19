using Clase_3_MVC.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_3_MVC.Servicios.Implementaciones
{
    public class EquipoService : IEquipoService
    {
        private static List<EquipoViewModel> _equipos = new List<EquipoViewModel>()
    {
        new EquipoViewModel(){Id=1, Nombre="Boca Juniors", Pais="Argentina" },
        new EquipoViewModel(){Id=2, Nombre="Club Deportivo Morón", Pais="Argentina" },
    };
        public List<EquipoViewModel> Agregar(EquipoViewModel equipo)
        {
            equipo.Id = _equipos.Max(o => o.Id) + 1;
            _equipos.Add(equipo);
            return _equipos;
        }

        public List<EquipoViewModel> Borrar(int id)
        {
            _equipos.RemoveAll(o => o.Id == id);
            return _equipos;
        }

        public List<EquipoViewModel> ObtenerTodos()
        {
            return _equipos;
        }
    }
}
