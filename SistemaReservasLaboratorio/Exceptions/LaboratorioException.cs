using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasLaboratorio.Exceptions
{
    public class LaboratorioException : Exception
    {
        public LaboratorioException() : base()
        {
        }

        public LaboratorioException(string mensaje) : base(mensaje)
        {
        }

        public LaboratorioException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}