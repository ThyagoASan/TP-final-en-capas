using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEFacultad : BEDepartamento
    {
        public int CantidadCarreras { get; set; }
        public BEFacultad() { }
        public BEFacultad(int codigo, string nombre, int cantidadCarreras) : base(codigo, nombre, "Facultad") { CantidadCarreras = cantidadCarreras; }
        public override string ToString()
        {
            return $"{Nombre} (Facultad)";
        }
    }
}
