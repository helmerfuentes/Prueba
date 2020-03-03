using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dato
{
    public class DatoUsuario:Conexion
    {
        DatoRol DatoRol;

        public Usuario Login(string user, string clave)
        {
            Usuario usuario=null;
            try
            {
                Sql = "SELECT *FROM USUARIO  WHERE usuario=@usuario and clave=@clave;";
                if (conectar(Sql))
                {
                    cmd.Parameters.AddWithValue("@usuario",user);
                    cmd.Parameters.AddWithValue("@clave", clave);


                    using (var dr = cmd.ExecuteReader())
                    {

                        dr.Read();
                        if (dr.HasRows)
                        {

                            DatoRol = new DatoRol();
                            usuario = new Usuario();

                                usuario.Rol= DatoRol.Obtener(long.Parse(dr["idRol"].ToString()));
                                 usuario.Id = long.Parse(dr["id"].ToString());
                                usuario.Nombre = dr["nombre"].ToString();
                                usuario.Apellido = dr["apellido"].ToString();


                            return usuario;
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

        public List<Usuario> Listar()
        {
            return null;
        }



        public Usuario Buscarusuario(long id)
        {
            throw new NotImplementedException();
        }

        public Usuario Actualizar(long id)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public Usuario Agregar(Usuario usuario)
        {
            try
            {
                Sql = "INSERT INTO USUARIO(usuario,clave,nombre,apellido,estado,idRol) VALUES(@usuario,@clave,@nombre,@apellido,@estado,@rol) SELECT @@IDENTITY AS Id ;";
                if (conectar(Sql))
                {
                   
                    cmd.Parameters.AddWithValue("@usuario", usuario.usuario);
                    cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@estado", enumUsuarios.Activo);
                    cmd.Parameters.AddWithValue("@rol", usuario.Rol.Id);
                    var reader = cmd.ExecuteReader();
                    reader.Read();

                    usuario.Id = long.Parse(reader[0].ToString());
                    Console.WriteLine("id generado " + usuario.Id);
                    return usuario;
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
    }
}
