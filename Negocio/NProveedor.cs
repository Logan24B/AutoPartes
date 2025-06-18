using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad; // Importamos la entidad EProveedor
using Datos; // Importamos la capa de datos para acceder a la base de datos

namespace Negocio
{
    public class NProveedor
    {
        // Aquí puedes implementar la lógica de negocio relacionada con los proveedores.
        // Por ejemplo, podrías tener métodos para agregar, actualizar, eliminar o buscar proveedores.
        // Ejemplo de método para agregar un proveedor
        public void AgregarProveedor(Entidad.EProveedor proveedor)
        {
            Datos.ProveedoresBD proveedoresBD = new Datos.ProveedoresBD();
            proveedoresBD.Insertar(proveedor);
        }
        // Ejemplo de método para obtener todos los proveedores
        public List<Entidad.EProveedor> ObtenerProveedores()
        {
            try // Intentamos obtener la lista de proveedores
            {
                Datos.ProveedoresBD proveedoresBD = new Datos.ProveedoresBD(); // Creamos una instancia de la clase ProveedoresBD para acceder a los datos
                return proveedoresBD.ObtenerTodos(); // Llamamos al método ObtenerTodos para obtener la lista de proveedores
            }
            catch (Exception ex) // Capturamos cualquier excepción que pueda ocurrir al obtener los proveedores
            {
                // Manejo de excepciones para capturar errores al obtener proveedores
                throw new Exception("Error al obtener proveedores.: " + ex.Message);
            }
        }

        // Ejemplo de método para buscar un proveedor por ID
        public EProveedor BuscarProveedorPorId(int id)
        {
            return new ProveedoresBD().ObtenerPorId(id);
        }
        // método para insertar un proveedor
        public bool InsertarProveedor(EProveedor proveedor) // Método para insertar un proveedor en la base de datos
        {
            return new ProveedoresBD().Insertar(proveedor); // Llamamos al método Insertar de la clase ProveedoresBD para insertar el proveedor
        }
        // Método para verificar si un proveedor ya existe por nombre
        public bool ProveedorYaExiste(string nombre)
        {
            return new ProveedoresBD().ExisteProveedor(nombre);
        }
        // Método para actualizar un proveedor
        public bool ActualizarProveedor(EProveedor proveedor)
        {
            return new ProveedoresBD().Actualizar(proveedor);
        }
        // Método para eliminar un proveedor por ID
        public bool EliminarProveedor(int id)
        {
            return new ProveedoresBD().Eliminar(id);
        }




    }



}
