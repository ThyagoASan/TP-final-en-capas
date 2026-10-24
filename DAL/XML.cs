using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public class EmpleadoXmlDAL
    {
        public void Guardar(string ruta, List<BEEmpleado> empleados)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<BEEmpleado>));

                using (FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs, new UTF8Encoding(false)))
                {
                    xs.Serialize(sw, empleados);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar empleados en XML.", ex);
            }
        }

        public List<BEEmpleado> Leer(string ruta)
        {
            try
            {
                if (!File.Exists(ruta))
                    return new List<BEEmpleado>();

                XmlSerializer xs = new XmlSerializer(typeof(List<BEEmpleado>));

                using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    return (List<BEEmpleado>)xs.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer empleados desde XML.", ex);
            }
        }
    }
}

