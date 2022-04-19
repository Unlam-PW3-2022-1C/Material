using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_3_MVC.Entidades.Models;
using Microsoft.AspNetCore.Http;

namespace Clase_3_MVC.Servicios
{
    public interface IEquipoService
    {
        public List<EquipoViewModel> ObtenerTodos();

        public List<EquipoViewModel> Agregar(EquipoViewModel equipo);

        public List<EquipoViewModel> Borrar(int id);
    }
}
