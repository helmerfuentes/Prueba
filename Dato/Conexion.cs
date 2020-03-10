using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Dato
{
   public class Conexion
    {
        public SqlConnection connection;
        public string Sql;
        private const string servidor = "sql5052.site4now.net";
        private const string puerto = "3306";
        private const string usuario = "DB_A5622D_prueba_admin";
        private const string password = "diosesamor123";
        private const string database = "DB_A5622D_prueba";

        public SqlCommand cmd;

                //conexion Local
        public string connectionString = string.Format("Data Source = {0}; Initial Catalog = {1}; user id={2}; password={3}",servidor,database,usuario,password);
      
                //conexion Remota
        // public string connectionString = string.Format("data source = {0}; initial catalog = {1}; user id = {2}; password = {3}", servidor, database,usuario,password);



        public bool conectar(string sql)
        {
            try
            {

                connection = new SqlConnection(connectionString);
                connection.Open();
                cmd = new SqlCommand(sql,connection);
              
                return true;
            }
            catch (Exception)
            {
             
                return false;

            }
        }

        public bool desConectar()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        //public long ObtenerUltimoId()
        //{
        //    Sql = "SELECT SCOPE_IDENTITY()";
        //    try
        //    {
        //        cmd = new SqlCommand(Sql, connection);





        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
