using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        // Cadena de conexión, usaremos la autenticación de windows
        private readonly string CadenaConexion = "Server=DESKTOP-M27HGA0\\SQLEXPRESS;Database=AutoPartes;Trusted_Connection=True;";

        /// <summary>
        /// Obtiene una conexión abierta a la base de datos.
        /// </summary>

        // Metodo para obtener una conexión abierta
        public SqlConnection ObtenerConexion()
        {
            // Creamos una nueva instancia de SqlConnection con la cadena de conexión
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            // Intentamos abrir la conexión y manejamos posibles excepciones con un bloque try-catch
            try
            {
                conexion.Open(); // Abrimos la conexión a la base de datos
            }
            catch (Exception ex) // Capturamos cualquier excepción que ocurra al intentar abrir la conexión
            {
                // Manejo de excepciones, podrías registrar el error o lanzar una excepción personalizada
                throw new Exception("Error al abrir la conexión a la base de datos.", ex);
            }
            return conexion; // Retornamos la conexión abierta
        }

        /// <summary>
        /// Cierra la conexión si está abierta.
        /// </summary>
        // Este metodo realmente no es utilizado en la capa de negocio, pero es una buena práctica tenerlo
        public void CerrarConexion(SqlConnection conexion)
        {
            // Verificamos si la conexión está abierta antes de intentar cerrarla
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    conexion.Close(); // Cerramos la conexión a la base de datos
                }
                catch (Exception ex) // Capturamos cualquier excepción que ocurra al intentar cerrar la conexión
                {
                    // Manejo de excepciones, podrías registrar el error o lanzar una excepción personalizada
                    throw new Exception("Error al cerrar la conexión a la base de datos.", ex);
                }
            }
        }
    }
}
