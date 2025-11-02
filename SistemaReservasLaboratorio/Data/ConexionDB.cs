using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SistemaReservasLaboratorio.Data
{
    public class ConexionBD
    {
        private static string cadenaConexion;

        static ConexionBD()
        {
            // Leer la cadena de conexión desde App.config
            cadenaConexion = ConfigurationManager.ConnectionStrings["SistemaReservas"]?.ConnectionString;

            if (string.IsNullOrEmpty(cadenaConexion))
            {
                throw new Exception("No se encontró la cadena de conexión 'SistemaReservas' en App.config");
            }
        }

        public static SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al conectar con la base de datos: {ex.Message}", ex);
            }
        }

        public static void CerrarConexion(SqlConnection conexion)
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    return conexion.State == System.Data.ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}