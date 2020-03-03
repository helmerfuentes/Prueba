using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
   public class Opcion
    {
        public long Id { get; set; }
        public string  Nombre { get; set; }
        public string Descripcion { get; set; }
        public OpcionEnum Estado{ get; set; }
        public Modulo modulo { get; set; }
        public Opcion()
        {
            modulo = new Modulo();
        }


    }
    public enum OpcionEnum
    {
        Inactivo = 0,
        Activo = 1
    }
}
