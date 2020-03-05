using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Permiso
    {
        public Opcion Opcion { get; set; }
        public Rol Rol { get; set; }
        public string Modulo { get; set; }
        public EnumPermiso Permitido{ get; set; }

        public Permiso()
        {
            Opcion = new Opcion();
            Rol = new Rol();

        }
    }

    public enum EnumPermiso
    {
        Permitido=1,
        NoPermitido=0
    }
}
