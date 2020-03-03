using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
   public class Rol
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "campo requerido.")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]   
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "Maximo 500 caracteres")]
        public string Descripcion { get; set; }
        public RolEstado Estado { get; set; }
        public List<Modulo> ListaModulos{ get; set; }

        public Rol()
        {
            ListaModulos = new List<Modulo>();
        }
    }

    public enum RolEstado
    {
        Inactivo = 0,
        Activo = 1
    }
}
