using Clase_Layouts_PartialViews_Validaciones.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace Clase_Layouts_PartialViews_Validaciones.Models
{
    public class Usuario
    {
        [Required(ErrorMessage= "Nombre es requerido")]
        public string Nombre { get; set; }
        [Url(ErrorMessage = "AvatarURL debe ser una URL val")]
        [Required(ErrorMessage = "AvatarURL es requerido")]
        public string AvatarURL { get; set; }
        [ExcluirDominios("gmail.com,yahoo.com")]
        public string Email { get; set; }
        [Range(1, 100000, ErrorMessage = "Puntos debe ser un valor entre 1-100000")]
        [Required(ErrorMessage = "Puntos es requerido")]
        public int Puntos { get; set; }
    }
}
