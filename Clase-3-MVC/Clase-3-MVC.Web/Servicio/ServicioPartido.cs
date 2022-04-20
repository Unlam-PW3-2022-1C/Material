using Clase_3_MVC.Web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Servicio
{
    public class ServicioPartido : IServicioPartido
    {

        Partidos partidos = new Partidos();
        Equipos equipos = new Equipos();


        public List<PartidoViewModel> obtenerPartidos()
        {
            return partidos.getPartidos();
        }
        public void agregarNuevoPartido(PartidoViewModel partido)
        {
            partidos.addPartido(partido);
        }

        public List<PartidoViewModel> consultarFecha(IFormCollection collection)
        {

            List<PartidoViewModel> partidos = obtenerPartidos();

            DateTime fechaElegida = Convert.ToDateTime(collection["Fecha"]);
            List<PartidoViewModel> partidosDeEsaFecha = new List<PartidoViewModel>();

            foreach (PartidoViewModel partido in partidos)
            {

                if (partido.Fecha.Year == fechaElegida.Year &&
                    partido.Fecha.Month == fechaElegida.Month &&
                    partido.Fecha.Day == fechaElegida.Day)
                {

                    partidosDeEsaFecha.Add(partido);

                }
            }

            if (partidosDeEsaFecha.Count == 0)
            {
                throw new NoExistePartidosParaEsaFechaException();
            }

            return partidosDeEsaFecha;

        }

        public void agregarNuevoPartido(IFormCollection collection)


        {

            List<PartidoViewModel> partidos = obtenerPartidos();

            String nombreLocal = collection["NombreLocal"];
            String nombreVisitante = collection["NombreVisitante"];



            EquipoViewModel equipoLocal = obtenerEquipoLocal(nombreLocal);
            EquipoViewModel equipoVisitante = obtenerEquipoVisitante(nombreVisitante);


            PartidoViewModel partidoNuevo = new PartidoViewModel();

            partidoNuevo.local = equipoLocal;
            partidoNuevo.visitante = equipoVisitante;
            partidoNuevo.resultado = "-/-";
            partidoNuevo.Lugar = collection["Estadio"];
            partidoNuevo.Fecha = Convert.ToDateTime(collection["fecha"]);
            partidoNuevo.Id = partidos.Count + 1;

            partidos.Add(partidoNuevo);
        }

        private EquipoViewModel obtenerEquipoVisitante(string nombreVisitante)
        {


            foreach (var equipo in equipos.getEquipos())
            {
                if (equipo.Nombre == nombreVisitante)
                {
                    return equipo;
                }

            }
            return null;



        }

        private EquipoViewModel obtenerEquipoLocal(string nombreLocal)
        {

            foreach (var equipo in equipos.getEquipos())
            {
                if (equipo.Nombre == nombreLocal)
                {
                    return equipo;
                }

            }
            return null;
        }






    }



}

