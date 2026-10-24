using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;

namespace BLL
{
    public class DepartamentoBLL
    {
        MPPDepartamento mppDepartamento;

        public DepartamentoBLL()
        {
            mppDepartamento = new MPPDepartamento();
        }

        public List<BEDepartamento> ListarTodo()
        {
            return mppDepartamento.ListarTodos();
        }

        public bool Guardar(BEDepartamento departamento)
        {
            return mppDepartamento.InsertarDepartamento(departamento);
        }

        public bool Baja(int codigo)
        {
            return mppDepartamento.EliminarDepartamento(codigo);
        }

        // Método para modificar un departamento
        public bool Modificar(BEDepartamento departamentoSeleccionado, BEDepartamento departamento)
        {
            return mppDepartamento.ModificarDepartamento(departamento);
        }
    }
}
