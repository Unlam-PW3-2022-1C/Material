using Clase_3_MVC.Web.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Servicio
{
    public interface IServicioPartido
    {
        List<PartidoViewModel> ObtenerPartidos();
        List<PartidoViewModel> ConsultarFecha(IFormCollection colection);
        void AgregarNuevoPartido(IFormCollection collection);
        PartidoViewModel ObtenerPartido(int id);
        void EditarPartido(IFormCollection colection);
    }
}
