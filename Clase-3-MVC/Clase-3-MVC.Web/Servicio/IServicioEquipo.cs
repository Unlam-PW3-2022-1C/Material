using Clase_3_MVC.Web.Models;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Servicio
{
    public interface IServicioEquipo

    {
        void AgregarEquipo(EquipoViewModel equipoNuevo);
        EquipoViewModel DevolverEquipo(string nombre);
        EquipoViewModel DevolverEquipo(int id);
        List<string> ObtenerPaises();
        List<EquipoViewModel> ObtenerTodos();
        EquipoViewModel Editar(int id, EquipoViewModel equipoNuevo);
    }
}
