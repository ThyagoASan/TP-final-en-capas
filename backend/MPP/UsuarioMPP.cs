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
    public class MPPUsuario
    {
        private Acceso oAcceso;
        public MPPUsuario()
        {
            oAcceso = new Acceso();
        }
        public bool ValidarUsuario(BEUsuario u)
        {
            // Ideal: SP sp_Usuario_Validar. Si no querés agregarlo,
            // al menos parametrizá. Mejor con SP:
            var param = new List<SqlParameter>
            {
                new SqlParameter("@NombreUsuario", u.NombreUsuario),
                new SqlParameter("@Clave", u.Clave)
            };

            var dt = oAcceso.LeerSP("sp_Usuario_Validar", param);
            return dt.Rows.Count > 0; // o COUNT(*)
        }

        public List<BEUsuario> Listar()
        {
            var dt = oAcceso.LeerSP("sp_Usuario_Listar");
            var lista = new List<BEUsuario>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new BEUsuario
                {
                    Codigo = Convert.ToInt32(row["Codigo"]),
                    NombreUsuario = row["NombreUsuario"].ToString(),
                    Clave = row["Clave"].ToString()
                });
            }

            return lista;
        }

        public bool Insertar(BEUsuario u)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@NombreUsuario", u.NombreUsuario),
                new SqlParameter("@Clave", u.Clave)
            };

            return oAcceso.EjecutarSP("sp_Usuario_Insert", param) > 0;
        }

        public bool Modificar(BEUsuario u)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id", u.Codigo),
                new SqlParameter("@NombreUsuario", u.NombreUsuario),
                new SqlParameter("@Clave", u.Clave)
            };

            return oAcceso.EjecutarSP("sp_Usuario_Update", param) > 0;
        }

        public bool Eliminar(int codigo)
        {
            var param = new List<SqlParameter>
            {
                 new SqlParameter("@Id", codigo)
            };

            return oAcceso.EjecutarSP("sp_Usuario_Delete", param) > 0;
        }

    }

}
