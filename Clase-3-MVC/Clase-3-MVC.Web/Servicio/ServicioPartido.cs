﻿using Clase_3_MVC.Web.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Servicio
{
    public interface ServicioPartido
    {
        List<PartidoViewModel> ObtenerPartidos();
        List<PartidoViewModel> ConsultarFecha(IFormCollection colection);
        void AgregarNuevoPartido(IFormCollection collection);
    }
}
