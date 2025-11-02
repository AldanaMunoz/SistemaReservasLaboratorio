using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasLaboratorio.Exceptions
{
    public class ValidacionException : Exception
    {
        public ValidacionException() : base()
        {
        }

        public ValidacionException(string mensaje) : base(mensaje)
        {
        }

        public ValidacionException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}