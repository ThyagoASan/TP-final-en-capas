using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPracticoAdminEmpleados5Capas
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            BloquearMenu();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministracion frmAdministracion = new FrmAdministracion();
            frmAdministracion.MdiParent = this;
            frmAdministracion.Show();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDepartamento frmDepartamentos = new FrmDepartamento();
            frmDepartamentos.MdiParent = this;
            frmDepartamentos.Show();
        }

        private void sucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSucursal frmSucursal = new FrmSucursal();
            frmSucursal.MdiParent = this;
            frmSucursal.Show();
        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frminformes frminformes = new frminformes();
            frminformes.MdiParent = this;
            frminformes.Show();
        }

        private void empleadoDesconectadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpleadoDesconectado frmEmpleadoDesconectado = new FrmEmpleadoDesconectado();
            frmEmpleadoDesconectado.MdiParent = this;
            frmEmpleadoDesconectado.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.ModoABM = true;     // 👥 ABM usuarios
            frm.MdiParent = this;
            frm.Show();
        }

        private void BloquearMenu()
        {
            empleadoToolStripMenuItem.Enabled = false;
            departamentoToolStripMenuItem.Enabled = false;
            sucursalToolStripMenuItem.Enabled = false;
            informesToolStripMenuItem.Enabled = false;
            empleadoDesconectadoToolStripMenuItem.Enabled = false;
        }

        private void HabilitarMenu()
        {
            empleadoToolStripMenuItem.Enabled = true;
            departamentoToolStripMenuItem.Enabled = true;
            sucursalToolStripMenuItem.Enabled = true;
            informesToolStripMenuItem.Enabled = true;
            empleadoDesconectadoToolStripMenuItem.Enabled = true;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            using (FrmLogin frmLogin = new FrmLogin())
            {
                frmLogin.ModoABM = false; // 🔐 LOGIN

                if (frmLogin.ShowDialog() == DialogResult.OK)
                    HabilitarMenu();
                else
                    Application.Exit();
            }
        }
    }
}
