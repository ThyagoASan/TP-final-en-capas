using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class BEEmpleado
    {
        #region Administracion Empleado
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public decimal Salario { get; set; }
        public int IdDepartamentoCodigo { get; set; }

        //Relacion 1 a 1
        [XmlIgnore]
        public BEDepartamento IdDepartamento { get; set; }
        #endregion
        public BEEmpleado() { }
        public BEEmpleado(int codigo, string nombre, string apellido, decimal salario, int dni, BEDepartamento departamento)
        {
            Codigo = codigo;
            Nombre = nombre;
            Apellido = apellido;
            Salario = salario;
            Dni = dni;
            IdDepartamento = departamento;
        }
        public override string ToString()
        {
            return $"{Nombre} {Apellido}, DNI: {Dni}, Salario: {Salario:C}, Departamento: {IdDepartamento?.Nombre}";
        }
    }
}
