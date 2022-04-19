using Clase_3_MVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Services
{
    public interface IPartidosService
    {
        IEnumerable<PartidoViewModel> Lista();
        void NuevoBindingManual(IFormCollection form);
        void Nuevo(PartidoViewModel partido);
        PartidoViewModel Encontrar(int id);
        void Eliminar(int id);
        IEnumerable<PartidoViewModel> EncontrarPartidos(int dia, int mes, int anio);
    }
}
