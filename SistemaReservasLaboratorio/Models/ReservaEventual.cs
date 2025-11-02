using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SistemaReservasLaboratorio.Models
{
    public class ReservaEventual : Reserva
    {
        private int cantidadSemanas;

        public int IdReservaEventual { get; set; }

        public int CantidadSemanas
        {
            get => cantidadSemanas;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La cantidad de semanas debe ser mayor a cero.");
                cantidadSemanas = value;
            }
        }

        public override string TipoReserva => "Eventual";

        public ReservaEventual() : base()
        {
        }

        public ReservaEventual(DateTime fechaInicio, int cantidadSemanas,
            string carrera, string asignatura, int anio, string comision, string profesor, int idLaboratorio)
        {
            FechaHoraInicio = fechaInicio;
            CantidadSemanas = cantidadSemanas;
            // Calcular fecha fin basándose en la cantidad de semanas
            FechaHoraFin = fechaInicio.AddDays(cantidadSemanas * 7);
            Carrera = carrera;
            Asignatura = asignatura;
            Anio = anio;
            Comision = comision;
            Profesor = profesor;
            IdLaboratorio = idLaboratorio;
        }

        public override void ValidarReserva()
        {
            ValidarDatosComunes();

            if (CantidadSemanas <= 0)
            {
                throw new ArgumentException("Debe especificar la cantidad de semanas.");
            }

            // Validar que la cantidad de semanas no sea excesiva (máximo 1 año)
            if (CantidadSemanas > 52)
            {
                throw new ArgumentException("Una reserva eventual no puede exceder 52 semanas.");
            }
        }

        public override string ObtenerDescripcion()
        {
            return $"{base.ObtenerDescripcion()} - {CantidadSemanas} semanas";
        }

        public override string ToString()
        {
            return $"Reserva Eventual ({CantidadSemanas} sem) - {Asignatura}";
        }
    }
}