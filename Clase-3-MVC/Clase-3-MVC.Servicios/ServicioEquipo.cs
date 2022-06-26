using Clase_3_MVC.Entidades;
using System.Collections.Generic;

namespace Clase_3_MVC.Servicios
{
    public interface ServicioEquipo

    {
        void AgregarEquipo(Equipo equipoNuevo);
        Equipo DevolverEquipo(string nombre);
        Equipo DevolverEquipo(int id);
        List<string> ObtenerPaises();
        List<Equipo> ObtenerTodos();
        Equipo Editar(int id, Equipo equipoNuevo);
    }
}
