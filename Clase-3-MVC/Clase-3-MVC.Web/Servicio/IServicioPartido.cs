using Clase_3_MVC.Web.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Servicio
{
    public interface IServicioPartido
    {
        List<PartidoViewModel> obtenerPartidos();
        List<PartidoViewModel> consultarFecha(IFormCollection colection);
        void agregarNuevoPartido(IFormCollection collection);
    }
}
