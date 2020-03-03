using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Modulo
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ModulosEnum Estado { get; set; }
        public List<Opcion> Opciones { get; set; }

        public Modulo()
        {
            Opciones = new List<Opcion>();
        }
    }

    public enum ModulosEnum
    {
        Inactivo = 0,
        Activo = 1
    }
}
