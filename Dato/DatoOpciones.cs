using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dato
{
   public class DatoOpciones:Conexion
    {
        DatoModulos DatoModulos;
        public Opcion Agregar(Opcion opcion)
        {
            try
            {
                Sql = "INSERT INTO OPCION(nombre,descripcion,estado,idModulo) VALUES(@nombre,@descripcion,@estado,@modulo) SELECT @@IDENTITY AS Id ;";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@nombre", opcion.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", opcion.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", OpcionEnum.Activo);
                    cmd.Parameters.AddWithValue("@modulo",opcion.modulo.Id);
                    var reader = cmd.ExecuteReader();
                    reader.Read();

                    opcion.Id = long.Parse(reader[0].ToString());
                    Console.WriteLine("id generado " + opcion.Id);
                    return opcion;
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

        public List<Opcion> ListarPorModulo(long id)
        {
            try
            {
                List<Opcion> ListaOpciones = null;
                Sql = "SELECT *FROM OPCION WHERE ESTADO=@estado AND idModulo=@idModulo;";

                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@estado", OpcionEnum.Activo);
                    cmd.Parameters.AddWithValue("@idModulo", id);
                    using (var dr = cmd.ExecuteReader())
                    {
                        ListaOpciones = new List<Opcion>();
                        while (dr.Read())
                        {

                            var opcion = new Opcion
                            {
                                Id = long.Parse(dr["id"].ToString()),
                                Nombre = dr["nombre"].ToString(),
                                Descripcion = dr["descripcion"].ToString(),
                                Estado = (OpcionEnum)Convert.ToInt32(dr["estado"])
                            };

                            ListaOpciones.Add(opcion);
                        }
                        return ListaOpciones;
                    }
                }
                return ListaOpciones;
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
                Sql = "DELETE FROM OPCION WHERE id=@id; ";
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

        public Opcion Buscar(long id)
        {

            try
            {
                Sql = "SELECT *FROM OPCION WHERE id=@id;";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var dr = cmd.ExecuteReader())
                    {

                        dr.Read();
                        if (dr.HasRows)
                        {
                            var opcion  = new Opcion
                            {
                                Id = long.Parse(dr["id"].ToString()),
                                Nombre = dr["nombre"].ToString(),
                                Descripcion = dr["descripcion"].ToString(),
                                Estado = (OpcionEnum)Convert.ToInt32(dr["estado"])
                            };

                            return opcion;
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

        public Opcion Actualizar(Opcion opcion)
        {
            try
            {
                Sql = "UPDATE OPCION SET nombre=@nombre,descripcion=@descripcion,estado=@estado WHERE id=@id;";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@nombre", opcion.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", opcion.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", opcion.Estado);
                    cmd.Parameters.AddWithValue("@id", opcion.Id);
                    cmd.ExecuteReader();

                    return opcion;
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
        public List<Opcion> Listar()
        {
            try
            {
                List<Opcion> ListaOpciones= null;
                Sql = "SELECT *FROM MODULO WHERE ESTADO=@estado;";

                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@estado", ModulosEnum.Activo);
                    using (var dr = cmd.ExecuteReader())
                    {
                        ListaOpciones = new List<Opcion>();
                        while (dr.Read())
                        {

                            var opcion = new Opcion
                            {
                                Id = long.Parse(dr["id"].ToString()),
                                Nombre = dr["nombre"].ToString(),
                                Descripcion = dr["descripcion"].ToString(),
                                Estado = (OpcionEnum)Convert.ToInt32(dr["estado"])
                            };

                            ListaOpciones.Add(opcion);
                        }
                        return ListaOpciones;
                    }
                }
                return ListaOpciones;
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
