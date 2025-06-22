using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidad
{
    public class ECliente
    {
        // Atributos de la clase ECliente
        public int Id { get; set; } // Identificador único del cliente
        public string Nombres { get; set; } // Nombre del cliente
        public string Apellidos { get; set; } // Apellido del cliente
        public string Telefono { get; set; } // Número de teléfono del cliente
        public string Direccion { get; set; } // Dirección del cliente
        public string Correo { get; set; } // Correo electrónico del cliente
        public DateTime FechaRegistro { get; set; } // Fecha de registro del cliente
        public bool Estado { get; set; } // Estado del cliente (activo/inactivo)

        // Constructor por defecto de la clase ECliente

        public ECliente(int id, string nombres, string apellidos, string telefono, string direccion, string correo, DateTime fecharegistro, bool estado)
        {
            Id = id; 
            Nombres = nombres;
            Apellidos = apellidos; 
            Telefono = telefono;
            Direccion = direccion; 
            Correo = correo;
            FechaRegistro = fecharegistro; 
            Estado = estado;

        }
        public ECliente() { } // Este constructor es obligatorio para evitar CS7036

    }
}
