using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace TrabajoPracticoAdminEmpleados5Capas
{
    public partial class FrmEmpleadoDesconectado : Form
    {
        private readonly string _cnnStr =
            @"Data Source=.;Initial Catalog=BaseDatos2;Integrated Security=True;TrustServerCertificate=True";

        private SqlDataAdapter _da;
        private DataTable _dt;
        private BindingSource _bs;

        public FrmEmpleadoDesconectado()
        {
            InitializeComponent();
            this.Load += FrmEmpleadoDesconectado_Load;
        }

        private void FrmEmpleadoDesconectado_Load(object sender, EventArgs e)
        {
            CargarDesconectado();

            txtFiltroNombre.TextChanged += (s, ev) => AplicarFiltro();
            txtFiltroDni.TextChanged += (s, ev) => AplicarFiltro();
        }

        private void CargarDesconectado()
        {
            try
            {
                using (var cnn = new SqlConnection(_cnnStr))
                {
                    // Adapter
                    _da = new SqlDataAdapter(
                        @"SELECT Codigo, Nombre, Apellido, Dni, Salario, IdDepartamento
                  FROM Empleado", cnn);

                    // Traer esquema (PK incluida)
                    _da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    // DataTable
                    _dt = new DataTable("Empleado");

                    // Primero esquema
                    _da.FillSchema(_dt, SchemaType.Source);

                    // Luego datos
                    _da.Fill(_dt);

                    // Ajustar columna Codigo
                    if (_dt.Columns.Contains("Codigo"))
                    {
                        var colCodigo = _dt.Columns["Codigo"];

                        // Permitimos asignar valores temporales en memoria
                        colCodigo.ReadOnly = false;
                    }

                    // BindingSource
                    _bs = new BindingSource();
                    _bs.DataSource = _dt;

                    // Grid
                    dgvEmpleadosDesc.AutoGenerateColumns = true;
                    dgvEmpleadosDesc.DataSource = _bs;

                    dgvEmpleadosDesc.AllowUserToAddRows = false;
                    dgvEmpleadosDesc.AllowUserToDeleteRows = false;

                    dgvEmpleadosDesc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEmpleadosDesc.MultiSelect = false;

                    // Bloquear edición de Codigo en UI
                    if (dgvEmpleadosDesc.Columns["Codigo"] != null)
                    {
                        dgvEmpleadosDesc.Columns["Codigo"].ReadOnly = true;
                    }

                    // Crear comandos Update/Delete automáticamente
                    SqlCommandBuilder cb = new SqlCommandBuilder(_da);

                    _da.UpdateCommand = cb.GetUpdateCommand();
                    _da.DeleteCommand = cb.GetDeleteCommand();

                    // Insert manual
                    ConfigurarComandosAdapter(cnn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando empleados (desconectado): " + ex.Message);
            }
        }

        private void ConfigurarComandosAdapter(SqlConnection cnn)
        {
            _da.InsertCommand = new SqlCommand(@"
            INSERT INTO Empleado (Nombre, Apellido, Dni, Salario, IdDepartamento)
            OUTPUT INSERTED.Codigo
            VALUES (@Nombre, @Apellido, @Dni, @Salario, @IdDepartamento);", cnn);

            _da.InsertCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50, "Nombre");
            _da.InsertCommand.Parameters.Add("@Apellido", SqlDbType.VarChar, 50, "Apellido");
            _da.InsertCommand.Parameters.Add("@Dni", SqlDbType.Int, 0, "Dni");

            var pSal = _da.InsertCommand.Parameters.Add("@Salario", SqlDbType.Decimal, 0, "Salario");
            pSal.Precision = 18;
            pSal.Scale = 2;

            _da.InsertCommand.Parameters.Add("@IdDepartamento", SqlDbType.Int, 0, "IdDepartamento");
            _da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;

            var cb = new SqlCommandBuilder(_da);
            _da.UpdateCommand = cb.GetUpdateCommand(true);
            _da.DeleteCommand = cb.GetDeleteCommand(true);
        }

        private void AplicarFiltro()
        {
            if (_bs == null) return;

            string nombre = (txtFiltroNombre.Text ?? "").Replace("'", "''").Trim();
            string dni = (txtFiltroDni.Text ?? "").Trim();

            string filtro = "1=1";

            if (!string.IsNullOrEmpty(nombre))
                filtro += $" AND (Nombre LIKE '%{nombre}%' OR Apellido LIKE '%{nombre}%')";

            if (!string.IsNullOrEmpty(dni) && int.TryParse(dni, out _))
                filtro += $" AND Convert(Dni, 'System.String') LIKE '%{dni}%'";

            _bs.Filter = filtro;
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltroNombre.Clear();
            txtFiltroDni.Clear();
            _bs?.RemoveFilter();
        }

        private int ObtenerIdDepartamentoDefault()
        {
            using (var cnn = new SqlConnection(_cnnStr))
            using (var cmd = new SqlCommand("SELECT TOP 1 Codigo FROM Departamento ORDER BY Codigo", cnn))
            {
                cnn.Open();
                object val = cmd.ExecuteScalar();
                return (val == null || val == DBNull.Value) ? 0 : Convert.ToInt32(val);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (_dt == null) return;

            int idDep = ObtenerIdDepartamentoDefault();
            if (idDep == 0)
            {
                MessageBox.Show("No hay departamentos cargados en la BD. Cargá uno antes de crear empleados.");
                return;
            }

            DataRow nueva = _dt.NewRow();

            // Generar Codigo temporal negativo y único
            int nuevoCodigo = -1;

            var codigosNegativos = _dt.AsEnumerable()
                .Where(r => r.RowState != DataRowState.Deleted)
                .Select(r => Convert.ToInt32(r["Codigo"]))
                .Where(c => c < 0);

            if (codigosNegativos.Any())
                nuevoCodigo = codigosNegativos.Min() - 1;

            nueva["Codigo"] = nuevoCodigo;
            nueva["Nombre"] = "";
            nueva["Apellido"] = "";
            nueva["Dni"] = 0;
            nueva["Salario"] = 0m;
            nueva["IdDepartamento"] = idDep;

            _dt.Rows.Add(nueva);
            _bs.MoveLast();
        }

        private void btnBorrarFila_Click(object sender, EventArgs e)
        {
            if (dgvEmpleadosDesc.CurrentRow == null) return;

            var drv = dgvEmpleadosDesc.CurrentRow.DataBoundItem as DataRowView;
            drv?.Row.Delete();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (_da == null || _dt == null) return;

            try
            {
                dgvEmpleadosDesc.EndEdit();
                _bs.EndEdit();

                using (var cnn = new SqlConnection(_cnnStr))
                {
                    cnn.Open();
                    using (var tx = cnn.BeginTransaction())
                    {
                        _da.SelectCommand.Connection = cnn;
                        _da.SelectCommand.Transaction = tx;

                        _da.InsertCommand.Connection = cnn;
                        _da.UpdateCommand.Connection = cnn;
                        _da.DeleteCommand.Connection = cnn;

                        _da.InsertCommand.Transaction = tx;
                        _da.UpdateCommand.Transaction = tx;
                        _da.DeleteCommand.Transaction = tx;

                        int filas = _da.Update(_dt);
                        tx.Commit();

                        MessageBox.Show("Cambios guardados correctamente. Filas afectadas: " + filas);

                        _dt.Clear();
                        _da.Fill(_dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando cambios: " + ex.Message);
            }
        }

        private void btnCancelarCambios_Click(object sender, EventArgs e)
        {
            if (_dt == null) return;

            _dt.RejectChanges();
            MessageBox.Show("Cambios cancelados.");
        }
    }
}
