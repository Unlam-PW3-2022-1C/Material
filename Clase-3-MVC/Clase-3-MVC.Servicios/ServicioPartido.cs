using Clase_3_MVC.Entidades;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Clase_3_MVC.Servicios
{
    public interface ServicioPartido
    {
        List<Partido> ObtenerPartidos();
        Partido ObtenerPartidoPorId(int id);
        List<Partido> ConsultarFecha(IFormCollection colection);
        void AgregarNuevoPartido(IFormCollection collection);
        Partido Editar(int id, DateTime fecha, string lugar);
    }
}
