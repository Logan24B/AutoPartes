namespace Presentacion
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.Pnlmenu = new System.Windows.Forms.Panel();
            this.BtnCliente = new System.Windows.Forms.Button();
            this.BtnProveedores = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pnlmain = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Pnlmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnlmenu
            // 
            this.Pnlmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(176)))), ((int)(((byte)(225)))));
            this.Pnlmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Pnlmenu.Controls.Add(this.button1);
            this.Pnlmenu.Controls.Add(this.BtnCliente);
            this.Pnlmenu.Controls.Add(this.BtnProveedores);
            this.Pnlmenu.Controls.Add(this.label1);
            this.Pnlmenu.Controls.Add(this.pictureBox1);
            this.Pnlmenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Pnlmenu.Location = new System.Drawing.Point(0, 0);
            this.Pnlmenu.Name = "Pnlmenu";
            this.Pnlmenu.Size = new System.Drawing.Size(221, 547);
            this.Pnlmenu.TabIndex = 0;
            // 
            // BtnCliente
            // 
            this.BtnCliente.BackColor = System.Drawing.Color.White;
            this.BtnCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCliente.FlatAppearance.BorderSize = 0;
            this.BtnCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCliente.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCliente.Image = ((System.Drawing.Image)(resources.GetObject("BtnCliente.Image")));
            this.BtnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCliente.Location = new System.Drawing.Point(16, 240);
            this.BtnCliente.Name = "BtnCliente";
            this.BtnCliente.Size = new System.Drawing.Size(194, 41);
            this.BtnCliente.TabIndex = 2;
            this.BtnCliente.Text = "Clientes";
            this.BtnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCliente.UseVisualStyleBackColor = false;
            this.BtnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // BtnProveedores
            // 
            this.BtnProveedores.BackColor = System.Drawing.Color.White;
            this.BtnProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProveedores.FlatAppearance.BorderSize = 0;
            this.BtnProveedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProveedores.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("BtnProveedores.Image")));
            this.BtnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProveedores.Location = new System.Drawing.Point(16, 181);
            this.BtnProveedores.Name = "BtnProveedores";
            this.BtnProveedores.Size = new System.Drawing.Size(194, 41);
            this.BtnProveedores.TabIndex = 0;
            this.BtnProveedores.Text = "Proveedores";
            this.BtnProveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnProveedores.UseVisualStyleBackColor = false;
            this.BtnProveedores.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(10, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "EUROPARTES, S.A.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Pnlmain
            // 
            this.Pnlmain.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Pnlmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnlmain.Location = new System.Drawing.Point(221, 0);
            this.Pnlmain.Name = "Pnlmain";
            this.Pnlmain.Size = new System.Drawing.Size(945, 547);
            this.Pnlmain.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(16, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Facturación";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 547);
            this.Controls.Add(this.Pnlmain);
            this.Controls.Add(this.Pnlmenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FMain";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FMain_Load);
            this.Pnlmenu.ResumeLayout(false);
            this.Pnlmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pnlmenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Pnlmain;
        private System.Windows.Forms.Button BtnProveedores;
        private System.Windows.Forms.Button BtnCliente;
        private System.Windows.Forms.Button button1;
    }
}