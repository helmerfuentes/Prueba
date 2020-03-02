using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
   public class Opciones
    {
        public long Id { get; set; }
        public string  Nombre { get; set; }
        public string Descripcion { get; set; }

        public Modulos modulo { get; set; }
        public Opciones()
        {
            modulo = new Modulos();
        }


    }
}
