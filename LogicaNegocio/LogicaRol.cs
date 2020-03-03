using Dato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio
{
    public class LogicaRol
    {
        DatoRol DatoRol = new DatoRol();

        public Rol Agregar(Rol rol)
        {
            return null;/* DatoRol.Agregar(rol)*/
        }

        public List<Rol> Listar()
        {

            return DatoRol.Listar();
        }

        public Rol Actualizar(Rol rol)
        {
            return DatoRol.Actualizar(rol);
        }

        public bool Eliminar(long id)
        {
            return DatoRol.Eliminar(id);
        }
        public Rol Obtener(long id)
        {
            return DatoRol.Obtener(id);
        }
        public  bool TienePermiso(string rol, EnumRolesPermiso permiso)
        {
            return DatoRol.BuscarPermiso(rol,Convert.ToInt32(permiso));
        }
    }

    public enum EnumRolesPermiso
    {
            Registrar_usuario=0

      }
}
