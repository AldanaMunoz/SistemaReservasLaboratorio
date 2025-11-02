using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SistemaReservasLaboratorio.Exceptions;

namespace SistemaReservasLaboratorio.Utils
{
    public static class Validaciones
    {
        public static void ValidarCadenaNoVacia(string valor, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ValidacionException($"El campo {nombreCampo} no puede estar vacío.");
            }
        }

        public static void ValidarNumeroPositivo(int valor, string nombreCampo)
        {
            if (valor <= 0)
            {
                throw new ValidacionException($"El campo {nombreCampo} debe ser un número positivo.");
            }
        }

        public static void ValidarRangoFechas(DateTime inicio, DateTime fin)
        {
            if (fin <= inicio)
            {
                throw new ValidacionException("La fecha de finalización debe ser posterior a la fecha de inicio.");
            }
        }

        public static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ValidacionException("El email no puede estar vacío.");
            }

            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, patron))
            {
                throw new ValidacionException("El formato del email no es válido.");
            }
        }

        public static void ValidarHorarioLaboratorio(DateTime fecha)
        {
            DayOfWeek dia = fecha.DayOfWeek;
            TimeSpan hora = fecha.TimeOfDay;

            if (dia == DayOfWeek.Sunday)
            {
                throw new ValidacionException("Los domingos no está permitido realizar reservas.");
            }

            if (dia == DayOfWeek.Saturday)
            {
                if (hora < new TimeSpan(8, 0, 0) || hora > new TimeSpan(12, 0, 0))
                {
                    throw new ValidacionException("Los sábados el horario permitido es de 08:00 a 12:00.");
                }
            }
            else // Lunes a Viernes
            {
                if (hora < new TimeSpan(7, 0, 0) || hora > new TimeSpan(23, 0, 0))
                {
                    throw new ValidacionException("De lunes a viernes el horario permitido es de 07:00 a 23:00.");
                }
            }
        }
    }
}