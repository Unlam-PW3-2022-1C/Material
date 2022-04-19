using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_3_MVC.Entidades.Models;
using Microsoft.AspNetCore.Http;

namespace Clase_3_MVC.Servicios
{
    public interface IPartidoService
    {
        public List<PartidoViewModel> BuscarPorFecha(int dia, int mes, int anio);

        public List<PartidoViewModel> ObtenerTodos();

        public List<PartidoViewModel> Agregar(IFormCollection collection);

        public List<PartidoViewModel> Agregar(PartidoViewModel partido);

        public List<PartidoViewModel> Borrar(int id);
    }
}
