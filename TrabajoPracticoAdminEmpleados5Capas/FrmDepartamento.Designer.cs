namespace TrabajoPracticoAdminEmpleados5Capas
{
    partial class FrmDepartamento
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
            this.lblCodigo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dgvDepartamentos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.txtCantaulas = new System.Windows.Forms.TextBox();
            this.txtCantCarreras = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnGuardamodificar = new System.Windows.Forms.Button();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblCantCarreras = new System.Windows.Forms.Label();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(560, 19);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 13;
            this.lblCodigo.Text = "Codigo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(563, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 14;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(684, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(170, 20);
            this.txtNombre.TabIndex = 16;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(681, 19);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 17;
            this.lblNombre.Text = "Nombre";
            // 
            // dgvDepartamentos
            // 
            this.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamentos.Location = new System.Drawing.Point(12, 12);
            this.dgvDepartamentos.Name = "dgvDepartamentos";
            this.dgvDepartamentos.Size = new System.Drawing.Size(512, 396);
            this.dgvDepartamentos.TabIndex = 23;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(563, 172);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 24;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(668, 172);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 25;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(779, 172);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 26;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // txtCantaulas
            // 
            this.txtCantaulas.Location = new System.Drawing.Point(563, 137);
            this.txtCantaulas.Name = "txtCantaulas";
            this.txtCantaulas.Size = new System.Drawing.Size(170, 20);
            this.txtCantaulas.TabIndex = 27;
            // 
            // txtCantCarreras
            // 
            this.txtCantCarreras.Location = new System.Drawing.Point(757, 137);
            this.txtCantCarreras.Name = "txtCantCarreras";
            this.txtCantCarreras.Size = new System.Drawing.Size(170, 20);
            this.txtCantCarreras.TabIndex = 28;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(563, 95);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cmbCategoria.TabIndex = 29;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // btnGuardamodificar
            // 
            this.btnGuardamodificar.Location = new System.Drawing.Point(668, 217);
            this.btnGuardamodificar.Name = "btnGuardamodificar";
            this.btnGuardamodificar.Size = new System.Drawing.Size(93, 23);
            this.btnGuardamodificar.TabIndex = 30;
            this.btnGuardamodificar.Text = "GuardarModificar";
            this.btnGuardamodificar.UseVisualStyleBackColor = true;
            this.btnGuardamodificar.Click += new System.EventHandler(this.btnGuardamodificar_Click);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(703, 98);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 31;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblCantCarreras
            // 
            this.lblCantCarreras.AutoSize = true;
            this.lblCantCarreras.Location = new System.Drawing.Point(933, 144);
            this.lblCantCarreras.Name = "lblCantCarreras";
            this.lblCantCarreras.Size = new System.Drawing.Size(71, 13);
            this.lblCantCarreras.TabIndex = 32;
            this.lblCantCarreras.Text = "Cant Carreras";
            // 
            // cmbIdioma
            // 
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Location = new System.Drawing.Point(779, 98);
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.Size = new System.Drawing.Size(121, 21);
            this.cmbIdioma.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(920, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Idioma ";
            // 
            // FrmDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 440);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbIdioma);
            this.Controls.Add(this.lblCantCarreras);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.btnGuardamodificar);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.txtCantCarreras);
            this.Controls.Add(this.txtCantaulas);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvDepartamentos);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCodigo);
            this.Name = "FrmDepartamento";
            this.Text = "FrmDepartamento";
            this.Load += new System.EventHandler(this.FrmDepartamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DataGridView dgvDepartamentos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.TextBox txtCantaulas;
        private System.Windows.Forms.TextBox txtCantCarreras;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnGuardamodificar;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblCantCarreras;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.Label label5;
    }
}