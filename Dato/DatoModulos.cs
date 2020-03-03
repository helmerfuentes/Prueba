using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dato
{
    public class DatoModulos : Conexion
    {
        DatoOpciones opciones;

        public Modulo Agregar(Modulo modulo)
        {
            try
            {
                Sql = "INSERT INTO MODULO(nombre,descripcion,estado) VALUES(@nombre,@descripcion,@estado) SELECT @@IDENTITY AS Id ;";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@nombre", modulo.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", modulo.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", ModulosEnum.Activo);
                    var reader = cmd.ExecuteReader();
                    reader.Read();

                    modulo.Id = long.Parse(reader[0].ToString());
                    Console.WriteLine("id generado " + modulo.Id);
                    return modulo;
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
                Sql = "DELETE FROM MODULO WHERE id=@id; ";
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

        public Modulo Buscar(long id)
        {

            try
            {
                Sql = "SELECT *MODULO WHERE id=@id;";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var dr = cmd.ExecuteReader())
                    {

                        dr.Read();
                        if (dr.HasRows)
                        {
                            var modulo = new Modulo
                            {
                                Id = long.Parse(dr["id"].ToString()),
                                Nombre = dr["nombre"].ToString(),
                                Descripcion = dr["descripcion"].ToString(),
                                Estado = (ModulosEnum)Convert.ToInt32(dr["estado"])
                            };
                            opciones = new DatoOpciones();
                            modulo.Opciones = opciones.ListarPorModulo(modulo.Id);
                            return modulo;
                        }

                    }




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

        public List<Modulo> BuscarModuloPorRol(long id)
        {
            List<Modulo> ListaModulo = null;
            try
            {
                Sql = @"SELECT dbo.modulo.nombre, dbo.modulo.id
                         FROM      dbo.modulo INNER JOIN
                         dbo.opcion ON dbo.modulo.id = dbo.opcion.idModulo INNER JOIN
                         dbo.rol ON dbo.modulo.id = dbo.rol.id INNER JOIN
                         dbo.[rol-opciones] ON dbo.opcion.id = dbo.[rol-opciones].idOpcion AND dbo.rol.id = dbo.[rol-opciones].idRol
						 where dbo.modulo.estado=@estado;";


                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@estado", ModulosEnum.Activo);
                    using (var dr = cmd.ExecuteReader())
                    {
                        ListaModulo = new List<Modulo>();
                        while (dr.Read())
                        {

                            var modulo = new Modulo
                            {
                                Id = long.Parse(dr["id"].ToString()),
                                Nombre = dr["nombre"].ToString(),
                              
                            };

                            ListaModulo.Add(modulo);
                        }

                    }

                    //Agregamos las Opciones de los modulos
                    opciones = new DatoOpciones();
                    foreach (Modulo item in ListaModulo)
                    {
                        item.Opciones = opciones.ListarPorModulo(item.Id);
                    }

                }
                return ListaModulo;
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

        public Modulo Actualizar(Modulo modulo)
        {
            try
            {
                Sql = "UPDATE MODULO SET nombre=@nombre,descripcion=@descripcion,estado=@estado WHERE id=@id;";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@nombre", modulo.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", modulo.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", ModulosEnum.Activo);
                    cmd.Parameters.AddWithValue("@id", modulo.Id);
                    cmd.ExecuteReader();

                    return modulo;
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
        public List<Modulo> Listar()
        {

            try
            {
                List<Modulo> ListaModulo = null;
                Sql = "SELECT *FROM MODULO WHERE ESTADO=@estado;";

                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@estado", ModulosEnum.Activo);
                    using (var dr = cmd.ExecuteReader())
                    {
                        ListaModulo = new List<Modulo>();
                        while (dr.Read())
                        {

                            var modulo = new Modulo
                            {
                                Id = long.Parse(dr["id"].ToString()),
                                Nombre = dr["nombre"].ToString(),
                                Descripcion = dr["descripcion"].ToString(),
                                Estado = (ModulosEnum)Convert.ToInt32(dr["estado"])
                            };

                            ListaModulo.Add(modulo);
                        }

                    }

                    //Agregamos las Opciones de los modulos
                    opciones = new DatoOpciones();
                    foreach (Modulo item in ListaModulo)
                    {
                        item.Opciones = opciones.ListarPorModulo(item.Id);
                    }

                }
                return ListaModulo;
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
