using Clase_3_MVC.Web.Models;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Servicio
{
    public interface IServicioEquipo

    {
        void AgregarEquipo(EquipoViewModel equipoNuevo);

        EquipoViewModel devolverEquipo(string nombre);
        List<string> ObtenerPaises();
    }
}
