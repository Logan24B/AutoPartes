using Entidad; // Importamos la entidad ECliente
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteBD
    {
        private Conexion conexionBD = new Conexion(); // Instancia de la conexión a la base de datos

        // Método para insertar un nuevo cliente en la base de datos
        public bool Insertar(Entidad.ECliente cliente)
        {
            try
            {
                using (SqlConnection con = conexionBD.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Cliente 
                            (Nombres, Apellidos, Telefono, Direccion, Correo, FechaRegistro, Estado) 
                            VALUES 
                            (@Nombres, @Apellidos, @Telefono, @Direccion, @Correo, @FechaRegistro, @Estado)", con);
                        cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                        cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                        cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        cmd.Parameters.AddWithValue("@Correo", cliente.Correo);
                        cmd.Parameters.AddWithValue("@FechaRegistro", cliente.FechaRegistro);
                        cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cliente en la base de datos: " + ex.Message);
            }
        }

        // Método para verificar si un cliente ya existe en la base de datos por su nombre
        public bool ExisteCliente(string nombres, string apellidos, string correo)
        {
            using (SqlConnection con = conexionBD.ObtenerConexion())
            {
                string consulta = @"
                SELECT COUNT(*) 
                FROM Cliente 
                WHERE Nombres = @Nombres 
                  AND Apellidos = @Apellidos 
                  AND Correo = @Correo";

                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@Nombres", nombres);
                cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                cmd.Parameters.AddWithValue("@Correo", correo);

                int cantidad = (int)cmd.ExecuteScalar();
                return cantidad > 0;
            }
        }


        // Ajuste en el método ObtenerTodos para incluir el parámetro requerido "id" al crear un objeto ECliente
        public List<ECliente> ObtenerTodos()
        {
            List<ECliente> clientes = new List<ECliente>();
            using (SqlConnection con = conexionBD.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente c where c.Estado = 1", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Se ajusta la creación del objeto ECliente para incluir el parámetro requerido "id"
                    ECliente cliente = new ECliente
                    {
                        Id = reader.GetInt32(0), // Se asigna el valor de la columna "Id"
                        Nombres = reader.GetString(1),
                        Apellidos = reader.GetString(2), // Se incluye Apellidos
                        Telefono = reader.GetString(3),
                        Direccion = reader.GetString(4),
                        Correo = reader.GetString(5),
                        FechaRegistro = reader.GetDateTime(6),
                        Estado = reader.GetBoolean(7)
                    };
                    clientes.Add(cliente);
                }
            }
            return clientes; // Retorna la lista de clientes
        }

        // Método para actualizar un cliente existente en la base de datos
        public bool Actualizar(ECliente cliente)
        {
            try
            {
                using (SqlConnection con = conexionBD.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE Cliente 
                            SET Nombres = @Nombres, 
                                Apellidos = @Apellidos, 
                                Telefono = @Telefono, 
                                Correo = @Correo, 
                                Direccion = @Direccion, 
                                FechaRegistro = @FechaRegistro, 
                                Estado = @Estado 
                            WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Id", cliente.Id);
                    cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", cliente.Correo);
                    cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@FechaRegistro", cliente.FechaRegistro);
                    cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cliente en la base de datos: " + ex.Message);
            }



        }


        // Método para eliminar un cliente de la base de datos (cambiar estado a inactivo)
        public bool Eliminar(int id)
        {
            try
            {
                using (SqlConnection con = conexionBD.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Cliente SET Estado = 0 WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente en la base de datos: " + ex.Message);
            }
        }
        // Método para buscar un cliente por su ID
        public ECliente ObtenerPorId(int id)
        {
            using (SqlConnection con = conexionBD.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new ECliente
                    {
                        Id = reader.GetInt32(0),
                        Nombres = reader.GetString(1),
                        Apellidos = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        Correo = reader.GetString(4),
                        Direccion = reader.GetString(5),
                        FechaRegistro = reader.GetDateTime(6),
                        Estado = reader.GetBoolean(7)
                    };
                }
                return null; // Retorna null si no se encuentra el cliente
            }
        }

    }
}
