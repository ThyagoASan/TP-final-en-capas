using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLLEmpleado : ICloneable
    {
        private EmpleadoXmlDAL xmlDal = new EmpleadoXmlDAL();
        MPPEmpleado mppEmpleado;

        public BLLEmpleado()
        {
            mppEmpleado = new MPPEmpleado();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public List<BEEmpleado> ListarTodo()
        {
            return mppEmpleado.ListarTodo();
        }

        public bool Guardar(BEEmpleado empleado)
        {
            return mppEmpleado.GuardarEmpleado(empleado);
        }

        // Método para eliminar un empleado
        public bool Baja(int codigo)
        {
            return mppEmpleado.EliminarEmpleado(codigo);
        }

        // Método para modificar un empleado
        public bool Modificar(BEEmpleado empleadoSeleccionado, BEEmpleado empleado)
        {
            return mppEmpleado.ModificarEmpleado(empleado);
        }
        public void ExportarXml(string ruta)
        {
            var lista = mppEmpleado.ListarTodo();

            foreach (var emp in lista)
                emp.IdDepartamentoCodigo = emp.IdDepartamento?.Codigo ?? 0;

            xmlDal.Guardar(ruta, lista);
        }

        public List<BEEmpleado> ImportarXml(string ruta)
        {
            var lista = xmlDal.Leer(ruta);

            var departamentos = new DepartamentoBLL().ListarTodo();

            foreach (var emp in lista)
                emp.IdDepartamento = departamentos.FirstOrDefault(d => d.Codigo == emp.IdDepartamentoCodigo);

            return lista;
        }
    }
}
