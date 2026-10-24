using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPEmpleado
    {
        private Acceso oAcceso;

        public MPPEmpleado()
        {
            oAcceso = new Acceso();
        }

        public List<BEEmpleado> ListarTodo()
        {
            List<BEEmpleado> lista = new List<BEEmpleado>();

            string Query = @"SELECT e.Codigo, e.Nombre, e.Apellido, e.Dni, e.Salario, e.IdDepartamento,
                            d.Codigo AS DepCodigo, d.Nombre AS DepNombre, d.Categoria
                     FROM Empleado e
                     INNER JOIN Departamento d ON e.IdDepartamento = d.Codigo";

            DataTable tabla = oAcceso.LeerBase(Query);

            foreach (DataRow Fila in tabla.Rows)
            {
                BEEmpleado empleado = new BEEmpleado
                {
                    Codigo = Convert.ToInt32(Fila["Codigo"]),
                    Nombre = Fila["Nombre"].ToString(),
                    Apellido = Fila["Apellido"].ToString(),
                    Dni = Convert.ToInt32(Fila["Dni"]),
                    Salario = Convert.ToDecimal(Fila["Salario"]),

                    // ✅ ESTA LÍNEA ES LA CLAVE (para que en el grid no salga 0)
                    IdDepartamentoCodigo = Convert.ToInt32(Fila["IdDepartamento"])
                    // también podrías usar DepCodigo, es lo mismo:
                    // IdDepartamentoCodigo = Convert.ToInt32(Fila["DepCodigo"])
                };

                string cat = Fila["Categoria"].ToString();

                if (cat == "Colegio")
                {
                    empleado.IdDepartamento = new BEColegio
                    {
                        Codigo = Convert.ToInt32(Fila["DepCodigo"]),
                        Nombre = Fila["DepNombre"].ToString(),
                        Categoria = "Colegio"
                    };
                }
                else if (cat == "Facultad")
                {
                    empleado.IdDepartamento = new BEFacultad
                    {
                        Codigo = Convert.ToInt32(Fila["DepCodigo"]),
                        Nombre = Fila["DepNombre"].ToString(),
                        Categoria = "Facultad"
                    };
                }

                // ✅ (opcional pero recomendado) asegurar consistencia:
                if (empleado.IdDepartamento != null)
                    empleado.IdDepartamentoCodigo = empleado.IdDepartamento.Codigo;

                lista.Add(empleado);
            }

            return lista;
        }
        public bool GuardarEmpleado(BEEmpleado empleado)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Nombre", empleado.Nombre),
                new SqlParameter("@Apellido", empleado.Apellido),
                new SqlParameter("@Dni", empleado.Dni),
                new SqlParameter("@Salario", empleado.Salario),
                new SqlParameter("@IdDepartamento", empleado.IdDepartamento.Codigo)
            };

            return oAcceso.EjecutarSP("sp_Empleado_Insert", parametros) > 0;
        }

        public bool ModificarEmpleado(BEEmpleado empleado)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Codigo", empleado.Codigo),
                new SqlParameter("@Nombre", empleado.Nombre),
                new SqlParameter("@Apellido", empleado.Apellido),
                new SqlParameter("@Dni", empleado.Dni),
                new SqlParameter("@Salario", empleado.Salario),
                new SqlParameter("@IdDepartamento", empleado.IdDepartamento.Codigo)
            };

            return oAcceso.EjecutarSP("sp_Empleado_Update", parametros) > 0;
        }

        public bool EliminarEmpleado(int codigo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Codigo", codigo)
            };

            return oAcceso.EjecutarSP("sp_Empleado_Delete", parametros) > 0;
        }

    }


}





 /*  public bool EliminarEmpleado(int codigo)
        {
            string query = string.Format("DELETE FROM Empleado WHERE Codigo = {0}", codigo);
            return oAcceso.Escribir(query);
        }*/

/* public bool ModificarEmpleado(BEEmpleado empleado)
        {
            string query = string.Format(
    "UPDATE Empleado SET " +
    "Nombre = '{0}', Apellido = '{1}', Dni = {2}, Salario = {3}, IdDepartamento = {4} " +
    "WHERE Codigo = {5}",
    empleado.Nombre,
    empleado.Apellido,
    empleado.Dni,
    empleado.Salario,
    empleado.IdDepartamento.Codigo,  // ✅ CLAVE
    empleado.Codigo
);

            return oAcceso.Escribir(query);
        }
        */

/*public bool GuardarEmpleado(BEEmpleado empleado)
{
    string query = string.Format(
"INSERT INTO Empleado (Nombre, Apellido, Dni, Salario, IdDepartamento) " +
"VALUES ('{0}', '{1}', {2}, {3}, {4})",
empleado.Nombre,
empleado.Apellido,
empleado.Dni,
empleado.Salario,
empleado.IdDepartamento.Codigo   // ✅ CLAVE: el int real
);

    return oAcceso.Escribir(query);
}*/