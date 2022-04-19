using Clase_3_MVC.Entidades.Models;
using Clase_3_MVC.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_3_MVC.Web.Controllers
{
    public class PartidosController : Controller
    {
        private readonly IPartidoService _partidoService;

        public PartidosController(IPartidoService partidoService)
        {
            _partidoService = partidoService;
        }

        [HttpGet]
        public ActionResult Lista()
        {
            return View(_partidoService.ObtenerTodos());
        }

        // GET: PartidosController/NuevoBindingManual
        public ActionResult NuevoBindingManual()
        {
            return View();
        }

        // POST: PartidosController/Nuevo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoBindingManual(IFormCollection collection)
        {
            try
            {
                _partidoService.Agregar(collection);
                return RedirectToAction(nameof(Lista));
            }
            catch
            {
                return View();
            }
        }

        // GET: PartidosController/Nuevo
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: PartidosController/Nuevo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(PartidoViewModel partido)
        {
            try
            {
                _partidoService.Agregar(partido);
                return RedirectToAction(nameof(Lista));
            }
            catch
            {
                return View();
            }
        }
        // GET: PartidosController/Eliminar/5
        public ActionResult Eliminar(int id)
        {
            if (Request.Form["Confirmar"] == "Cancelar")
            {
                return RedirectToAction(nameof(Lista));
            }
            _partidoService.Borrar(id);
            return RedirectToAction(nameof(Lista));
        }

        //// GET: PartidosController/EliminarConfirmacion/5
        public ActionResult EliminarConfirmacion(int id)
        {
            PartidoViewModel partido = _partidoService.ObtenerTodos().Find(o => o.Id == id);
            return View(partido);
        }

        public ActionResult PartidoNotFound()
        {
            return View();
        }

        [Route("Partidos/DelDia/{dia}/{mes}/{anio}")]
        public ActionResult DelDia(int dia, int mes, int anio)
        {
            List<PartidoViewModel> partidosFecha = _partidoService.BuscarPorFecha(dia, mes, anio);

            if (partidosFecha != null)
            {
                return View(partidosFecha);

            }
            return RedirectToAction(nameof(PartidoNotFound));


        }
    }
}
