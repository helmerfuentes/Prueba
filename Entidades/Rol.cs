using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
   public class Rol
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public RolEstado Estado { get; set; }
        public List<Opciones> ListaOpciones { get; set; }

        public Rol()
        {
            ListaOpciones = new List<Opciones>();
        }
    }

    public enum RolEstado
    {
        Inactivo = 0,
        Activo = 1
    }
}
