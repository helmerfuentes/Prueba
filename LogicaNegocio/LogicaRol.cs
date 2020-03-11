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
            return rol;// DatoRol.Agregar(rol);
        }

        public List<Rol> Listar()
        {

            return DatoRol.Listar();
        }

        public Rol Actualizar(Rol rol)
        {
            return  DatoRol.Actualizar(rol);
        }

        public bool Eliminar(long id)
        {
            if (DatoRol.RolConUsuario(id) > 0)
            {
                return false;
            }
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
        #region Rol
        Registrar_Rol = 1,
        Listar_Rol=2,
        Actualizar_Rol=5,
        Eliminar_rol=4,
        #endregion

        #region Usuario
        registrar_usuario=6,
        listar_Usuario=7
        #endregion
        //#region Alumnos
        //Alumno_Puede_Crear_Nuevo_Registro = 2,
        //Alumno_Puede_Eliminar_Registro = 3,
        //Alumno_Puede_Visualizar_Un_Alumno = 4,
        //#endregion

    }
}
