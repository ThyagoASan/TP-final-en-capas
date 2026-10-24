namespace TrabajoPracticoAdminEmpleados5Capas
{
    partial class FrmEmpleadoDesconectado
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
            this.dgvEmpleadosDesc = new System.Windows.Forms.DataGridView();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.txtFiltroDni = new System.Windows.Forms.TextBox();
            this.btnLimpiarFiltro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBorrarFila = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnCancelarCambios = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleadosDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpleadosDesc
            // 
            this.dgvEmpleadosDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleadosDesc.Location = new System.Drawing.Point(21, 12);
            this.dgvEmpleadosDesc.Name = "dgvEmpleadosDesc";
            this.dgvEmpleadosDesc.Size = new System.Drawing.Size(304, 299);
            this.dgvEmpleadosDesc.TabIndex = 0;
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(344, 20);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroNombre.TabIndex = 1;
            // 
            // txtFiltroDni
            // 
            this.txtFiltroDni.Location = new System.Drawing.Point(344, 64);
            this.txtFiltroDni.Name = "txtFiltroDni";
            this.txtFiltroDni.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroDni.TabIndex = 3;
            // 
            // btnLimpiarFiltro
            // 
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(331, 154);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarFiltro.TabIndex = 4;
            this.btnLimpiarFiltro.Text = "Filtro";
            this.btnLimpiarFiltro.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltro.Click += new System.EventHandler(this.btnLimpiarFiltro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(466, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dni";
            // 
            // btnBorrarFila
            // 
            this.btnBorrarFila.Location = new System.Drawing.Point(425, 113);
            this.btnBorrarFila.Name = "btnBorrarFila";
            this.btnBorrarFila.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarFila.TabIndex = 8;
            this.btnBorrarFila.Text = "Borrar";
            this.btnBorrarFila.UseVisualStyleBackColor = true;
            this.btnBorrarFila.Click += new System.EventHandler(this.btnBorrarFila_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(331, 113);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(425, 154);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCambios.TabIndex = 10;
            this.btnGuardarCambios.Text = "GuardaCambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // btnCancelarCambios
            // 
            this.btnCancelarCambios.Location = new System.Drawing.Point(425, 194);
            this.btnCancelarCambios.Name = "btnCancelarCambios";
            this.btnCancelarCambios.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCambios.TabIndex = 11;
            this.btnCancelarCambios.Text = "CancelarCambios";
            this.btnCancelarCambios.UseVisualStyleBackColor = true;
            this.btnCancelarCambios.Click += new System.EventHandler(this.btnCancelarCambios_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(528, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(645, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Apellido";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(528, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(645, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "salario";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(528, 113);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(645, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "IdDepartamento";
            // 
            // FrmEmpleadoDesconectado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnCancelarCambios);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnBorrarFila);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiarFiltro);
            this.Controls.Add(this.txtFiltroDni);
            this.Controls.Add(this.txtFiltroNombre);
            this.Controls.Add(this.dgvEmpleadosDesc);
            this.Name = "FrmEmpleadoDesconectado";
            this.Text = "FrmEmpleadoDesconectado";
            this.Load += new System.EventHandler(this.FrmEmpleadoDesconectado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleadosDesc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpleadosDesc;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.TextBox txtFiltroDni;
        private System.Windows.Forms.Button btnLimpiarFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBorrarFila;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnCancelarCambios;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
    }
}