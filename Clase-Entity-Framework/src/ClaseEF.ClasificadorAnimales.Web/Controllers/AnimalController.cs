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
        public AnimalController(ITipoAnimalServicio tipoAnimalServicio)
        {
            _tipoAnimalServicio = tipoAnimalServicio;
        }

        [HttpGet]
        public ActionResult Alta()
        {
            List<TipoAnimal> tipoAnimales = _tipoAnimalServicio.ObtenerTodos();
            ViewBag.TipoAnimales = tipoAnimales;
            return View();
        }
    }
}
