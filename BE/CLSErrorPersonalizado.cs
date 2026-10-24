using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CLSErrorPersonalizado : Exception
    {
        public enum Error
        {
            CampoVacio = 1,
            RegistroNoEncontrado = 2,
            EliminacionFallida = 3,
            // Agrega otros tipos de error aquí
        }

        public Error _Error { get; private set; }

        public CLSErrorPersonalizado(Error _error)
        {
            _Error = _error;
        }

        public CLSErrorPersonalizado(int v)
        {
        }
        public override string Message
        {
            get
            {
                switch (_Error)
                {
                    case Error.CampoVacio:
                        return "Uno o más campos están vacíos.";
                    case Error.RegistroNoEncontrado:
                        return "El registro solicitado no se encontró.";
                    case Error.EliminacionFallida:
                        return "No se pudo eliminar el registro.";
                    // Agrega otros mensajes de error aquí
                    default:
                        return "Se ha producido un error desconocido.";
                }
            }
        }

    }
}
