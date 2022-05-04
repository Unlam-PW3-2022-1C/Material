using Microsoft.AspNetCore.Mvc;
using System;

namespace Clase_Pasaje_De_Datos.Controllers
{
    public class CalculadorDeGastosController : Controller
    {
        private static readonly string[] Meses = new[]
        {
            "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
        };

        public IActionResult Index()
        {
            //ejemplo ViewData
            ViewData["Meses"] = Meses;
            //ejemplo ViewBag
            ViewBag.MesActual = Meses[DateTime.Now.Month - 1];

            return View();
        }

        [HttpPost]
        public IActionResult Index(string mes)
        {
            int index = Array.IndexOf(Meses, mes);
            if (index > 6)
            {
                TempData["Gastos"] = 50000;
            }
            else
            {
                TempData["Gastos"] = 0;
            }
            return Redirect($"/CalculadorDeGastos/Resultado");
        }

        public IActionResult Resultado()
        {
            return View();
        }
    }
}
