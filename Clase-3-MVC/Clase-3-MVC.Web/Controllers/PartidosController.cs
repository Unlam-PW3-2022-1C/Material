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

        private readonly ServicioPartido _servicioPartido;

        public PartidosController(ServicioPartido servicioEquipo)
        {
            _servicioPartido = servicioEquipo;

        }


        // GET: PartidosController
        public IActionResult Lista()
        {
            List<Partido> listPartidos = _servicioPartido.ObtenerPartidos();
            return View(listPartidos);
        }

        public IActionResult DelDia(IFormCollection colection)
        {
            List<Partido> partidosDeEseDia;
            try
            {
                partidosDeEseDia = _servicioPartido.ConsultarFecha(colection);
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

            _servicioPartido.AgregarNuevoPartido(collection);
            return RedirectToAction(nameof(Lista));

        }

        // GET: PartidosController/NuevoBindingManual
        public ActionResult NuevoBindingManual()//ver binding
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            Partido partido = _servicioPartido.ObtenerPartidoPorId(id);
            return View(partido);
        }

        [HttpPost]
        public ActionResult Editar(IFormCollection collection)
        {
            int id = Int32.Parse(collection["id"]);
            DateTime fecha = Convert.ToDateTime(collection["fecha"]);
            String lugar = collection["lugar"];

            _servicioPartido.Editar(id, fecha, lugar);

            return RedirectToAction(nameof(Lista));
        }



    }
}
