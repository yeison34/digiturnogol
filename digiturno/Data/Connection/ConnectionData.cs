using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace digiturno.Data.Connection
{
    public class ConnectionData
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static NpgsqlConnection ConnectionSystem()
        {
            NpgsqlConnection conexion = null;
            try
            {
                conexion = new NpgsqlConnection(connectionString);
                conexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo conectar");
            }

            return conexion;
        }

       
    }
}