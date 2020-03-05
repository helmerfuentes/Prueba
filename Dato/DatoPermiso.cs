using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dato
{
   public class DatoPermiso: Conexion
    {

        public List<Permiso> ObtenerListaPermiso(long idRol)
        {
            try
            {
                List<Permiso> getPermisos = null;
                Sql = @"SELECT        dbo.opcion.nombre, dbo.opcion.descripcion, dbo.[rol-opciones].idRol, dbo.modulo.nombre AS modulo, dbo.opcion.id
                        FROM            dbo.opcion FULL OUTER JOIN
                         dbo.[rol-opciones] ON dbo.opcion.id = dbo.[rol-opciones].idOpcion INNER JOIN
                         dbo.modulo ON dbo.opcion.idModulo = dbo.modulo.id";
                if (conectar(Sql))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        getPermisos = new List<Permiso>();
                        Permiso per;
                        while (dr.Read())
                        {
                            // Usuario
                            per = new Permiso();
                            per.Rol.Id = idRol;
                            per.Modulo = dr["modulo"].ToString();
                            per.Opcion.Nombre = dr["nombre"].ToString();
                            per.Opcion.Descripcion = dr["modulo"].ToString();
                            per.Opcion.Id = Convert.ToInt32(dr["id"]);
                            if (dr["idRol"] is DBNull)
                            {
                                per.Permitido = EnumPermiso.NoPermitido;
                            }
                            else
                            {

                                per.Permitido = (Convert.ToInt32(dr["idRol"]) == idRol) ? EnumPermiso.Permitido : EnumPermiso.NoPermitido;
                            }



                            // Agregamos el usuario a la lista genreica
                            getPermisos.Add(per);
                        }

                    }
                }
                return getPermisos;
            }
            catch (Exception e)
            {
                Console.WriteLine("error mensaje " + e.Message);
                return null;

            }
            finally
            {
                desConectar();
            }
        }
        
        public bool Denegar(long idrol, long idOpcion)
        {
            try
            {
                bool respuesta = false;
                Sql = "DELETE FROM [ROL-OPCIONES] WHERE idRol=@rol AND idOpcion=@opcion";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@rol", idrol);
                    cmd.Parameters.AddWithValue("@opcion", idOpcion);
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                    return respuesta;
                }
                return respuesta;
            }
            catch (Exception e)
            {
                Console.WriteLine("error mensaje " + e.Message);
                return false;

            }
            finally
            {
                desConectar();
            }
        }

    }

}
