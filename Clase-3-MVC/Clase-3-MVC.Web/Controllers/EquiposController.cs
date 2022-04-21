using Clase_3_MVC.Web.Models;
using Clase_3_MVC.Web.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Controllers
{
    public class EquiposController : Controller
    {

        IServicioEquipo _servicioEquipo;

        public EquiposController(IServicioEquipo servicioEquipo)
        {
            _servicioEquipo = servicioEquipo;
        }

        // GET: EquiposController
        public ActionResult Nuevo()//me devuelve de la carpeta Equipos
                                   //la vista Nuevo por defecto
        {
            List<string> paises = _servicioEquipo.ObtenerPaises();
            return View(paises);
        }

        // GET: EquiposController/crear
        public ActionResult Crear(EquipoViewModel equipoNuevo)
        {
            _servicioEquipo.AgregarEquipo(equipoNuevo);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Equipos/info/{nombre?}")]
        public ActionResult Info(string nombre)
        {

            EquipoViewModel equipo = _servicioEquipo.devolverEquipo(nombre);
            return View(equipo);

        }

      
    }
}
