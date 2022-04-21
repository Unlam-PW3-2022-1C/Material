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

        public IActionResult Lista()
        {
            List<EquipoViewModel> listEquipo = _servicioEquipo.ObtenerTodos();
            return View(listEquipo);
        }

        // GET: EquiposController
        public ActionResult Nuevo()//me devuelve de la carpeta Equipos
                                   //la vista Nuevo por defecto
        {
            List<string> paises = _servicioEquipo.ObtenerPaises();
            return View(paises);
        }

        [HttpPost]
        public ActionResult Nuevo(EquipoViewModel equipoNuevo)
        {
            _servicioEquipo.AgregarEquipo(equipoNuevo);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Editar(int id)
        {
            List<string> paises = _servicioEquipo.ObtenerPaises();
            ViewBag.TodosPaises = paises;

            EquipoViewModel equipo = _servicioEquipo.DevolverEquipo(id);
            return View(equipo);
        }


        [HttpPost]
        public ActionResult Editar(EquipoViewModel equipoNuevo)
        {
            _servicioEquipo.Editar(equipoNuevo.Id, equipoNuevo);

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        [Route("Equipos/info/{nombre?}")]
        public ActionResult Info(string nombre)
        {

            EquipoViewModel equipo = _servicioEquipo.DevolverEquipo(nombre);
            return View(equipo);

        }

      
    }
}
