using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasLaboratorio.Exceptions
{
    public class ReservaException : Exception
    {
        public ReservaException() : base()
        {
        }

        public ReservaException(string mensaje) : base(mensaje)
        {
        }

        public ReservaException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}