using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad; // Importamos la entidad EProveedor
using Negocio; // Importamos la capa de negocio para acceder a los proveedores


namespace Presentacion
{
    public partial class FProveedor : Form
    {
        private NProveedor nProveedor = new NProveedor(); // Instancia de la capa de negocio para proveedores
        private NPais paisNegocio = new NPais(); // instancia de la capa negocio

        public FProveedor()
        {
            InitializeComponent();
            CargarProveedores(); // Llamamos al método para cargar los proveedores al iniciar el formulario
            CargarPaises(); // Llamamos al método para cargar los países al iniciar el formulario
        }
        private void CargarProveedores()
        {
            try
            {
                List<EProveedor> listaProveedores = nProveedor.ObtenerProveedores(); // Obtenemos la lista de proveedores desde la capa de negocio
                DtgProveedor.DataSource = listaProveedores; // Asignamos la lista al DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FProveedor_Load(object sender, EventArgs e)
        {

        }

        private void DtgProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            // 1. Validar campos obligatorios primero
            if (string.IsNullOrWhiteSpace(TxtName.Text) || string.IsNullOrWhiteSpace(TxtEmail.Text) || CmbCountry.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener valores
            string nombre = TxtName.Text.Trim();
            string telefono = TxtPhone.Text.Trim();
            string email = TxtEmail.Text.Trim();
            string sitioWeb = TxtUrl.Text.Trim();
            int paisId = ((EPais)CmbCountry.SelectedItem).Id;
            DateTime fechaRegistro = DateTime.Now;
            bool estado = ChkStatus.Checked;

            // 3. Crear proveedor
            EProveedor nuevoProveedor = new EProveedor(0, nombre, paisId, telefono, email, sitioWeb, fechaRegistro, estado);

            // 4. Validar duplicado e insertar
            try
            {
                if (nProveedor.ProveedorYaExiste(nombre))
                {
                    MessageBox.Show("Este proveedor ya está registrado.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                nProveedor.AgregarProveedor(nuevoProveedor);
                MessageBox.Show("Proveedor insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            TxtName.Clear();
            TxtPhone.Clear();
            TxtEmail.Clear();
            TxtUrl.Clear();
            CmbCountry.SelectedIndex = 0;
            ChkStatus.Checked = true;
        }


        private void CmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CargarPaises()
        {
            try
            {
                List<EPais> paises = paisNegocio.ObtenerTodos();
                CmbCountry.DataSource = paises;
                CmbCountry.DisplayMember = "Nombre"; // lo que se muestra en el combo
                CmbCountry.ValueMember = "Id";       // lo que se usa internamente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar países: " + ex.Message);
            }
        }
        // Método para manejar el evento de clic del botón "Leer"
        private void BtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(TxtCode.Text, out int id))
                {
                    MessageBox.Show("Ingrese un ID válido para buscar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NProveedor negocio = new NProveedor();
                EProveedor proveedor = negocio.BuscarProveedorPorId(id);

                if (proveedor != null)
                {
                    TxtName.Text = proveedor.Nombre;
                    TxtPhone.Text = proveedor.Telefono;
                    TxtEmail.Text = proveedor.Email;
                    TxtUrl.Text = proveedor.SitioWeb;
                    CmbCountry.SelectedValue = proveedor.PaisId;
                    ChkStatus.Checked = proveedor.Estado;
                    // Opcional: podrías guardar la fecha original en un campo oculto si querés conservarla en el update
                }
                else
                {
                    MessageBox.Show("Proveedor no encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar ID
                if (string.IsNullOrWhiteSpace(TxtCode.Text))
                {
                    MessageBox.Show("Debe buscar o seleccionar un proveedor para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar campos requeridos
                if (string.IsNullOrWhiteSpace(TxtName.Text) || string.IsNullOrWhiteSpace(TxtEmail.Text) || CmbCountry.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener datos
                int id = int.Parse(TxtCode.Text);
                string nombre = TxtName.Text.Trim();
                string telefono = TxtPhone.Text.Trim();
                string email = TxtEmail.Text.Trim();
                string sitioWeb = TxtUrl.Text.Trim();
                int paisId = ((EPais)CmbCountry.SelectedItem).Id;
                DateTime fechaRegistro = DateTime.Now; // o conservar el original si lo estás guardando
                bool estado = ChkStatus.Checked;

                EProveedor proveedorActualizado = new EProveedor(id, nombre, paisId, telefono, email, sitioWeb, fechaRegistro, estado);

                // Actualizar
                bool actualizado = nProveedor.ActualizarProveedor(proveedorActualizado);

                if (actualizado)
                {
                    MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarProveedores();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya un proveedor cargado
                if (string.IsNullOrWhiteSpace(TxtCode.Text))
                {
                    MessageBox.Show("Debe buscar o seleccionar un proveedor para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validar que el ID sea un número válido
                int id = int.Parse(TxtCode.Text);

                // Confirmación
                DialogResult confirm = MessageBox.Show("¿Estás seguro de que deseas eliminar este proveedor?",
                                                       "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    bool eliminado = nProveedor.EliminarProveedor(id);

                    if (eliminado)
                    {
                        MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        CargarProveedores();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarCampos(); // Limpia todos los campos del formulario
        }
    }
}

