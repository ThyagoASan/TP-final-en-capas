using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    public class Acceso
    {

        public SqlConnection oCnn = new SqlConnection(@"Data Source =.; Initial Catalog = BaseDatos2; Integrated Security = True; TrustServerCertificate=True");
        SqlCommand cmd;
        SqlTransaction tranx;

        public bool LeerScalar(string consulta)
        {
            oCnn.Open();
            //uso el constructor del objeto Command
            SqlCommand cmd = new SqlCommand(consulta, oCnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                oCnn.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex; }
        }

        public bool Escribir(string consulta)
        {
            oCnn.Open();

            cmd = new SqlCommand(consulta, oCnn);
            cmd.CommandType = CommandType.Text;
            tranx = oCnn.BeginTransaction();
            cmd.Transaction = tranx;

            try
            {

                int respuesta = cmd.ExecuteNonQuery();
                tranx.Commit();
                return true;

            }
            catch (SqlException ex)
            {
                tranx.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                tranx.Rollback();
                throw ex;
            }
            finally
            {
                oCnn.Close();
            }

        }
        public int EjecutarSP(string spName, List<SqlParameter> parametros)
        {
            using (SqlConnection cnn = new SqlConnection(@"Data Source=./; Initial Catalog=BaseDatos2; Integrated Security=True; TrustServerCertificate=True"))
            using (SqlCommand cmd = new SqlCommand(spName, cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros.ToArray());

                cnn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public DataTable LeerSP(string spName, List<SqlParameter> parametros = null)
        {
            using (SqlConnection cnn = new SqlConnection(@"Data Source=.; Initial Catalog=BaseDatos2; Integrated Security=True; TrustServerCertificate=True"))
            using (SqlCommand cmd = new SqlCommand(spName, cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros.ToArray());

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable LeerBase(string Consulta)
        {
            DataTable tabla = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(Consulta, oCnn);
                da.Fill(tabla);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCnn.Close();
            }
            return tabla;
        }
        public bool VerificarCreedenciales(string consulta)
        {
            try
            {
                oCnn.Open();
                cmd = new SqlCommand(consulta, oCnn);
                cmd.CommandType = CommandType.Text;

                int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                return (Convert.ToInt32(cmd.ExecuteScalar()) > 0);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCnn.Close();
            }

        }
    }
}
