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

namespace TrabajoPracticoAdminEmpleados5Capas
{
    public partial class FrmSucursal : Form
    {
        private SucursalBLL bllSucursal;
        public FrmSucursal()
        {
            InitializeComponent();
            bllSucursal = new SucursalBLL();
            CargarSucursales();

        }

        private void FrmSucursal_Load(object sender, EventArgs e)
        {
            CargarSucursales();
            CargarDepartamentosChecklist();

        }
        private void CargarSucursales()
        {
            var sucursales = bllSucursal.CargarListaSucursales();
            dgvSucursal.DataSource = sucursales;
        }



        private void button1_Click(object sender, EventArgs e) // agregar 
        {
            var sucursal = new BESucursal
            {
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Localidad = textBox2.Text
            };

            bllSucursal.Guardar(sucursal);
            CargarSucursales();
            LimpiarCampos();
        }

        private void button2_Click(object sender, EventArgs e) //Modificar 
        {
            if (dgvSucursal.CurrentRow == null) return;

            var suc = (BESucursal)dgvSucursal.CurrentRow.DataBoundItem;
            if (suc == null) return;

            // Cargar datos en los TextBox
            textBox1.Text = suc.Codigo.ToString();
            txtNombre.Text = suc.Nombre;
            txtDireccion.Text = suc.Direccion;
            textBox2.Text = suc.Localidad;
        }

        private void button3_Click(object sender, EventArgs e)  // Eliminar 
        {
            if (dgvSucursal.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una sucursal");
                return;
            }

            var sucursal = (BESucursal)dgvSucursal.CurrentRow.DataBoundItem;

            bllSucursal.BajaSucursal(sucursal.Codigo);
            CargarSucursales();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvSucursal.CurrentRow == null) return;

            var sucursalSeleccionada =
                (BESucursal)dgvSucursal.CurrentRow.DataBoundItem;

            BESucursal sucursalModificada = new BESucursal
            {
                Codigo = sucursalSeleccionada.Codigo, // NO se toca
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Localidad = textBox2.Text
            };

            if (bllSucursal.Modificar(sucursalSeleccionada, sucursalModificada))
            {
                MessageBox.Show("Sucursal modificada correctamente");
                CargarSucursales();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al modificar");
            }
        }
        private void CargarDepartamentosChecklist()
        {
            var deptos = new DepartamentoBLL().ListarTodo(); // te devuelve List<BEDepartamento>

            checkedListBoxDeptos.DataSource = deptos;
            checkedListBoxDeptos.DisplayMember = "Nombre";
            checkedListBoxDeptos.ValueMember = "Codigo";
        }

        private void dgvSucursal_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSucursal.CurrentRow?.DataBoundItem == null) return;

            var suc = (BESucursal)dgvSucursal.CurrentRow.DataBoundItem;

            // limpiar checks
            for (int i = 0; i < checkedListBoxDeptos.Items.Count; i++)
                checkedListBoxDeptos.SetItemChecked(i, false);

            // traer deptos asociados desde BD (por SP)
            var asociados = new SucursalBLL().ListarDeptosPorSucursal(suc.Codigo);
            // devuelve List<int> codigosDepto

            // marcar los que correspondan
            for (int i = 0; i < checkedListBoxDeptos.Items.Count; i++)
            {
                var dep = (BEDepartamento)checkedListBoxDeptos.Items[i];
                int codDepto = dep.Codigo;
                if (asociados.Contains(codDepto))
                    checkedListBoxDeptos.SetItemChecked(i, true);
            }
        }

        private void btnGuardarRelaciones_Click(object sender, EventArgs e)
        {
            if (dgvSucursal.CurrentRow == null) return;

            var suc = (BESucursal)dgvSucursal.CurrentRow.DataBoundItem;

            var deptosSeleccionados = checkedListBoxDeptos.CheckedItems
                .Cast<BEDepartamento>()
                .Select(d => d.Codigo)
                .ToList();

            new SucursalBLL().GuardarDeptosPorSucursal(suc.Codigo, deptosSeleccionados);

            MessageBox.Show("Relaciones guardadas OK");
        }
    }
}

