
using Clase_3_MVC.Entidades;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Clase_3_MVC.Servicios
{
    public class IServicioPartido : ServicioPartido
    {

        static ListaPartidos partidos = new ListaPartidos();
        List<Partido> ListPartidos = partidos.GetPartidos();
        static ListaEquipos equipos = new ListaEquipos();

        public List<Partido> ObtenerPartidos()
        {
            return partidos.GetPartidos();
        }
        public void AgregarNuevoPartido(Partido partido)
        {
            partidos.addPartido(partido);
        }

        public List<Partido> ConsultarFecha(IFormCollection collection)
        {

            List<Partido> partidos = ObtenerPartidos();

            DateTime fechaElegida = Convert.ToDateTime(collection["Fecha"]);
            List<Partido> partidosDeEsaFecha = new List<Partido>();

            foreach (Partido partido in partidos)
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

        public void AgregarNuevoPartido(IFormCollection collection)


        {

            List<Partido> partidos = ObtenerPartidos();

            String nombreLocal = collection["NombreLocal"];
            String nombreVisitante = collection["NombreVisitante"];



            Equipo equipoLocal = ObtenerEquipoLocal(nombreLocal);
            Equipo equipoVisitante = ObtenerEquipoVisitante(nombreVisitante);


            Partido partidoNuevo = new Partido();

            partidoNuevo.local = equipoLocal;
            partidoNuevo.visitante = equipoVisitante;
            partidoNuevo.resultado = "-/-";
            partidoNuevo.Lugar = collection["Estadio"];
            partidoNuevo.Fecha = Convert.ToDateTime(collection["fecha"]);
            partidoNuevo.Id = partidos.Count + 1;

            partidos.Add(partidoNuevo);
        }

        private Equipo ObtenerEquipoVisitante(string nombreVisitante)
        {


            foreach (var equipo in equipos.GetEquipos())
            {
                if (equipo.Nombre == nombreVisitante)
                {
                    return equipo;
                }

            }
            return null;



        }

        private Equipo ObtenerEquipoLocal(string nombreLocal)
        {

            foreach (var equipo in equipos.GetEquipos())
            {
                if (equipo.Nombre == nombreLocal)
                {
                    return equipo;
                }

            }
            return null;
        }

        public Partido Editar(int id, DateTime fecha, string lugar)
        {
            Partido partidoAhora = ObtenerPartidoPorId(id);
            partidoAhora.Fecha = fecha;
            partidoAhora.Lugar = lugar;

            return partidoAhora;
        }

        public Partido ObtenerPartidoPorId(int id)
        {
            Partido partido = ListPartidos.Find(o => o.Id == id);
            return partido;
        }
    }



}

