using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entidad; // 👈 Importamos la entidad EProveedor

namespace Datos
{
    // Esta clase representa la base de datos de proveedores.
    public class ProveedoresBD
    {
        private Conexion conexionBD = new Conexion(); // 👈 Instanciá de la conexión a la base de datos


        // Método para insertar un nuevo proveedor en la base de datos
        public bool Insertar(EProveedor proveedor)
        {
            try
            {
                using (SqlConnection con = conexionBD.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Proveedor 
                (Nombre, PaisId, Telefono, Email, SitioWeb, FechaRegistro, Estado) 
                VALUES 
                (@Nombre, @PaisId, @Telefono, @Email, @SitioWeb, @FechaRegistro, @Estado)", con);

                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@PaisId", proveedor.PaisId);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                    cmd.Parameters.AddWithValue("@SitioWeb", proveedor.SitioWeb);
                    cmd.Parameters.AddWithValue("@FechaRegistro", proveedor.FechaRegistro);
                    cmd.Parameters.AddWithValue("@Estado", proveedor.Estado);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar proveedor en la base de datos: " + ex.Message);
            }
        }
        public bool ExisteProveedor(string nombre)
        {
            using (SqlConnection con = conexionBD.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Proveedor WHERE Nombre = @Nombre", con);
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                int cantidad = (int)cmd.ExecuteScalar();
                return cantidad > 0;
            }
        }


        // Método para obtener todos los proveedores de la base de datos
        public List<EProveedor> ObtenerTodos()
        {
            List<EProveedor> proveedores = new List<EProveedor>();

            using (SqlConnection con = conexionBD.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Proveedor WHERE Estado = 1", con); // 🔍 Solo activos
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EProveedor proveedor = new EProveedor(
                        reader.GetInt32(0),         // Id
                        reader.GetString(1),        // Nombre
                        reader.GetInt32(2),         // PaisId
                        reader.GetString(3),        // Telefono
                        reader.GetString(4),        // Email
                        reader.GetString(5),        // SitioWeb
                        reader.GetDateTime(6),      // FechaRegistro
                        reader.GetBoolean(7)        // Estado
                    );

                    proveedores.Add(proveedor);
                }
            }

            return proveedores;
        }

        public EProveedor ObtenerPorId(int id)
        {
            using (SqlConnection con = conexionBD.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Proveedor WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new EProveedor(
                        reader.GetInt32(0), // Id
                        reader.GetString(1), // Nombre
                        reader.GetInt32(2), // PaisId
                        reader.GetString(3), // Telefono
                        reader.GetString(4), // Email
                        reader.GetString(5), // SitioWeb
                        reader.GetDateTime(6), // FechaRegistro
                        reader.GetBoolean(7)  // Estado
                    );
                }

                return null; // No encontrado
            }
        }



        // Método para actualizar un proveedor existente en la base de datos
        public bool Actualizar(EProveedor proveedor)
        {
            try
            {
                // Asegurate de que la conexión esté abierta antes de ejecutar el comando
                using (SqlConnection con = conexionBD.ObtenerConexion())
                {
                    // Preparamos el comando SQL para actualizar el proveedor
                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE Proveedor SET
                    Nombre = @Nombre,
                    PaisId = @PaisId,
                    Telefono = @Telefono,
                    Email = @Email,
                    SitioWeb = @SitioWeb,
                    FechaRegistro = @FechaRegistro,
                    Estado = @Estado
                  WHERE Id = @Id", con);

                    // Asignamos los parámetros del comando con los valores del proveedor
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@PaisId", proveedor.PaisId);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                    cmd.Parameters.AddWithValue("@SitioWeb", proveedor.SitioWeb);
                    cmd.Parameters.AddWithValue("@FechaRegistro", proveedor.FechaRegistro);
                    cmd.Parameters.AddWithValue("@Estado", proveedor.Estado);
                    cmd.Parameters.AddWithValue("@Id", proveedor.Id);

                    return cmd.ExecuteNonQuery() > 0; // Retorna true si se actualizó al menos un registro
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar proveedor: " + ex.Message);
            }
        }


        // Método para eliminar un proveedor de la base de datos
        public bool Eliminar(int id)
        {
            try
            {
                using (SqlConnection con = conexionBD.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Proveedor SET Estado = 0 WHERE Id = @Id", con);

                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar proveedor: " + ex.Message);
            }
        }



    }
}
