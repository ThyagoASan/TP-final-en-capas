using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUsuario
    {
        public int Codigo { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }

        public BEUsuario() { }

        public BEUsuario(int codigo, string nombreUsuario, string clave)
        {
            Codigo = codigo;
            NombreUsuario = nombreUsuario;
            Clave = clave;
        }

    }
}
