using Clase_3_MVC.Entidades;
using Clase_3_MVC.Servicios;
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

        private readonly ServicioPartido ISEquipo;

        public PartidosController(ServicioPartido servicioEquipo)
        {
            ISEquipo = servicioEquipo;

        }


        // GET: PartidosController
        public IActionResult Lista()
        {
            List<Partido> listPartidos = ISEquipo.ObtenerPartidos();
            return View(listPartidos);
        }

        public IActionResult DelDia(IFormCollection colection)
        {
            List<Partido> partidosDeEseDia;
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

            ListaEquipos equipos = new ListaEquipos();
            List<Equipo> listEQ = equipos.GetEquipos();
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
