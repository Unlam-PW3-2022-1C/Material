using Clase_3_MVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_3_MVC.Web.Controllers
{
    public class PartidosController : Controller
    {
        private static List<PartidoViewModel> _partidos = new List<PartidoViewModel>()
            {
                new PartidoViewModel() { Id =1,  Fecha = new DateTime(2022, 4, 12), Lugar = "La Bombonera" },
                new PartidoViewModel() { Id =2, Fecha = new DateTime(2022, 4, 13), Lugar = "El Monumental" },
            };

        // GET: PartidosController
        public ActionResult Lista()
        {
            return View(_partidos);
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
                PartidoViewModel nuevoPartido = new PartidoViewModel()
                {
                    Id = _partidos.Max(o => o.Id) + 1,
                    Fecha = Convert.ToDateTime(collection["Fecha"]),
                    Lugar = collection["Lugar"]
                };
                _partidos.Add(nuevoPartido);
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
                _partidos.Add(partido);
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
            _partidos.RemoveAll(o => o.Id == id);
            return RedirectToAction(nameof(Lista));
        }

        // GET: PartidosController/EliminarConfirmacion/5
        public ActionResult EliminarConfirmacion(int id)
        {
            PartidoViewModel partido = _partidos.Find(o => o.Id == id);
            return View(partido);
        }
    }
}
