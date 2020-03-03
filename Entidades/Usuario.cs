using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Usuario
    {

    
        public long Id { get; set; }

        [Required(ErrorMessage = "campo requerido.")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        [Display(Name = "First Name:")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "campo requerido.")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        [Display(Name = "First Name:")]
        public string Clave { get; set;
        }
        [Required(ErrorMessage = "campo requerido.")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres.")]
        [Display(Name = "First Name:")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "campo requerido.")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "First Name:")]
        public string Apellido { get; set; }

        public Rol Rol { get; set; }

        public Usuario()
        {
            Rol = new Rol();
        }

    }

    public enum enumUsuarios{
    Activo=1,
    Inactivo=2,
    Eliminado=3
    }

}
