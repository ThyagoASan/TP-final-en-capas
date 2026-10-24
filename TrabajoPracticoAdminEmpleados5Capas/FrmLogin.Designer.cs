namespace TrabajoPracticoAdminEmpleados5Capas
{
    partial class FrmLogin
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardarModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(6, 55);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(6, 81);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(61, 13);
            this.lblClave.TabIndex = 1;
            this.lblClave.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(73, 48);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(186, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(73, 87);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(186, 20);
            this.txtClave.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(16, 255);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cmbIdioma
            // 
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Location = new System.Drawing.Point(73, 124);
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.Size = new System.Drawing.Size(121, 21);
            this.cmbIdioma.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Idioma";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(110, 168);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardarModificar
            // 
            this.btnGuardarModificar.Location = new System.Drawing.Point(99, 206);
            this.btnGuardarModificar.Name = "btnGuardarModificar";
            this.btnGuardarModificar.Size = new System.Drawing.Size(95, 23);
            this.btnGuardarModificar.TabIndex = 8;
            this.btnGuardarModificar.Text = "GuardarModificar";
            this.btnGuardarModificar.UseVisualStyleBackColor = true;
            this.btnGuardarModificar.Click += new System.EventHandler(this.btnGuardarModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(16, 168);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 9;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(289, 12);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(274, 288);
            this.dgvUsuarios.TabIndex = 10;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(73, 12);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(186, 20);
            this.txtCodigo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Codigo";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(208, 168);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 312);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnGuardarModificar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbIdioma);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.lblUsuario);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardarModificar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
    }
}