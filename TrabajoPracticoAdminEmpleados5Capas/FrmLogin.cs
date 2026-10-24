using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using MPP;
using BLL;
using System.Text.RegularExpressions;


namespace TrabajoPracticoAdminEmpleados5Capas
{
    public partial class FrmLogin : Form
    {
        private UsuarioBLL bll = new UsuarioBLL();
        private BEUsuario seleccionado = null;
        public bool ModoABM { get; set; } = false;
        public FrmLogin()
        {
            InitializeComponent();


        }
        private void CargarUsuarios()
        {
            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = bll.Listar();

            // opcional: ocultar la clave en grilla
            if (dgvUsuarios.Columns["Clave"] != null)
                dgvUsuarios.Columns["Clave"].Visible = false;
        }

        private bool ValidarInputs()
        {
            Regex rxUser = new Regex(@"^[a-zA-Z0-9._-]{4,20}$");
            Regex rxPass = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$");

            if (!rxUser.IsMatch(txtUsuario.Text))
            {
                MessageBox.Show("Usuario inválido (4-20: letras/números/._-).");
                return false;
            }
            if (!rxPass.IsMatch(txtClave.Text))
            {
                MessageBox.Show("Clave inválida (mín 6, mayúscula, minúscula y número).");
                return false;
            }
            return true;
        }

        private bool ValidarLogin()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Ingrese usuario");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Ingrese clave");
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarLogin()) return;

            var usuario = new BEUsuario
            {
                NombreUsuario = txtUsuario.Text,
                Clave = bll.EncriptarClave(txtClave.Text)
            };

            if (!bll.ValidarUsuario(usuario))
            {
                MessageBox.Show("Usuario o clave incorrecta");
                return;
            }

            // 🔐 LOGIN OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            bool hayUsuarios = bll.HayUsuarios();

            // idioma
            cmbIdioma.Items.Add("ES");
            cmbIdioma.Items.Add("EN");
            cmbIdioma.SelectedIndex = 0;
            AplicarIdioma("ES");
            cmbIdioma.SelectedIndexChanged += (s, ev) =>
            {
                string idioma = cmbIdioma.SelectedItem.ToString();
                AplicarIdioma(idioma);
            };

            // ✅ si lo abro como ABM, SIEMPRE mostrar grilla y cargar
            if (ModoABM)
            {
                dgvUsuarios.Visible = true;
                btnAgregar.Visible = true;
                btnModificar.Visible = true;
                btnBorrar.Visible = true;
                btnGuardarModificar.Visible = true;

                btnAceptar.Visible = false; // en ABM no se loguea

                CargarUsuarios();
                return;
            }

            // ✅ si es LOGIN y no hay usuarios: permitir crear el primero
            if (!hayUsuarios)
            {
                MessageBox.Show("No hay usuarios cargados. Cree el primer usuario (admin).");

                dgvUsuarios.Visible = true;
                btnAgregar.Visible = true;

                btnModificar.Visible = false;
                btnBorrar.Visible = false;
                btnGuardarModificar.Visible = false;

                btnAceptar.Visible = false;

                CargarUsuarios();
            }
            else
            {
                // ✅ login normal: ocultar ABM
                dgvUsuarios.Visible = false;
                btnAgregar.Visible = false;
                btnModificar.Visible = false;
                btnBorrar.Visible = false;
                btnGuardarModificar.Visible = false;

                btnAceptar.Visible = true;
            }


        }

        private void AplicarIdioma(string idioma)
        {
            if (idioma == "ES")
            {
                this.Text = "Login";
                lblUsuario.Text = "Usuario";
                lblClave.Text = "Clave";
                btnAceptar.Text = "Ingresar";

            }
            else // EN
            {
                this.Text = "Login";
                lblUsuario.Text = "User";
                lblClave.Text = "Password";
                btnAceptar.Text = "Sign in";

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem == null) return;

            seleccionado = (BEUsuario)dgvUsuarios.CurrentRow.DataBoundItem;
            txtCodigo.Text = seleccionado.Codigo.ToString();
            txtUsuario.Text = seleccionado.NombreUsuario;

            txtClave.Clear(); // obligo  a reingresar
        }

        private void btnGuardarModificar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null) return;
            if (!ValidarInputs()) return;

            bll.Modificar(seleccionado.Codigo, txtUsuario.Text, txtClave.Text);
            CargarUsuarios();
            Limpiar();
            seleccionado = null;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem == null) return;

            var u = (BEUsuario)dgvUsuarios.CurrentRow.DataBoundItem;
            bll.Baja(u.Codigo);

            CargarUsuarios();
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarInputs()) return;

            bll.Alta(txtUsuario.Text, txtClave.Text);

            MessageBox.Show("Usuario creado. Ahora puede ingresar.");

            // ahora ya hay usuarios → ocultás ABM si querés
            // ✅ pasar a modo login
            btnAceptar.Visible = true;
            btnAgregar.Visible = false;
            dgvUsuarios.Visible = false;

            CargarUsuarios();
            Limpiar();
        }
    }
}
