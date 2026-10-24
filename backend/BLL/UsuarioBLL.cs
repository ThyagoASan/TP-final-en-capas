using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MPP;

namespace BLL
{
    public class UsuarioBLL
    {
        MPPUsuario mpp;
        public UsuarioBLL()
        {
            mpp = new MPPUsuario();
        }
        public List<BEUsuario> Listar() => mpp.Listar();

        public bool Alta(string nombreUsuario, string clavePlano)
        {
            var u = new BEUsuario
            {
                NombreUsuario = nombreUsuario,
                Clave = EncriptarClave(clavePlano)
            };
            return mpp.Insertar(u);
        }
        public bool Modificar(int codigo, string nombreUsuario, string clavePlano)
        {
            var u = new BEUsuario
            {
                Codigo = codigo,
                NombreUsuario = nombreUsuario,
                Clave = EncriptarClave(clavePlano)
            };
            return mpp.Modificar(u);
        }
        public bool Baja(int codigo) => mpp.Eliminar(codigo);

        public bool ValidarUsuario(BEUsuario u) => mpp.ValidarUsuario(u);

        public string EncriptarClave(string clave)
        {
            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(clave));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public bool HayUsuarios()
        {
            return Listar().Count > 0;
        }
    }
}
