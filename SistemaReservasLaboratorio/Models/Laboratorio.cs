using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasLaboratorio.Models
{
    public class Laboratorio
    {
        private int numeroAsignado;
        private int capacidadPuestos;

        public int IdLaboratorio { get; set; }

        public int NumeroAsignado
        {
            get => numeroAsignado;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El número asignado debe ser mayor a cero.");
                numeroAsignado = value;
            }
        }

        public string UbicacionPiso { get; set; }

        public int CapacidadPuestos
        {
            get => capacidadPuestos;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La capacidad debe ser mayor a cero.");
                capacidadPuestos = value;
            }
        }

        public bool Activo { get; set; }

        public Laboratorio()
        {
            Activo = true;
        }

        public Laboratorio(int numeroAsignado, string ubicacionPiso, int capacidadPuestos)
        {
            NumeroAsignado = numeroAsignado;
            UbicacionPiso = ubicacionPiso ?? throw new ArgumentNullException(nameof(ubicacionPiso));
            CapacidadPuestos = capacidadPuestos;
            Activo = true;
        }

        public override string ToString()
        {
            return $"Lab {NumeroAsignado} - {UbicacionPiso} ({CapacidadPuestos} puestos)";
        }
    }
}