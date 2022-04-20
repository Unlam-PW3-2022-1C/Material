using System;
using System.Runtime.Serialization;

namespace Clase_3_MVC.Web.Servicio
{
    [Serializable]
    internal class NoExistePartidosParaEsaFechaException : Exception
    {
        public NoExistePartidosParaEsaFechaException()
        {
        }

        public NoExistePartidosParaEsaFechaException(string message) : base(message)
        {
        }

        public NoExistePartidosParaEsaFechaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoExistePartidosParaEsaFechaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}