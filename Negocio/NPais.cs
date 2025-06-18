using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos; // Importamos la capa de datos para acceder a la base de datos


namespace Negocio
{
    public class NPais
    {
        private Datos.PaisBD paisBD = new Datos.PaisBD(); // Instancia de la clase PaisBD para acceder a la base de datos
        // Método para insertar un nuevo país
        public void Insertar(Entidad.EPais pais)
        {
            paisBD.Insertar(pais); // Llamamos al método Insertar de PaisBD
        }
        // Método para obtener todos los países
        public List<Entidad.EPais> ObtenerTodos()
        {
            return paisBD.ObtenerTodos(); // Llamamos al método ObtenerTodos de PaisBD y retornamos la lista de países
        }
    }
}
