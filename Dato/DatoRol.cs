using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dato
{
    public class DatoRol : Conexion
    {

        DatoModulos DatoModulos;

        public Rol Agregar(Rol rol)
        {
            try
            {
                    Sql = "INSERT INTO ROL(nombre,descripcion,estado) VALUES(@nombre,@descripcion,@estado) SELECT @@IDENTITY AS Id ;";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@nombre", rol.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", rol.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", RolEstado.Activo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    rol.Id = long.Parse(reader[0].ToString());
                    Console.WriteLine("id generado " + rol.Id);
                    return rol;
                }
                return rol;
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

        public bool BuscarPermiso(string rol, int permiso)
        {
            if (rol == "Admnistrador")
                return true;
            else
                return false;
        }

        public Rol Obtener(long id)
        {
            Rol rol = null;
            try
            {
                Sql = "SELECT *FROM ROL WHERE id=@id;";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var dr = cmd.ExecuteReader())
                    {
                        rol = new Rol();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            DatoModulos = new DatoModulos();
                            rol.Id = Convert.ToInt32(dr["id"]);
                            rol.Nombre = dr["Nombre"].ToString();
                            rol.Estado = (RolEstado)Convert.ToInt32(dr["estado"]);
                            rol.ListaModulos = DatoModulos.BuscarModuloPorRol(rol.Id);
                           
                        }

                    }


                    return rol;
                }
                return null;
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



        public bool Eliminar(long id)
        {
            try
            {
                bool respuesta = false;
                Sql = "DELETE FROM ROL WHERE id=@id; ";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@id", id);
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

        public Rol Actualizar(Rol rol)
        {
            try
            {
                Sql = "UPDATE ROL SET nombre=@nombre,descripcion=@descripcion,estado=@estado WHERE id=@id;";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@nombre", rol.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", rol.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", rol.Estado);
                    cmd.Parameters.AddWithValue("@id", rol.Id);
                    cmd.ExecuteReader();

                    return rol;
                }
                return null;
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

        public List<Rol> Listar()
        {
            try
            {
                List<Rol> rols = null;
                Sql = "SELECT *FROM ROL;";
                if (conectar(Sql))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        rols = new List<Rol>();
                        while (dr.Read())
                        {
                            // Usuario
                            var rol = new Rol
                            {
                                Id = long.Parse(dr["id"].ToString()),
                                Nombre = dr["nombre"].ToString(),
                                Descripcion = dr["descripcion"].ToString(),
                                Estado = (RolEstado)Convert.ToInt32(dr["estado"])
                            };

                            // Agregamos el usuario a la lista genreica
                            rols.Add(rol);
                        }
                        return rols;
                    }
                }
                return rols;
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
    }
}
