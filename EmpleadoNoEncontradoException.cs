using System;

namespace TallerPoo
{
    public class EmpleadoNoEncontradoException : Exception
    {
        public EmpleadoNoEncontradoException() : base("El empleado solicitado no fue encontrado.")
        {
        }

        public EmpleadoNoEncontradoException(string message) : base(message)
        {
        }

        public EmpleadoNoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
