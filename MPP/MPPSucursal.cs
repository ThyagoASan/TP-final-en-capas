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
    public class MPPSucursal
    {
        private Acceso oAcceso;

        public MPPSucursal()
        {
            oAcceso = new Acceso();
        }

        public List<BESucursal> ListarTodo()
        {
            List<BESucursal> ListaSucursales = new List<BESucursal>();

            string query = @"SELECT s.Codigo,s.Nombre, s.Direccion,s.Localidad,d.Codigo AS CodDepartamento,d.Nombre AS NomDepartamento, d.Categoria, d.CantidadAulas,
                           d.CantidadCarreras FROM Sucursal s LEFT JOIN DepartamentoSucursales ds ON ds.IdSucursal = s.Codigo LEFT JOIN Departamento d ON d.Codigo = ds.IdDepartamento";

            DataTable tabla = oAcceso.LeerBase(query);

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    // Revisamos si ya existe la sucursal en la lista
                    BESucursal sucursal = ListaSucursales.FirstOrDefault(s => s.Codigo == Convert.ToInt32(fila["Codigo"]));

                    if (sucursal == null)
                    {
                        // Si no existe, la creamos y la agregamos a la lista
                        sucursal = new BESucursal
                        {
                            Codigo = Convert.ToInt32(fila["Codigo"]),
                            Nombre = fila["Nombre"].ToString(),
                            Direccion = fila["Direccion"].ToString(),
                            Localidad = fila["Localidad"].ToString()
                        };
                        ListaSucursales.Add(sucursal);
                    }

                    // Creamos el departamento asociado a la sucursal
                    BEDepartamento departamento = null;

                    string tipoDepartamento = fila["Categoria"].ToString();

                    if (tipoDepartamento == "Colegio")
                    {
                        departamento = new BEColegio
                        {
                            Codigo = Convert.ToInt32(fila["CodDepartamento"]),
                            Nombre = fila["NomDepartamento"].ToString(),
                            CantidadAulas = Convert.ToInt32(fila["CantidadAulas"])
                        };
                    }
                    else if (tipoDepartamento == "Facultad")
                    {
                        departamento = new BEFacultad
                        {
                            Codigo = Convert.ToInt32(fila["CodDepartamento"]),
                            Nombre = fila["NomDepartamento"].ToString(),
                            CantidadCarreras = Convert.ToInt32(fila["CantidadCarreras"])
                        };
                    }

                    // Agregamos el departamento a la sucursal
                    if (departamento != null)
                    {
                        sucursal.ListaDepartamentos.Add(departamento);
                    }
                }
            }

            return ListaSucursales;
        }

        public bool GuardarSucursal(BESucursal sucursal)
        {
            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@Nombre", sucursal.Nombre),
        new SqlParameter("@Direccion", sucursal.Direccion),
        new SqlParameter("@Localidad", sucursal.Localidad)
    };

            return oAcceso.EjecutarSP("sp_Sucursal_Insert", parametros) > 0;
        }

        public bool ModificarSucursal(BESucursal sucursal)
        {
            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@Codigo", sucursal.Codigo),
        new SqlParameter("@Nombre", sucursal.Nombre),
        new SqlParameter("@Direccion", sucursal.Direccion),
        new SqlParameter("@Localidad", sucursal.Localidad)
    };

            return oAcceso.EjecutarSP("sp_Sucursal_Update", parametros) > 0;
        }

        public bool EliminarSucursal(int codigo)
        {
            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@Codigo", codigo)
    };

            return oAcceso.EjecutarSP("sp_Sucursal_Delete", parametros) > 0;
        }

        public void BorrarRelacionesSucursal(int idSucursal)
        {
            oAcceso.EjecutarSP("sp_DepartamentoSucursal_DeleteBySucursal",
                new List<SqlParameter> { new SqlParameter("@IdSucursal", idSucursal) });
        }

        public void InsertarRelacion(int idSucursal, int idDepartamento)
        {
            oAcceso.EjecutarSP("sp_DepartamentoSucursal_Insert",
                new List<SqlParameter> {
            new SqlParameter("@IdSucursal", idSucursal),
            new SqlParameter("@IdDepartamento", idDepartamento)
                });
        }

        public List<int> ListarDeptosPorSucursal(int idSucursal)
        {
            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@IdSucursal", idSucursal)
    };

            var dt = oAcceso.LeerSP("sp_DepartamentoSucursal_ListarPorSucursal", parametros);

            return dt.AsEnumerable()
                     .Select(r => Convert.ToInt32(r["idDepartamento"]))
                     .ToList();
        }
    }


}




/*public bool GuardarSucursal(BESucursal sucursal)
{
    string query =
    $"INSERT INTO Sucursal (Nombre, Localidad, Direccion) " +
    $"VALUES ('{sucursal.Nombre}', '{sucursal.Localidad}', '{sucursal.Direccion}')";

    return oAcceso.Escribir(query);
}
*/

/*public bool ModificarSucursal(BESucursal sucursal)
{
    string query =
$"UPDATE Sucursal SET " +
$"Nombre = '{sucursal.Nombre}', " +
$"Localidad = '{sucursal.Localidad}', " +
$"Direccion = '{sucursal.Direccion}' " +
$"WHERE Codigo = {sucursal.Codigo}";

    return oAcceso.Escribir(query);
}*/

/*public bool EliminarSucursal(int codigo)
{
    string query = $"DELETE FROM Sucursal WHERE Codigo = {codigo}";
    return oAcceso.Escribir(query);
}
*/