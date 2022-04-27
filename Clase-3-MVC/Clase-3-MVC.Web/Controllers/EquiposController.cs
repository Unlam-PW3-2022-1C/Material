using Clase_3_MVC.Entidades;
using Clase_3_MVC.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Clase_3_MVC.Web.Controllers
{
    public class EquiposController : Controller
    {

        ServicioEquipo _servicioEquipo;

        public EquiposController(ServicioEquipo servicioEquipo)
        {
            _servicioEquipo = servicioEquipo;
        }

        public IActionResult Lista()
        {
            List<Equipo> listEquipo = _servicioEquipo.ObtenerTodos();
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
        public ActionResult Nuevo(Equipo equipoNuevo)
        {
            _servicioEquipo.AgregarEquipo(equipoNuevo);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Editar(int id)
        {
            List<string> paises = _servicioEquipo.ObtenerPaises();
            ViewBag.TodosPaises = paises;

            Equipo equipo = _servicioEquipo.DevolverEquipo(id);
            return View(equipo);
        }


        [HttpPost]
        public ActionResult Editar(Equipo equipoNuevo)
        {
            _servicioEquipo.Editar(equipoNuevo.Id, equipoNuevo);

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        [Route("Equipos/info/{nombre?}")]
        public ActionResult Info(string nombre)
        {

            Equipo equipo = _servicioEquipo.DevolverEquipo(nombre);
            return View(equipo);

        }

      
    }
}
