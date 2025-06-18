using Entidad; // Importamos la entidad EProveedor
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PaisBD
    {
        private Conexion conexionBD = new Conexion(); // Instancia de la conexión a la base de datos

        public void Insertar(EPais pais)
        {
            using (SqlConnection con = conexionBD.ObtenerConexion()) // Obtenemos la conexión a la base de datos
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Pais (Nombre) VALUES (@Nombre)", con);// Creamos el comando SQL para insertar un nuevo país
                // Asignamos los parámetros del comando con los valores del país
                cmd.Parameters.AddWithValue("@Nombre", pais.Nombre);// Asignamos el nombre del país al parámetro
                // Ejecutamos el comando
                cmd.ExecuteNonQuery();
            }
        }

        // Método para obtener todos los países de la base de datos
        public List<EPais> ObtenerTodos()
        {
            List<EPais> paises = new List<EPais>();
            using (SqlConnection con = conexionBD.ObtenerConexion()) // Obtenemos la conexión a la base de datos
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Pais", con); // Creamos el comando SQL para obtener todos los países
                SqlDataReader reader = cmd.ExecuteReader(); // Ejecutamos el comando y obtenemos un lector de datos
                while (reader.Read()) // Leemos los datos del lector
                {
                    EPais pais = new EPais(reader.GetInt32(0), reader.GetString(1)); // Creamos una instancia de EPais con los datos leídos
                    paises.Add(pais); // Agregamos el país a la lista
                }
            }
            return paises; // Retornamos la lista de países
        }




    }
}
