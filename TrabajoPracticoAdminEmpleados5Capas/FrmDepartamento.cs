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

namespace TrabajoPracticoAdminEmpleados5Capas
{
    public partial class FrmDepartamento : Form
    {
        private DepartamentoBLL bllDepartamento;
        private List<BEDepartamento> _listaDeptos;
        private BEDepartamento _deptoEditando;
        private bool _cargandoDatos = false;
        public FrmDepartamento()
        {
            InitializeComponent();
            bllDepartamento = new DepartamentoBLL();
            CargarDepartamentos();
            CargarCategorias();

        }
        private void CargarDepartamentos()
        {
            _listaDeptos = bllDepartamento.ListarTodo(); // <- devuelve List<BEDepartamento>
            dgvDepartamentos.AutoGenerateColumns = true;
            dgvDepartamentos.DataSource = null;
            dgvDepartamentos.DataSource = _listaDeptos;
        }
        private void CargarCategorias()
        {
            cmbCategoria.DataSource = null;
            cmbCategoria.Items.Clear();

            cmbCategoria.Items.Add("Colegio");
            cmbCategoria.Items.Add("Facultad");

            cmbCategoria.SelectedIndex = -1; // sin selección inicial
        }
        private void AplicarCategoriaUI()
        {
            bool esColegio = cmbCategoria.SelectedItem?.ToString() == "Colegio";

            txtCantaulas.Enabled = esColegio;
            txtCantCarreras.Enabled = !esColegio;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BEDepartamento departamento;

            string nombre = txtNombre.Text;

            if (cmbCategoria.Text == "Colegio")
            {
                departamento = new BEColegio
                {
                    Nombre = nombre,
                    Categoria = "Colegio",
                    CantidadAulas = int.Parse(txtCantaulas.Text)
                };
            }
            else
            {
                departamento = new BEFacultad
                {
                    Nombre = nombre,
                    Categoria = "Facultad",
                    CantidadCarreras = int.Parse(txtCantCarreras.Text)
                };
            }

            bllDepartamento.Guardar(departamento);
            CargarDepartamentos();
            LimpiarCampos();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDepartamentos.CurrentRow == null || dgvDepartamentos.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Selecciona un departamento.");
                return;
            }

            _deptoEditando = (BEDepartamento)dgvDepartamentos.CurrentRow.DataBoundItem;


            // Cargar datos en TextBox / Combo
            textBox1.Text = _deptoEditando.Codigo.ToString();  // identity: solo mostrar
            txtNombre.Text = _deptoEditando.Nombre;

            // seleccionar categoría BIEN
            cmbCategoria.SelectedIndex = cmbCategoria.FindStringExact(_deptoEditando.Categoria);

            // aplicar enabled/disabled
            AplicarCategoriaUI();

            if (_deptoEditando is BEColegio col)
            {
                txtCantaulas.Text = col.CantidadAulas.ToString();
                txtCantCarreras.Clear();
            }
            else if (_deptoEditando is BEFacultad fac)
            {
                txtCantCarreras.Text = fac.CantidadCarreras.ToString();
                txtCantaulas.Clear();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDepartamentos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un departamento");
                return;
            }

            int codigo = Convert.ToInt32(dgvDepartamentos.CurrentRow.Cells["Codigo"].Value);

            bllDepartamento.Baja(codigo);
            CargarDepartamentos();
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            textBox1.Clear();
            txtNombre.Clear();
            txtCantaulas.Clear(); // o CantidadCarreras según el caso
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargandoDatos) return;   // <- clave para que no se pise cuando cargás datos

            AplicarCategoriaUI();

            // Opcional: limpiar el textbox que no corresponde
            bool esColegio = cmbCategoria.SelectedItem?.ToString() == "Colegio";
            if (esColegio) txtCantCarreras.Clear();
            else txtCantaulas.Clear();
        }

        private void btnGuardamodificar_Click(object sender, EventArgs e)
        {
            if (_deptoEditando == null)
            {
                MessageBox.Show("Primero toca Modificar.");
                return;
            }

            BEDepartamento deptoModificado = null;

            if (_deptoEditando is BEColegio)
            {
                deptoModificado = new BEColegio
                {
                    Codigo = _deptoEditando.Codigo,  // identity NO se cambia
                    Nombre = txtNombre.Text,
                    Categoria = "Colegio",
                    CantidadAulas = int.Parse(txtCantaulas.Text)
                };
            }
            else if (_deptoEditando is BEFacultad)
            {
                deptoModificado = new BEFacultad
                {
                    Codigo = _deptoEditando.Codigo,
                    Nombre = txtNombre.Text,
                    Categoria = "Facultad",
                    CantidadCarreras = int.Parse(txtCantCarreras.Text)
                };
            }

            if (bllDepartamento.Modificar(_deptoEditando, deptoModificado))
            {
                MessageBox.Show("Departamento modificado con éxito.");
                CargarDepartamentos();
                LimpiarCampos();
                _deptoEditando = null;
            }
            else
            {
                MessageBox.Show("Error al modificar.");
            }
        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idiomaSeleccionado = cmbIdioma.SelectedItem.ToString();
            AplicarIdioma(idiomaSeleccionado);
        }

        private void FrmDepartamento_Load(object sender, EventArgs e)
        {
            cmbIdioma.Items.Add("ES");
            cmbIdioma.Items.Add("EN");
            cmbIdioma.SelectedIndex = 0;
            AplicarIdioma("ES");
            cmbIdioma.SelectedIndexChanged += cmbIdioma_SelectedIndexChanged;
        }

        private void AplicarIdioma(string idioma)
        {
            if (idioma == "ES")
            {
                lblCodigo.Text = "Codigo";
                lblNombre.Text = "Nombre";
                lblCategoria.Text = "Categoría";
                lblCantCarreras.Text = "Cant. Carreras";
                btnAgregar.Text = "Agregar";
                btnModificar.Text = "Modificar";
                btnBorrar.Text = "Borrar";
                btnGuardamodificar.Text = "Guardar/Modificar";
            }
            else if (idioma == "EN")
            {
                lblCodigo.Text = "Code";
                lblNombre.Text = "Name";
                lblCategoria.Text = "Category";
                lblCantCarreras.Text = "Careers";
                btnAgregar.Text = "Add";
                btnModificar.Text = "Edit";
                btnBorrar.Text = "Delete";
                btnGuardamodificar.Text = "Save/Edit";
            }
        }
    }
}
