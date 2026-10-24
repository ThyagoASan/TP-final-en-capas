using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BESucursal
    {
        #region Administracion Sucursales

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }

        // Relación 1 a muchos con Departamento
        public List<BEDepartamento> ListaDepartamentos { get; set; }

        // Constructor vacío (OBLIGATORIO para DataBinding)
        public BESucursal()
        {
            ListaDepartamentos = new List<BEDepartamento>();
        }

        // Constructor completo
        public BESucursal(int codigo, string nombre, string direccion, string localidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Direccion = direccion;
            Localidad = localidad;
            ListaDepartamentos = new List<BEDepartamento>();
        }

        #endregion

        public override string ToString()
        {
            return $"{Nombre} - {Localidad}";
        }
    }
}

