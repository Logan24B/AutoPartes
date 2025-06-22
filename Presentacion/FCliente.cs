using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio; // Importamos la capa de negocio para manejar la lógica de clientes
using Entidad; // Importamos la entidad ECliente para trabajar con los datos del cliente
using System.Drawing;
using System.Drawing.Printing;


namespace Presentacion
{
    public partial class FCliente : Form
    {

        private PrintDocument documento;
        private int filaActual;

        public FCliente()
        {
            // Inicializa los componentes del formulario
            InitializeComponent();
            CargarClientes(); // Llama al método para cargar los clientes al iniciar el formulario
            documento = new PrintDocument();
            /*documento.PrintPage += new PrintPageEventHandler(Documento_PrintPage);*/ // Asocia el evento PrintPage del documento a un manejador de eventos



        }

        private void CargarClientes()
        {
            try
            {
                // Crea una instancia de NCliente para acceder a la lógica de negocio de clientes
                NCliente nCliente = new NCliente();
                // Obtiene la lista de clientes y la asigna al DataGridView
                DtgCliente.DataSource = nCliente.ObtenerClientes();
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al cargar los clientes
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FCliente_Load(object sender, EventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            //1. Verifica si todos los campos del formulario están llenos
            if (string.IsNullOrWhiteSpace(TxtName.Text) || string.IsNullOrWhiteSpace(TxtLastName.Text) ||
                string.IsNullOrWhiteSpace(TxtPhoneNumber.Text) || string.IsNullOrWhiteSpace(TxtAdress.Text) ||
                string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                // Muestra un mensaje de error si algún campo está vacío
                MessageBox.Show("Por favor, complete todos los campos.");
                return; // Sale del método si hay campos vacíos
            }

            //2. Crea una nueva instancia de ECliente con los datos ingresados en los campos del formulario
            ECliente cliente = new ECliente
            {
                Nombres = TxtName.Text, // Asigna el nombre del cliente desde el campo de texto
                Apellidos = TxtLastName.Text, // Asigna los apellidos del cliente desde el campo de texto
                Telefono = TxtPhoneNumber.Text, // Asigna el teléfono del cliente desde el campo de texto
                Direccion = TxtAdress.Text, // Asigna la dirección del cliente desde el campo de texto
                Correo = TxtEmail.Text, // Asigna el correo electrónico del cliente desde el campo de texto
                FechaRegistro = DateTime.Now, // Asigna la fecha actual como fecha de registro del cliente
                Estado = true, // Asigna el estado del cliente como activo
            };

            // 3. Crea una instancia de NCliente para acceder a la lógica de negocio
            NCliente nCliente = new NCliente();

            try
            {
                // 4. Verifica si el cliente ya existe por nombre, apellido y correo
                if (nCliente.ClienteYaExiste(cliente.Nombres, cliente.Apellidos, cliente.Correo))
                {
                    MessageBox.Show("El cliente ya existe.");
                    return;
                }

                // 5. Intenta insertar el cliente
                bool insertado = nCliente.InsertarCliente(cliente);
                if (insertado)
                {
                    MessageBox.Show("Cliente insertado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al insertar el cliente.");
                    return;
                }

                // 6. Solo si todo sale bien, limpia y recarga
                LimpiarCampos();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el cliente: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            // Limpia los campos del formulario después de insertar un cliente
            TxtName.Clear(); // Limpia el campo de nombre
            TxtLastName.Clear(); // Limpia el campo de apellidos
            TxtPhoneNumber.Clear(); // Limpia el campo de teléfono
            TxtAdress.Clear(); // Limpia el campo de dirección
            TxtEmail.Clear(); // Limpia el campo de correo electrónico
        }

        private void DtgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(TxtCode.Text, out int id))
                {
                    // Muestra un mensaje de error si el ID no es un número válido
                    MessageBox.Show("Por favor, ingrese un ID válido.");
                    return;
                }

                // Crea una instancia de NCliente para acceder a la lógica de negocio
                NCliente nCliente = new NCliente();

                // Busca el cliente por ID
                ECliente cliente = nCliente.BuscarClientePorId(id);
                if (cliente != null)
                {
                    // Si se encuentra el cliente, muestra sus datos en los campos del formulario
                    TxtName.Text = cliente.Nombres;
                    TxtLastName.Text = cliente.Apellidos;
                    TxtPhoneNumber.Text = cliente.Telefono;
                    TxtAdress.Text = cliente.Direccion;
                    TxtEmail.Text = cliente.Correo;
                }
                else
                {
                    // Si no se encuentra el cliente, muestra un mensaje
                    MessageBox.Show("Cliente no encontrado.");
                }

            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al leer los clientes
                MessageBox.Show("Error al leer los clientes: " + ex.Message);
            }
        }

