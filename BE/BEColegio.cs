using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEColegio : BEDepartamento
    {
        public int CantidadAulas { get; set; }

        // Constructor vacío (necesario)
        public BEColegio() { }

        // Constructor COMPLETO (el importante)
        public BEColegio(int codigo, string nombre, int cantidadAulas)
            : base(codigo, nombre, "Colegio")
        {
            CantidadAulas = cantidadAulas;
        }

        public override string ToString()
        {
            return $"{Nombre} (Colegio)";
        }


    }
}
