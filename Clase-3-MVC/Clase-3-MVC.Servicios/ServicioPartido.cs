using Clase_3_MVC.Entidades;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Clase_3_MVC.Servicios
{
    public interface ServicioPartido
    {
        List<Partido> ObtenerPartidos();
        List<Partido> ConsultarFecha(IFormCollection colection);
        void AgregarNuevoPartido(IFormCollection collection);
    }
}
