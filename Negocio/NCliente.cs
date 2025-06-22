using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos; // Importamos la capa de datos para acceder a la base de datos


namespace Negocio
{
    public class NCliente
    {
        // Método para insertar un cliente (ya incluye validación interna)
        public bool InsertarCliente(Entidad.ECliente cliente)
        {
            Datos.ClienteBD clienteBD = new Datos.ClienteBD();

            if (clienteBD.ExisteCliente(cliente.Nombres, cliente.Apellidos, cliente.Correo))
            {
                // Ya existe, no se inserta
                return false;
            }

            return clienteBD.Insertar(cliente);
        }

        // Método para verificar si un cliente ya existe por nombre, apellido y correo
        public bool ClienteYaExiste(string nombres, string apellidos, string correo)
        {
            return new Datos.ClienteBD().ExisteCliente(nombres, apellidos, correo);
        }

        // Método para obtener todos los clientes
        public List<Entidad.ECliente> ObtenerClientes()
        {
            try
            {
                Datos.ClienteBD clienteBD = new Datos.ClienteBD();
                return clienteBD.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message);
            }
        }

        // Método para buscar un cliente por ID
        public Entidad.ECliente BuscarClientePorId(int id)
        {
            return new Datos.ClienteBD().ObtenerPorId(id);
        }

        // Método para actualizar un cliente
        public bool ActualizarCliente(Entidad.ECliente cliente)
        {
            return new Datos.ClienteBD().Actualizar(cliente);
        }

        // Método para eliminar un cliente por ID (cambia estado a inactivo)
        public bool EliminarCliente(int id)
        {
            return new Datos.ClienteBD().Eliminar(id);
        }
    }
}
