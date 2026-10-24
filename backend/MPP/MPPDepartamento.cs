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
    public class MPPDepartamento
    {

        private Acceso oAcceso;
        public MPPDepartamento()
        {
            oAcceso = new Acceso();
        }
        public List<BEDepartamento> ListarTodos()
        {
            List<BEDepartamento> ListaDepartamentos = new List<BEDepartamento>();

            string query = "SELECT Codigo, Nombre,Categoria, CantidadAulas, CantidadCarreras FROM Departamento";
            DataTable tabla = oAcceso.LeerBase(query);

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    BEDepartamento departamento = null;

                    string tipoDepartamento = fila["Categoria"].ToString().Trim();

                    if (tipoDepartamento == "Colegio")
                    {
                        departamento = new BEColegio
                        {
                            Codigo = Convert.ToInt32(fila["Codigo"]),
                            Nombre = fila["Nombre"].ToString(),
                            Categoria = fila["Categoria"].ToString(), // ✅
                            CantidadAulas = fila["CantidadAulas"] == DBNull.Value ? 0 : Convert.ToInt32(fila["CantidadAulas"])
                        };
                    }
                    else if (tipoDepartamento == "Facultad")
                    {
                        departamento = new BEFacultad
                        {
                            Codigo = Convert.ToInt32(fila["Codigo"]),
                            Nombre = fila["Nombre"].ToString(),
                            Categoria = fila["Categoria"].ToString(), // ✅
                            CantidadCarreras = fila["CantidadCarreras"] == DBNull.Value ? 0 : Convert.ToInt32(fila["CantidadCarreras"])
                        };
                    }

                    if (departamento != null)
                    {
                        ListaDepartamentos.Add(departamento);
                    }
                }
            }

            return ListaDepartamentos;
        }

        public bool InsertarDepartamento(BEDepartamento depto)
        {
            int cantAulas = 0;
            int cantCarreras = 0;
            string categoria = depto.Categoria;

            if (depto is BEColegio col)
            {
                categoria = "Colegio";
                cantAulas = col.CantidadAulas;
                cantCarreras = 0;
            }
            else if (depto is BEFacultad fac)
            {
                categoria = "Facultad";
                cantAulas = 0;
                cantCarreras = fac.CantidadCarreras;
            }

            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@Nombre", depto.Nombre),
        new SqlParameter("@Categoria", categoria),
        new SqlParameter("@CantidadAulas", cantAulas),
        new SqlParameter("@CantidadCarreras", cantCarreras)
    };

            return oAcceso.EjecutarSP("sp_Departamento_Insert", parametros) > 0;
        }

        public bool ModificarDepartamento(BEDepartamento depto)
        {
            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@Codigo", depto.Codigo),
        new SqlParameter("@Nombre", depto.Nombre),
        new SqlParameter("@Categoria", depto.Categoria),
    };

            int cantidadAulas = 0;
            int cantidadCarreras = 0;

            if (depto is BEColegio col)
                cantidadAulas = col.CantidadAulas;
            else if (depto is BEFacultad fac)
                cantidadCarreras = fac.CantidadCarreras;

            parametros.Add(new SqlParameter("@CantidadAulas", cantidadAulas));
            parametros.Add(new SqlParameter("@CantidadCarreras", cantidadCarreras));

            return oAcceso.EjecutarSP("sp_Departamento_Update", parametros) > 0;
        }

        public bool EliminarDepartamento(int codigo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Codigo", codigo)
            };

            return oAcceso.EjecutarSP("sp_Departamento_Delete", parametros) > 0;
        }
    }

}





        /* public bool InsertarDepartamento(BEDepartamento departamento)
         {
             string query = "";

             if (departamento is BEColegio colegio)
             {
                 query =
                        "INSERT INTO Departamentoo (Nombre, Categoria, CantidadAulas, CantidadCarreras) " +
                         $"VALUES ('{colegio.Nombre}', 'Colegio', {colegio.CantidadAulas}, 0)";
             }
             else if (departamento is BEFacultad facultad)
             {
                 query =
                        "INSERT INTO Departamentoo (Nombre, Categoria, CantidadAulas, CantidadCarreras) " +
                         $"VALUES ('{facultad.Nombre}', 'Facultad', 0, {facultad.CantidadCarreras})";
             }

             return oAcceso.Escribir(query);
         }
         */
       /* public bool ModificarDepartamento(BEDepartamento departamento)
        {
            string query = "";

            if (departamento is BEColegio colegio)
            {
                query = $"UPDATE Departamentoo SET Nombre = '{colegio.Nombre}', CantidadAulas = {colegio.CantidadAulas} " +
                        $"WHERE Codigo = {colegio.Codigo}";
            }
            else if (departamento is BEFacultad facultad)
            {
                query = $"UPDATE Departamentoo SET Nombre = '{facultad.Nombre}', CantidadCarreras = {facultad.CantidadCarreras} " +
                        $"WHERE Codigo = {facultad.Codigo}";
            }

            return oAcceso.Escribir(query);
        }
        */
        /* public bool EliminarDepartamento(int codigo)
         {
             string query = $"DELETE FROM Departamentoo WHERE Codigo = {codigo}";
             return oAcceso.Escribir(query);
         }
         */