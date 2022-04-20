using Clase_3_MVC.Web.Models;
using Clase_3_MVC.Web.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Controllers
{
    public class EquiposController : Controller
    {

        IServicioEquipo IServicioEq;

        public EquiposController(IServicioEquipo Ieq)
        {
            IServicioEq = Ieq;
        }

        // GET: EquiposController
        public ActionResult Nuevo()//me devuelve de la carpeta Equipos
                                   //la vista Nuevo por defecto
        {
            List<string> paises = IServicioEq.obtenerPaises();
            return View(paises);
        }

        // GET: EquiposController/crear
        public ActionResult crear(EquipoViewModel equipoNuevo)
        {
            IServicioEq.agregarEquipo(equipoNuevo);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Equipos/info/{nombre?}")]
        public ActionResult info(string nombre)
        {

            EquipoViewModel equipo = IServicioEq.devolverEquipo(nombre);
            return View(equipo);

        }

      
    }
}
