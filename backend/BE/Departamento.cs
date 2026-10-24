using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEDepartamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }

        public BEDepartamento() { }
        public BEDepartamento(int codigo, string nombre, string categoria)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
        }

        public override string ToString() => $"{Nombre} ({Codigo} )";
    }
}
