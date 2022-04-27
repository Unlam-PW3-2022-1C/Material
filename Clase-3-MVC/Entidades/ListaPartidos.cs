using System;
using System.Collections.Generic;

namespace Clase_3_MVC.Entidades
{
    public class ListaPartidos
    {
        private static ListaEquipos equipos = new ListaEquipos();

        private static List<Partido> _partidos = new List<Partido>()
            {
                

                new Partido() { Id =1,  Fecha = new DateTime(2020, 2, 11, 18,30,00), Lugar = "El Monumental",
                    local = equipos.GetEquipos()[0],
                    visitante = equipos.GetEquipos()[1], resultado= "1-1"},

                new Partido() { Id =2, Fecha = new DateTime(2020, 6, 25, 17,00,00), Lugar = "La Bombonera",
                    local = equipos.GetEquipos()[1] ,
                    visitante = equipos.GetEquipos()[3], resultado="2-0"},

                new Partido() { Id =3,  Fecha = new DateTime(2021, 7, 08, 21,30,00), Lugar = "Estadio unico de la plata"
                    ,local = equipos.GetEquipos()[2],
                    visitante = equipos.GetEquipos()[1] , resultado="5-0" },

                new Partido() { Id =4, Fecha = new DateTime(2021, 12, 13, 22,00,00), Lugar = "Mario Alberto Kempes"
                    ,local = equipos.GetEquipos()[3],
                    visitante =equipos.GetEquipos()[4], resultado="0-0" },

                 new Partido() { Id =5, Fecha = new DateTime(2021, 12, 13, 18,00,00), Lugar = "Mario Alberto Kempres"
                    ,local = equipos.GetEquipos()[2],
                    visitante = equipos.GetEquipos()[4], resultado="1-0" },

                 new Partido() { Id =6, Fecha = new DateTime(2021, 12, 13, 20,00,00), Lugar = "El Monumental"
                    ,local = equipos.GetEquipos()[3],
                    visitante = equipos.GetEquipos()[1], resultado="4-0" },
            };

        public List<Partido> GetPartidos() {

            return _partidos;
        }

        public void addPartido(Partido partido) { 
        
            _partidos.Add(partido);
        }

    }
}
