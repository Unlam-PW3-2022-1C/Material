using Clase_3_MVC.Entidades.Models;
using Clase_3_MVC.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_3_MVC.Web.Controllers
{
    public class EquiposController : Controller
    {
        private readonly IEquipoService _equipoService;

        public EquiposController(IEquipoService equipoService)
        {
            _equipoService = equipoService;
        }
        
        // GET: EquiposController
        public ActionResult ListaEquipos()
        {
            return View(_equipoService.ObtenerTodos());
        }
     

        public ActionResult Agregar()
        {
            return View();
        }

        // POST: EquiposController/Agregar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(EquipoViewModel equipo)
        {
            try
            {
                _equipoService.Agregar(equipo);
                return RedirectToAction(nameof(ListaEquipos));
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Eliminar(int id)
        {
            if(Request.Form["Confirmar"] == "Cancelar")
            {
                return RedirectToAction(nameof(ListaEquipos));
            }
            _equipoService.Borrar(id);
            return RedirectToAction(nameof(ListaEquipos));
        }
        public ActionResult EliminarConfirmacion(int id)
        {
            EquipoViewModel equipo = _equipoService.ObtenerTodos().Find(o => o.Id == id);
            return View(equipo);
        }
    }
}
