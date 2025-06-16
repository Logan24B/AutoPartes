using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EProveedor
    {
        // Propiedades de la clase Eproveedor
        public int Id { get; set; } // Identificador único del proveedor
        public string Nombre { get; set; } // Nombre del proveedor
        public int PaisId { get; set; } // Identificador del país del proveedor
        public string Telefono { get; set; } // Número de teléfono del proveedor
        public string Email { get; set; } // Correo electrónico del proveedor
        public string SitioWeb { get; set; } // Sitio web del proveedor
        public DateTime FechaRegistro { get; set; } // Fecha de registro del proveedor
        public bool Estado { get; set; } // Estado del proveedor (activo, inactivo)
            
    
        // metodo constructor de la clase Eproveedor
        public EProveedor(int id, string nombre, int paisId, string telefono, string email, string sitioWeb, DateTime fechaRegistro, bool estado)
        {
            // Asignación de valores a las propiedades de la clase Eproveedor
            // Este constructor inicializa un nuevo objeto Eproveedor con los valores proporcionados.
            Id = id; 
            Nombre = nombre; 
            PaisId = paisId;
            Telefono = telefono;
            Email = email;
            SitioWeb = sitioWeb;
            FechaRegistro = fechaRegistro;
            Estado = estado;
        }






    }
}
