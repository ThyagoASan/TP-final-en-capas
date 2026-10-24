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
using System.Windows.Forms.DataVisualization.Charting;

namespace TrabajoPracticoAdminEmpleados5Capas
{
    public partial class frminformes : Form
    {
        public frminformes()
        {
            InitializeComponent();
            CargarTiposDeInforme();

            // Recomendado: iniciar visible solo el grid
            dgvInformes.Visible = true;
            chart1.Visible = false;
        }
        private void CargarTiposDeInforme()
        {
            cmbinformes.Items.Clear();
            cmbinformes.Items.Add("Informe de Empleados");
            cmbinformes.Items.Add("Informe de Departamentos");
            cmbinformes.Items.Add("Informe de Sucursales");
            cmbinformes.Items.Add("Chart - Empleados por Departamento");

            cmbinformes.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string tipoInforme = cmbinformes.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(tipoInforme))
            {
                MessageBox.Show("Por favor, selecciona un tipo de informe.");
                return;
            }

            switch (tipoInforme)
            {
                case "Informe de Empleados":
                    chart1.Visible = false;
                    dgvInformes.Visible = true;
                    GenerarInformeEmpleados();
                    break;

                case "Informe de Departamentos":
                    chart1.Visible = false;
                    dgvInformes.Visible = true;
                    GenerarInformeDepartamentos();
                    break;

                case "Informe de Sucursales":
                    chart1.Visible = false;
                    dgvInformes.Visible = true;
                    GenerarInformeSucursales();
                    break;

                case "Chart - Empleados por Departamento":
                    dgvInformes.Visible = false;
                    chart1.Visible = true;
                    GenerarChartEmpleadosPorDepartamento();
                    break;

                default:
                    MessageBox.Show("Tipo de informe no reconocido.");
                    break;
            }
        }
        private void GenerarChartEmpleadosPorDepartamento()
        {
            var empleados = new BLLEmpleado().ListarTodo(); // ya lo usás :contentReference[oaicite:2]{index=2}

            var data = empleados
                .Where(e => e.IdDepartamento != null)
                .GroupBy(e => e.IdDepartamento.Nombre)
                .Select(g => new { Departamento = g.Key, Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad)
                .ToList();

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            chart1.ChartAreas.Add(new ChartArea("Main"));
            chart1.Titles.Add("Empleados por Departamento");

            var serie = new Series("Cantidad")
            {
                ChartType = SeriesChartType.Column, // barras
                XValueMember = "Departamento",
                YValueMembers = "Cantidad",
                IsValueShownAsLabel = true
            };

            chart1.Series.Add(serie);

            foreach (var item in data)
                chart1.Series["Cantidad"].Points.AddXY(item.Departamento, item.Cantidad);
        }
        private void GenerarInformeEmpleados()
        {
            // Lógica para obtener y mostrar datos de empleados
            // Ejemplo: llamando a una BLL para obtener una lista de empleados
            var empleados = new BLLEmpleado().ListarTodo(); // Supone que tienes un método que obtiene todos los empleados

            // Mostrar en un DataGridView
            dgvInformes.DataSource = empleados; // Supone que tienes un DataGridView llamado dgvInformes

            MessageBox.Show("Informe de empleados generado exitosamente.");
        }
        private void GenerarInformeDepartamentos()
        {
            // Lógica para obtener y mostrar datos de departamentos
            var departamentos = new DepartamentoBLL().ListarTodo(); // Método para obtener todos los departamentos

            // Mostrar en un DataGridView
            dgvInformes.DataSource = departamentos; // Muestra en el mismo DataGridView

            MessageBox.Show("Informe de departamentos generado exitosamente.");
        }
        private void GenerarInformeSucursales()
        {
            // Lógica para obtener y mostrar datos de sucursales
            var sucursales = new SucursalBLL().CargarListaSucursales(); // Método para obtener todas las sucursales

            // Mostrar en un DataGridView
            dgvInformes.DataSource = sucursales; // Muestra en el mismo DataGridView

            MessageBox.Show("Informe de sucursales generado exitosamente.");
        }
    }
}
