using Clase_3_MVC.Entidades.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_3_MVC.Servicios.Implementaciones
{
    public class PartidoService : IPartidoService
    {
        private static List<PartidoViewModel> _partidos = new List<PartidoViewModel>()
        {
                new PartidoViewModel() { Id =1,  Fecha = new DateTime(2022, 4, 12), Lugar = "La Bombonera" },
                new PartidoViewModel() { Id =2, Fecha = new DateTime(2022, 4, 13), Lugar = "El Monumental" },
                new PartidoViewModel() { Id =3, Fecha = new DateTime(2022, 4, 13), Lugar = "Maracaná" },

            };
        
        public List<PartidoViewModel> ObtenerTodos()
        {
            return _partidos;
        }

        public List<PartidoViewModel> Agregar(IFormCollection collection)
        {
            PartidoViewModel nuevoPartido = new PartidoViewModel()
            {
                Id = _partidos.Max(o => o.Id) + 1,
                Fecha = Convert.ToDateTime(collection["Fecha"]),
                Lugar = collection["Lugar"]
            };
            _partidos.Add(nuevoPartido);
            return _partidos;
        }

        public List<PartidoViewModel> Agregar(PartidoViewModel partido)
        {
            _partidos.Add(partido);
            return _partidos;
        }

        public List<PartidoViewModel> Borrar(int id)
        {
            _partidos.RemoveAll(o => o.Id == id);
            return _partidos;
        }

        public List<PartidoViewModel> BuscarPorFecha(int dia, int mes, int anio)
        {
            List<PartidoViewModel> partidosPorFecha = _partidos.FindAll(o => o.Fecha.Day == dia && o.Fecha.Month == mes && o.Fecha.Year == anio);

            if (partidosPorFecha.Count > 0)
            {
                return partidosPorFecha;
            }
            return null;
        }

    }
}
