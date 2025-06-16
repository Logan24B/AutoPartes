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
        public void Insertar(EProveedor proveedor)
        {
            using (SqlConnection con = conexionBD.ObtenerConexion()) // 👈 Obtenemos la conexión a la base de datos
            {
                // Creamos el comando SQL para insertar un nuevo proveedor
                SqlCommand cmd = new SqlCommand("INSERT INTO Proveedores (Nombre, PaisId, Telefono, Email, SitioWeb, FechaRegistro, Estado) VALUES (@Nombre, @PaisId, @Telefono, @Email, @SitioWeb, @FechaRegistro, @Estado)", con);

                // Asignamos los parámetros del comando con los valores del proveedor
                cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@PaisId", proveedor.PaisId);
                cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                cmd.Parameters.AddWithValue("@SitioWeb", proveedor.SitioWeb);
                cmd.Parameters.AddWithValue("@FechaRegistro", proveedor.FechaRegistro);
                cmd.Parameters.AddWithValue("@Estado", proveedor.Estado);
                // Ejecutamos el comando
                cmd.ExecuteNonQuery();
            }

        }

        // Método para actualizar un proveedor existente en la base de datos
        public void Actualizar(EProveedor proveedor)
        {
            using (SqlConnection con = conexionBD.ObtenerConexion()) // 👈 Obtenemos la conexión a la base de datos
            {
                // Creamos el comando SQL para actualizar un proveedor existente
                SqlCommand cmd = new SqlCommand("UPDATE Proveedores SET Nombre = @Nombre, PaisId = @PaisId, Telefono = @Telefono, Email = @Email, SitioWeb = @SitioWeb, FechaRegistro = @FechaRegistro, Estado = @Estado WHERE IdProveedor = @IdProveedor", con);

                // Asignamos los parámetros del comando con los valores del proveedor
                cmd.Parameters.AddWithValue("@IdProveedor", proveedor.Id);
                cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@PaisId", proveedor.PaisId);
                cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                cmd.Parameters.AddWithValue("@SitioWeb", proveedor.SitioWeb);
                cmd.Parameters.AddWithValue("@FechaRegistro", proveedor.FechaRegistro);
                cmd.Parameters.AddWithValue("@Estado", proveedor.Estado);

                // Ejecutamos el comando
                cmd.ExecuteNonQuery();
            }


        }

        // Método para eliminar un proveedor de la base de datos
        public void Eliminar(int Id)
        {
            using (SqlConnection con = conexionBD.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Proveedores SET Estado = 0 WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }
        }


    }
}
