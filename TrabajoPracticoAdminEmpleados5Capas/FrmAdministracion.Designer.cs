namespace TrabajoPracticoAdminEmpleados5Capas
{
    partial class FrmAdministracion
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvEmpleado = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Exportar = new System.Windows.Forms.Button();
            this.Importar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnGuardarmodficar = new System.Windows.Forms.Button();
            this.ucHeader1 = new TrabajoPracticoAdminEmpleados5Capas.UcHeader();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "codigo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(538, 141);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(659, 141);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(170, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(656, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(659, 187);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(170, 20);
            this.txtApellido.TabIndex = 5;
            // 
            // txtSalario
            // 
            this.txtSalario.Location = new System.Drawing.Point(538, 187);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(100, 20);
            this.txtSalario.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Salario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Apellido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(535, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "IdDepartamento";
            // 
            // dgvEmpleado
            // 
            this.dgvEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleado.Location = new System.Drawing.Point(12, 12);
            this.dgvEmpleado.Name = "dgvEmpleado";
            this.dgvEmpleado.Size = new System.Drawing.Size(512, 396);
            this.dgvEmpleado.TabIndex = 10;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(538, 283);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(644, 283);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(754, 283);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 13;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(659, 238);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(656, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "DNI";
            // 
            // Exportar
            // 
            this.Exportar.Location = new System.Drawing.Point(538, 327);
            this.Exportar.Name = "Exportar";
            this.Exportar.Size = new System.Drawing.Size(100, 23);
            this.Exportar.TabIndex = 16;
            this.Exportar.Text = "Exportar Xml";
            this.Exportar.UseVisualStyleBackColor = true;
            this.Exportar.Click += new System.EventHandler(this.Exportar_Click);
            // 
            // Importar
            // 
            this.Importar.Location = new System.Drawing.Point(644, 327);
            this.Importar.Name = "Importar";
            this.Importar.Size = new System.Drawing.Size(75, 23);
            this.Importar.TabIndex = 17;
            this.Importar.Text = "Importar Xml";
            this.Importar.UseVisualStyleBackColor = true;
            this.Importar.Click += new System.EventHandler(this.Importar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(532, 238);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 18;
            // 
            // btnGuardarmodficar
            // 
            this.btnGuardarmodficar.Location = new System.Drawing.Point(754, 327);
            this.btnGuardarmodficar.Name = "btnGuardarmodficar";
            this.btnGuardarmodficar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarmodficar.TabIndex = 19;
            this.btnGuardarmodficar.Text = "GuardaModificar";
            this.btnGuardarmodficar.UseVisualStyleBackColor = true;
            this.btnGuardarmodficar.Click += new System.EventHandler(this.btnGuardarmodficar_Click);
            // 
            // ucHeader1
            // 
            this.ucHeader1.Location = new System.Drawing.Point(530, 12);
            this.ucHeader1.Name = "ucHeader1";
            this.ucHeader1.Size = new System.Drawing.Size(289, 92);
            this.ucHeader1.Subtitulo = "Subtitulo";
            this.ucHeader1.TabIndex = 20;
            this.ucHeader1.Titulo = "Titulo";
            // 
            // FrmAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 434);
            this.Controls.Add(this.ucHeader1);
            this.Controls.Add(this.btnGuardarmodficar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Importar);
            this.Controls.Add(this.Exportar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvEmpleado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmAdministracion";
            this.Text = "FrmAdministracion";
            this.Load += new System.EventHandler(this.FrmAdministracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox CargarComboDepartamentos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvEmpleado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Exportar;
        private System.Windows.Forms.Button Importar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnGuardarmodficar;
        private UcHeader ucHeader1;
    }
}