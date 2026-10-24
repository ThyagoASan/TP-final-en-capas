using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;


namespace BLL
{
    public class SucursalBLL
    {
        public SucursalBLL()
        {
            oMPPSucu = new MPPSucursal();
        }

        MPPSucursal oMPPSucu;

        public List<BESucursal> CargarListaSucursales()
        {
            return oMPPSucu.ListarTodo();
        }

        public bool Guardar(BESucursal oBESucursal)
        {
            return oMPPSucu.GuardarSucursal(oBESucursal);
        }
        public bool BajaSucursal(int codigo)
        {
            return oMPPSucu.EliminarSucursal(codigo);
        }
        public bool Modificar(BESucursal sucursalselecionada, BESucursal sucursal)
        {
            return oMPPSucu.ModificarSucursal(sucursal);
        }


        // RELACIÓN N a N (Sucursal <-> Departamentos)


        // 1) listar códigos de departamentos de una sucursal (usa SP)
        public List<int> ListarDeptosPorSucursal(int idSucursal)
        {
            return oMPPSucu.ListarDeptosPorSucursal(idSucursal);
        }

        // 2) guardar relación (borrar todo + insertar lo seleccionado) (usa SP)
        public void GuardarDeptosPorSucursal(int idSucursal, List<int> deptos)
        {
            oMPPSucu.BorrarRelacionesSucursal(idSucursal);  // SP delete by sucursal

            foreach (int idDepto in deptos)
                oMPPSucu.InsertarRelacion(idSucursal, idDepto); // SP insert
        }
    }
}
