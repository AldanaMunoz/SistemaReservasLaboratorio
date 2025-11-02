using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasLaboratorio.Models
{
    public abstract class Reserva
    {
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;

        public int IdReserva { get; set; }
        public int IdLaboratorio { get; set; }

        public DateTime FechaHoraInicio
        {
            get => fechaHoraInicio;
            set
            {
                ValidarHorario(value);
                fechaHoraInicio = value;
            }
        }

        public DateTime FechaHoraFin
        {
            get => fechaHoraFin;
            set
            {
                ValidarHorario(value);
                if (value <= fechaHoraInicio)
                    throw new ArgumentException("La fecha de fin debe ser posterior a la de inicio.");
                fechaHoraFin = value;
            }
        }

        public string Carrera { get; set; }
        public string Asignatura { get; set; }
        public int Anio { get; set; }
        public string Comision { get; set; }
        public string Profesor { get; set; }
        public bool Activo { get; set; }

        // Propiedad virtual que puede ser sobreescrita
        public virtual string TipoReserva => "General";

        protected Reserva()
        {
            Activo = true;
        }

        // Método abstracto que las clases derivadas deben implementar
        public abstract void ValidarReserva();

        // Método virtual que puede ser sobreescrito
        public virtual string ObtenerDescripcion()
        {
            return $"{TipoReserva} - {Asignatura} ({Profesor})";
        }

        // Método para validar horarios permitidos
        private void ValidarHorario(DateTime fechaHora)
        {
            DayOfWeek dia = fechaHora.DayOfWeek;
            TimeSpan hora = fechaHora.TimeOfDay;

            if (dia == DayOfWeek.Sunday)
            {
                throw new ArgumentException("Los domingos no está permitido reservar.");
            }

            if (dia == DayOfWeek.Saturday)
            {
                // Sábados: 08:00 - 12:00
                if (hora < new TimeSpan(8, 0, 0) || hora > new TimeSpan(12, 0, 0))
                {
                    throw new ArgumentException("Los sábados el horario permitido es de 08:00 a 12:00.");
                }
            }
            else
            {
                // Lunes a Viernes: 07:00 - 23:00
                if (hora < new TimeSpan(7, 0, 0) || hora > new TimeSpan(23, 0, 0))
                {
                    throw new ArgumentException("De lunes a viernes el horario permitido es de 07:00 a 23:00.");
                }
            }
        }

        protected void ValidarDatosComunes()
        {
            if (string.IsNullOrWhiteSpace(Carrera))
                throw new ArgumentException("La carrera es obligatoria.");

            if (string.IsNullOrWhiteSpace(Asignatura))
                throw new ArgumentException("La asignatura es obligatoria.");

            if (Anio <= 0)
                throw new ArgumentException("El año debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(Comision))
                throw new ArgumentException("La comisión es obligatoria.");

            if (string.IsNullOrWhiteSpace(Profesor))
                throw new ArgumentException("El profesor es obligatorio.");

            if (IdLaboratorio <= 0)
                throw new ArgumentException("Debe seleccionar un laboratorio válido.");
        }
    }
}