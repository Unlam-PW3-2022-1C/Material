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
            if (!ModelState.IsValid && string.IsNullOrEmpty(Request.Form["OtroTipo"]))
            {
                ViewBag.TipoAnimales = _tipoAnimalServicio.ObtenerTodos();
                return View(animal);
            }

            //en caso de que haya ingresado un nuevo tipo, lo agrego a la tabla y asigno al nuevo animal
            if (!string.IsNullOrEmpty(Request.Form["OtroTipo"]))
            {
                TipoAnimal nuevoTipoAnimal = new TipoAnimal() { Nombre = Request.Form["OtroTipo"] };
                _tipoAnimalServicio.Insertar(nuevoTipoAnimal);
                animal.IdTipoAnimal = nuevoTipoAnimal.IdTipoAnimal;
            }

            _animalServicio.Insertar(animal);
            return RedirectToAction("Lista");
        }

        [HttpGet]
        public ActionResult Lista()
        {
            ViewBag.TipoAnimales = _tipoAnimalServicio.ObtenerTodos();
            return View(_animalServicio.ObtenerTodos());
        }

        [HttpPost]
        public ActionResult Lista(int? IdTipoAnimal)
        {
            ViewBag.TipoAnimales = _tipoAnimalServicio.ObtenerTodos();
            if (IdTipoAnimal.HasValue)
            {
                return View(_animalServicio.ObtenerPorTipo(IdTipoAnimal.Value));
            }
            return View(_animalServicio.ObtenerTodos());
        }
    }
}
