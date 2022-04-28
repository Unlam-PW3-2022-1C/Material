using Clase_Layouts_PartialViews_Validaciones.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Clase_Layouts_PartialViews_Validaciones.Controllers
{
    public class UsuariosController : Controller
    {
        static List<Usuario> _listaUsuarios { get; set; } = new List<Usuario>();

        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Nuevo(Models.Usuario usuario)
        {
            _listaUsuarios.Add(usuario);
            return RedirectToAction(nameof(Lista));
        }
        public IActionResult Lista()
        {
            return View(_listaUsuarios);
        }
    }
}
