using Clase_3_MVC.Web.Models;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Services
{
    public interface IEquiposService
    {
        IEnumerable<EquipoViewModel> Lista();
        void Nuevo(EquipoViewModel equipoNuevo);
        EquipoViewModel Encontrar(int id);
        void Eliminar(int id);
    }
}
