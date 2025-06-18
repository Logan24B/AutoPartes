using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EPais
    {
        public int Id { get; set; } // Identificador único del país
        public string Nombre { get; set; } // Nombre del país
        
        // Constructor con parámetros para inicializar las propiedades
        public EPais(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
           
        }
    }
}
