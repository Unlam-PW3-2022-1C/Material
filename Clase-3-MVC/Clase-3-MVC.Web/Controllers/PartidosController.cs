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

        private readonly IServicioPartido ISePartidos;

        public PartidosController(IServicioPartido servicioEquipo)
        {
            ISePartidos = servicioEquipo;

        }


        // GET: PartidosController
        public IActionResult Lista()
        {
            List<PartidoViewModel> listPartidos = ISePartidos.ObtenerPartidos();
            return View(listPartidos);
        }

        public IActionResult DelDia(IFormCollection colection)
        {
            List<PartidoViewModel> partidosDeEseDia;
            try
            {
                partidosDeEseDia = ISePartidos.ConsultarFecha(colection);
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

            ISePartidos.AgregarNuevoPartido(collection);
            return RedirectToAction(nameof(Lista));

        }

        public IActionResult FormEdit(int id) {
            Equipos equipos = new Equipos();

            ViewBag.partido = (PartidoViewModel)ISePartidos.ObtenerPartido(id);
            ViewBag.equipos = (List<EquipoViewModel>)equipos.GetEquipos();
            DateTime fecha = ViewBag.partido.Fecha;

            string sfecha = fecha.ToString("yyyy-MM-ddThh:ss");


            ViewBag.fecha = sfecha;

            return View("FormularioEdicionPartido");

        }

        public IActionResult Edit(IFormCollection colection) {


            ISePartidos.EditarPartido(colection);
            return RedirectToAction(nameof(Lista));
        
        }





        //crear un controller y servicio para los equipos, que los liste, que los guarde y los implemente 
        //el servicio de partidos, que a la hora de cargar partidos me aparezcan en un option. 
    }
}
