using Clase_3_MVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clase_3_MVC.Web.Services.Implementations
{
    public class PartidosService : IPartidosService
    {
        private static List<PartidoViewModel> _partidos = new List<PartidoViewModel>()
            {
                new PartidoViewModel() { Id =1,  Fecha = new DateTime(2022, 4, 12), Lugar = "La Bombonera" },
                new PartidoViewModel() { Id =2, Fecha = new DateTime(2022, 4, 13), Lugar = "El Monumental" },
            };

        public IEnumerable<PartidoViewModel> Lista()
        {
            try
            {
                return _partidos;
            }
            catch (System.Exception)
            {

                throw new System.NotImplementedException();
            }
        }

        public void NuevoBindingManual(IFormCollection form)
        {
                PartidoViewModel nuevoPartido = new PartidoViewModel()
                {
                    Id = _partidos.Max(o => o.Id) + 1,
                    Fecha = Convert.ToDateTime(form["Fecha"]),
                    Lugar = form["Lugar"]
                };
                _partidos.Add(nuevoPartido);
        }

        public void Nuevo(PartidoViewModel partido)
        {
            _partidos.Add(partido);
        }

        public PartidoViewModel Encontrar(int id)
        {
            return _partidos.Find(x => x.Id == id);
        }

        public IEnumerable<PartidoViewModel> EncontrarPartidos(int dia, int mes, int anio)
        {
            var partidos = _partidos.FindAll(p => p.Dia == dia && p.Mes == mes && p.Anio == anio);
            return partidos;
        }

        public void Eliminar(int id)
        {
            _partidos.RemoveAll(x => x.Id == id);
        }
    }
}
