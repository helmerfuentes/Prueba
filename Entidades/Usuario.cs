using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
   public class Usuario
    {

        public long Id { get; set; }
        public string usuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Rol Rol { get; set; }

        public Usuario()
        {
            Rol = new Rol();
        }

    }
}
