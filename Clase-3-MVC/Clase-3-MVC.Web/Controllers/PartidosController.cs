using Clase_3_MVC.Web.Models;
using Clase_3_MVC.Web.Servicio;

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

        private readonly IServicioPartido ISEquipo;

        public PartidosController(IServicioPartido servicioEquipo)
        {
            ISEquipo = servicioEquipo;

        }


        // GET: PartidosController
        public IActionResult Lista()
        {
            List<PartidoViewModel> listPartidos = ISEquipo.ObtenerPartidos();
            return View(listPartidos);
        }

        public IActionResult DelDia(IFormCollection colection)
        {
            List<PartidoViewModel> partidosDeEseDia;
            try
            {
                partidosDeEseDia = ISEquipo.ConsultarFecha(colection);
            }
            catch (NoExistePartidosParaEsaFechaException e)
            {

                return RedirectToAction(nameof(Lista));

            }
            return View("Lista", partidosDeEseDia);
        }
        [HttpGet]
        public ActionResult FormularioNuevoPartido()
        {

            Equipos equipos = new Equipos();
            List<EquipoViewModel> listEQ = equipos.GetEquipos();
            return View(listEQ);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(IFormCollection collection) //binding manual
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            ISEquipo.AgregarNuevoPartido(collection);
            return RedirectToAction(nameof(Lista));

        }

        // GET: PartidosController/NuevoBindingManual
        public ActionResult NuevoBindingManual()//ver binding
        {
            return View();
        }





        //crear un controller y servicio para los equipos, que los liste, que los guarde y los implemente 
        //el servicio de partidos, que a la hora de cargar partidos me aparezcan en un option. 
    }
}
