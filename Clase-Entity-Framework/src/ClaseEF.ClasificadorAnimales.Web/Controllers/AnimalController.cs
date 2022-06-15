using ClaseEF.ClasificadorAnimales.Data.EF;
using ClaseEF.ClasificadorAnimales.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaseEF.ClasificadorAnimales.Web.Controllers
{
    public class AnimalController : Controller
    {
        ITipoAnimalServicio _tipoAnimalServicio;
        IAnimalServicio _animalServicio;
        public AnimalController(ITipoAnimalServicio tipoAnimalServicio, IAnimalServicio animalServicio)
        {
            _tipoAnimalServicio = tipoAnimalServicio;
            _animalServicio = animalServicio;
        }

        [HttpGet]
        public ActionResult Alta()
        {
            ViewBag.TipoAnimales = _tipoAnimalServicio.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public ActionResult Alta(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TipoAnimales = _tipoAnimalServicio.ObtenerTodos();
                return View(animal);
            }

            _animalServicio.Insertar(animal);
            return RedirectToAction("Lista");
        }

        [HttpGet]
        public ActionResult Lista()
        {
            //ViewBag.TipoAnimales = _tipoAnimalServicio.ObtenerTodos();
            return View(_animalServicio.ObtenerTodos());
        }
    }
}
