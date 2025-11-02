using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasLaboratorio.Models
{
    public class ReservaCuatrimestral : Reserva
    {
        public enum TipoPeriodicidad
        {
            Semanal,
            Quincenal
        }

        public int IdReservaCuatrimestral { get; set; }
        public TipoPeriodicidad Periodicidad { get; set; }

        public override string TipoReserva => "Cuatrimestral";

        public ReservaCuatrimestral() : base()
        {
        }

        public ReservaCuatrimestral(DateTime inicio, DateTime fin, TipoPeriodicidad periodicidad,
            string carrera, string asignatura, int anio, string comision, string profesor, int idLaboratorio)
        {
            FechaHoraInicio = inicio;
            FechaHoraFin = fin;
            Periodicidad = periodicidad;
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

            // Validar que sea realmente para un cuatrimestre (aproximadamente 4 meses)
            TimeSpan duracion = FechaHoraFin - FechaHoraInicio;
            if (duracion.TotalDays < 90) // Mínimo 3 meses
            {
                throw new ArgumentException("Una reserva cuatrimestral debe tener al menos 3 meses de duración.");
            }
        }

        public override string ObtenerDescripcion()
        {
            return $"{base.ObtenerDescripcion()} - {Periodicidad}";
        }

        public override string ToString()
        {
            return $"Reserva Cuatrimestral {Periodicidad} - {Asignatura}";
        }
    }
}