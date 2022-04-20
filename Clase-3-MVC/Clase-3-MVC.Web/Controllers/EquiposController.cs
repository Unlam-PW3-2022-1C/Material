using Clase_3_MVC.Web.Models;
using Clase_3_MVC.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Clase_3_MVC.Web.Controllers
{
    public class EquiposController : Controller
    {

        private readonly ILogger<EquiposController> _logger;
        private readonly IEquiposService _equiposService;
        public EquiposController(ILogger<EquiposController> logger, IEquiposService equiposService)
        {
            _logger = logger;
            _equiposService = equiposService;
        }
        [HttpGet]
        public ActionResult Lista()
        {
            return View(_equiposService.Lista());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(EquipoViewModel nuevoEquipo)
        {
            _equiposService.Nuevo(nuevoEquipo);
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public ActionResult EliminarConfirmacion(int id)
        {
            return View(_equiposService.Encontrar(id));
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            if (Request.Form["Confirmar"] == "Cancelar")
            {
                return RedirectToAction(nameof(Lista));
            }
            _equiposService.Eliminar(id);
            return RedirectToAction(nameof(Lista));
        }
    }
}
