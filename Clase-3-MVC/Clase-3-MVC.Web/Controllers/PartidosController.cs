using Clase_3_MVC.Web.Models;
using Clase_3_MVC.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Clase_3_MVC.Web.Controllers
{
    public class PartidosController : Controller
    {
        private readonly ILogger<PartidosController> _logger;
        private readonly IPartidosService _partidosService;

        public PartidosController(ILogger<PartidosController> looger, IPartidosService partidosService)
        {
            _logger = looger;
            _partidosService = partidosService;
        }

        [HttpGet]
        public ActionResult Lista()
        {
            return View(_partidosService.Lista());
        }

        [HttpGet]
        public ActionResult NuevoBindingManual()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoBindingManual(IFormCollection form)
        {
            try
            {
                _partidosService.NuevoBindingManual(form);
                return RedirectToAction(nameof(Lista));
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(PartidoViewModel partido)
        {
            try
            {
                _partidosService.Nuevo(partido);
                return RedirectToAction(nameof(Lista));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EliminarSinConfirmar(int id)
        {
            _partidosService.Eliminar(id);
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public ActionResult EliminarConfirmacion(int id)
        {
            return View(_partidosService.Encontrar(id));
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            if (Request.Form["Confirmar"] == "Cancelar")
            {
                return RedirectToAction(nameof(Lista));
            }
            _partidosService.Eliminar(id);
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public ActionResult Buscar()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult DelDia(DateTime fecha)
        {
            return RedirectToAction(nameof(DelDia), new { dia = fecha.Day, mes = fecha.Month, anio = fecha.Year });
        }
        [HttpGet]
        
        public ActionResult DelDia(int dia, int mes, int anio)
        {
            var partidos = _partidosService.EncontrarPartidos(dia, mes, anio);
            return View(partidos);
        }
    }
}
