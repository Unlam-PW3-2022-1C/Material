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
                new PartidoViewModel() {  Fecha = new DateTime(2022, 4, 12), Lugar = "La Bombonera" },
                new PartidoViewModel() {  Fecha = new DateTime(2022, 4, 13), Lugar = "El Monumental" },
            };

        // GET: PartidosController
        public ActionResult Lista()
        {
            return View(_partidos);
        }

        // GET: PartidosController/Nuevo
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: PartidosController/Nuevo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(IFormCollection collection)
        {
            try
            {
                PartidoViewModel nuevoPartido = new PartidoViewModel() 
                {
                    Fecha = Convert.ToDateTime(collection["FechaHora"]), 
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

        // GET: PartidosController/Eliminar/5
        public ActionResult Eliminar(int id)
        {
            return View();
        }

        // POST: PartidosController/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
