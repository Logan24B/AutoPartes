using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            // Cierra el formulario anterior si existe
            if (Pnlmain.Controls.Count > 0)
                Pnlmain.Controls.RemoveAt(0);

            // Configura el nuevo formulario
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.None; // ❌ No llenar el panel

            // Asignar posición centrada dentro del panel
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point(
                (Pnlmain.Width - formulario.Width) / 2,
                (Pnlmain.Height - formulario.Height) / 2
            );

            // Agrega al panel y muestra
            Pnlmain.Controls.Add(formulario);
            Pnlmain.Tag = formulario;
            formulario.Show();
        }


        private void button1_Click(object sender, EventArgs e) // ← Botón para abrir el formulario de Proveedor
        {
           
            AbrirFormularioEnPanel(new FProveedor());

        }

        private void FMain_Load(object sender, EventArgs e) // ← Evento que se dispara al cargar el formulario principal
        {
            
        }
       




    }
}
