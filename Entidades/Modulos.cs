using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Modulos
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public List<Opciones> Opciones { get; set; }

        public Modulos()
        {
            Opciones = new List<Opciones>();
        }
    }
}
