using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace TrabajoPracticoAdminEmpleados5Capas
{
    public partial class FrmAdministracion : Form
    {
        private BLLEmpleado bllEmpleado;
        private DepartamentoBLL bllDepartamento;

        public FrmAdministracion()
        {
            InitializeComponent();
            ucHeader1.Titulo = "Administración de Empleados";
            ucHeader1.Subtitulo = "Alta / Baja / Modificación";
            bllEmpleado = new BLLEmpleado();
            bllDepartamento = new DepartamentoBLL();   // ✅

            CargarComboDepartamento();                // ✅ primero
            CargarEmpleados();

        }
        private void CargarComboDepartamento()
        {
            var departamentos = bllDepartamento.ListarTodo(); // devuelve List<BEDepartamento>

            comboBox1.DataSource = departamentos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Codigo";
            comboBox1.SelectedIndex = -1;
        }
        private void CargarEmpleados()
        {
            var empleados = bllEmpleado.ListarTodo();

            dgvEmpleado.AutoGenerateColumns = false;
            dgvEmpleado.Columns.Clear();
            dgvEmpleado.DataSource = null;

            dgvEmpleado.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Codigo",
                HeaderText = "Código"
            });

            dgvEmpleado.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre"
            });

            dgvEmpleado.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido"
            });

            dgvEmpleado.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Dni",
                HeaderText = "DNI"
            });

            dgvEmpleado.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Salario",
                HeaderText = "Salario"
            });

            // ✅ USAMOS EL INT QUE YA EXISTE (para XML)
            dgvEmpleado.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdDepartamentoCodigo",
                HeaderText = " IdDepartamento"
            });

            dgvEmpleado.DataSource = empleados;
        }
        private void FrmAdministracion_Load(object sender, EventArgs e)
        {

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Regex rxNombre = new Regex(@"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ ]{2,50}$");
            Regex rxDni = new Regex(@"^\d{7,8}$");

            if (!rxNombre.IsMatch(txtNombre.Text))
            {
                MessageBox.Show("Nombre inválido (solo letras y espacios, 2 a 50).");
                txtNombre.Focus();
                return;
            }

            if (!rxNombre.IsMatch(txtApellido.Text))
            {
                MessageBox.Show("Apellido inválido (solo letras y espacios, 2 a 50).");
                txtApellido.Focus();
                return;
            }

            if (!rxDni.IsMatch(txtDni.Text))
            {
                MessageBox.Show("DNI inválido (debe tener 7 u 8 dígitos).");
                txtDni.Focus();
                return;
            }

            if (!int.TryParse(txtDni.Text, out int dni))
            {
                MessageBox.Show("DNI inválido");
                return;
            }

            if (!decimal.TryParse(txtSalario.Text, out decimal salario))
            {
                MessageBox.Show("Salario inválido");
                return;
            }

            var depto = (BEDepartamento)comboBox1.SelectedItem;
            if (depto == null)
            {
                MessageBox.Show("Seleccione un departamento");
                return;
            }

            var empleado = new BEEmpleado
            {
                // NO Codigo (lo genera la DB)
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = dni,
                Salario = salario,
                IdDepartamento = depto
            };

            bllEmpleado.Guardar(empleado);
            CargarEmpleados();
            LimpiarCampos();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleado.CurrentRow == null || dgvEmpleado.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Selecciona un empleado primero.");
                return;
            }

            var emp = (BEEmpleado)dgvEmpleado.CurrentRow.DataBoundItem;

            textBox1.Text = emp.Codigo.ToString();  // identity: solo mostrar
            txtNombre.Text = emp.Nombre;
            txtApellido.Text = emp.Apellido;
            txtDni.Text = emp.Dni.ToString();
            txtSalario.Text = emp.Salario.ToString();

            if (emp.IdDepartamento != null)
                comboBox1.SelectedValue = emp.IdDepartamento.Codigo; // ✅ con DataSource
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleado.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un empleado");
                return;
            }

            var empleadoSeleccionado =
                (BEEmpleado)dgvEmpleado.CurrentRow.DataBoundItem;

            bllEmpleado.Baja(empleadoSeleccionado.Codigo);

            CargarEmpleados();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtSalario.Clear();
            comboBox1.SelectedIndex = -1;
        }
        private void Exportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Archivos XML (*.xml)|*.xml";
                sfd.FileName = "empleados.xml";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    BLLEmpleado bll = new BLLEmpleado();
                    bll.ExportarXml(sfd.FileName);

                    MessageBox.Show("Exportación a XML realizada correctamente",
                                    "XML",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Importar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Archivos XML (*.xml)|*.xml";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    BLLEmpleado bll = new BLLEmpleado();
                    dgvEmpleado.DataSource = null;
                    dgvEmpleado.DataSource = bll.ImportarXml(ofd.FileName);

                    MessageBox.Show("Importación desde XML realizada correctamente",
                                    "XML",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarmodficar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleado.CurrentRow == null || dgvEmpleado.CurrentRow.DataBoundItem == null)
                return;

            var empleadoSeleccionado = (BEEmpleado)dgvEmpleado.CurrentRow.DataBoundItem;

            var empleadoModificado = new BEEmpleado
            {
                Codigo = empleadoSeleccionado.Codigo, // identity: NO se cambia
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = int.Parse(txtDni.Text),
                Salario = decimal.Parse(txtSalario.Text),
                IdDepartamento = (BEDepartamento)comboBox1.SelectedItem
            };

            if (bllEmpleado.Modificar(empleadoSeleccionado, empleadoModificado))
            {
                MessageBox.Show("Empleado modificado con éxito.");
                CargarEmpleados();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al modificar el empleado.");
            }
        }
    }
}