        // Método para actualizar un cliente
        private void BtnUpdate_Click_1(object sender, EventArgs e)
        {
            // Verifica si todos los campos del formulario están llenos
            if (string.IsNullOrWhiteSpace(TxtName.Text) || string.IsNullOrWhiteSpace(TxtLastName.Text) ||
                string.IsNullOrWhiteSpace(TxtPhoneNumber.Text) || string.IsNullOrWhiteSpace(TxtAdress.Text) ||
                string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return; // Sale del método si hay campos vacíos
            }
            // Crea una nueva instancia de ECliente con los datos ingresados en los campos del formulario
            ECliente cliente = new ECliente
            {
                Id = int.Parse(TxtCode.Text), // Asigna el ID del cliente desde el campo de texto
                Nombres = TxtName.Text, // Asigna el nombre del cliente desde el campo de texto
                Apellidos = TxtLastName.Text, // Asigna los apellidos del cliente desde el campo de texto
                Telefono = TxtPhoneNumber.Text, // Asigna el teléfono del cliente desde el campo de texto
                Direccion = TxtAdress.Text, // Asigna la dirección del cliente desde el campo de texto
                Correo = TxtEmail.Text, // Asigna el correo electrónico del cliente desde el campo de texto
                FechaRegistro = DateTime.Now, // Asigna la fecha actual como fecha de registro del cliente
                Estado = true, // Asigna el estado del cliente como activo
            };
            // Crea una instancia de NCliente para acceder a la lógica de negocio
            NCliente nCliente = new NCliente();
            try
            {
                // Intenta actualizar el cliente
                bool actualizado = nCliente.ActualizarCliente(cliente);
                if (actualizado)
                {
                    MessageBox.Show("Cliente actualizado correctamente.");
                    LimpiarCampos(); // Limpia los campos después de actualizar
                    CargarClientes(); // Recarga la lista de clientes
                }
                else
                {
                    MessageBox.Show("Error al actualizar el cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message);
            }
        }

        // Método para eliminar un cliente (cambia su estado a inactivo)
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(TxtCode.Text, out int id))
                {
                    // Muestra un mensaje de error si el ID no es un número válido
                    MessageBox.Show("Por favor, ingrese un ID válido.");
                    return;
                }
                // Crea una instancia de NCliente para acceder a la lógica de negocio
                NCliente nCliente = new NCliente();
                // Intenta eliminar el cliente por ID
                bool eliminado = nCliente.EliminarCliente(id);
                if (eliminado)
                {
                    MessageBox.Show("Cliente eliminado correctamente.");
                    LimpiarCampos(); // Limpia los campos después de eliminar
                    CargarClientes(); // Recarga la lista de clientes
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarCampos(); // Limpia los campos del formulario
        }

        // Método para imprimir el DataGridView (comentado porque no se usa actualmente) se encuentra inconpleto

        /*  private void BtnPrint_Click(object sender, EventArgs e)
          {
              filaActual = 0; // Reinicia fila al inicio

              documento.DefaultPageSettings.Landscape = true;

              PrintPreviewDialog vistaPrevia = new PrintPreviewDialog();
              vistaPrevia.Document = documento;
              vistaPrevia.ShowDialog();
          }


          private void Documento_PrintPage(object sender, PrintPageEventArgs e)
          {
              int y = 100;
              int x = 50;
              int altoFila = 30;

              Font fuente = new Font("Arial", 9);
              Brush pincel = Brushes.Black;

              int anchoDisponible = e.MarginBounds.Width;
              int columnas = DtgCliente.Columns.Count;
              int anchoColumna = anchoDisponible / columnas;

              // Encabezados
              for (int i = 0; i < columnas; i++)
              {
                  e.Graphics.DrawString(DtgCliente.Columns[i].HeaderText, fuente, pincel, x + i * anchoColumna, y);
              }

              y += altoFila;

              // Filas
              while (filaActual < DtgCliente.Rows.Count)
              {
                  for (int i = 0; i < columnas; i++)
                  {
                      object valor = DtgCliente.Rows[filaActual].Cells[i].Value;
                      if (valor != null)
                      {
                          string texto = valor.ToString();
                          e.Graphics.DrawString(texto, fuente, pincel, x + i * anchoColumna, y);
                      }
                  }

                  y += altoFila;
                  filaActual++;

                  if (y > e.MarginBounds.Bottom)
                  {
                      e.HasMorePages = true;
                      return;
                  }
              }

              e.HasMorePages = false;
          }*/


    }
}
