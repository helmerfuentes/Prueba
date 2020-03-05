using Dato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio
{
   public  class LogicaPermiso
    {
        DatoPermiso datoPermiso = new DatoPermiso();

        public List<Permiso> ObtenerListaPermisos(long idRol)
        {
            return datoPermiso.ObtenerListaPermiso(idRol);
        }

        public bool Denegar(long rol, long opcion)
        {
            return datoPermiso.Denegar(rol, opcion);
        }


    }
}
