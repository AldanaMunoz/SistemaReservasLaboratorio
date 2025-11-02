using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaReservasLaboratorio.Data.Repositorios;
using SistemaReservasLaboratorio.Exceptions;
using SistemaReservasLaboratorio.Models;

namespace SistemaReservasLaboratorio.Controllers
{
    public class ControladorReserva
    {
        private RepositorioReserva repositorio;

        public ControladorReserva()
        {
            repositorio = new RepositorioReserva();
        }

        public void AgregarReservaCuatrimestral(DateTime inicio, DateTime fin,
            ReservaCuatrimestral.TipoPeriodicidad periodicidad, string carrera,
            string asignatura, int anio, string comision, string profesor, int idLaboratorio)
        {
            try
            {
                var reserva = new ReservaCuatrimestral(inicio, fin, periodicidad,
                    carrera, asignatura, anio, comision, profesor, idLaboratorio);

                repositorio.Agregar(reserva);
                repositorio.GuardarCambios();
            }
            catch (Exception ex)
            {
                throw new ReservaException($"Error al agregar reserva cuatrimestral: {ex.Message}", ex);
            }
        }

        public void AgregarReservaEventual(DateTime fechaInicio, int cantidadSemanas,
            string carrera, string asignatura, int anio, string comision,
            string profesor, int idLaboratorio)
        {
            try
            {
                var reserva = new ReservaEventual(fechaInicio, cantidadSemanas,
                    carrera, asignatura, anio, comision, profesor, idLaboratorio);

                repositorio.Agregar(reserva);
                repositorio.GuardarCambios();
            }
            catch (Exception ex)
            {
                throw new ReservaException($"Error al agregar reserva eventual: {ex.Message}", ex);
            }
        }

        public void ModificarReserva(Reserva reserva)
        {
            try
            {
                repositorio.Modificar(reserva);
                repositorio.GuardarCambios();
            }
            catch (Exception ex)
            {
                throw new ReservaException($"Error al modificar reserva: {ex.Message}", ex);
            }
        }

        public void EliminarReserva(int id)
        {
            try
            {
                repositorio.Eliminar(id);
                repositorio.GuardarCambios();
            }
            catch (Exception ex)
            {
                throw new ReservaException($"Error al eliminar reserva: {ex.Message}", ex);
            }
        }

        public Reserva ObtenerReservaPorId(int id)
        {
            return repositorio.ObtenerPorId(id);
        }

        public List<Reserva> ObtenerTodasLasReservas()
        {
            return repositorio.ObtenerTodos();
        }

        public List<Reserva> BuscarReservasPorFecha(DateTime fecha)
        {
            return repositorio.Buscar(r =>
                r.FechaHoraInicio.Date <= fecha.Date &&
                r.FechaHoraFin.Date >= fecha.Date);
        }

        public List<Reserva> BuscarReservasPorProfesor(string profesor)
        {
            return repositorio.Buscar(r =>
                r.Profesor.ToLower().Contains(profesor.ToLower()));
        }

        public List<Reserva> BuscarReservasPorAsignatura(string asignatura)
        {
            return repositorio.Buscar(r =>
                r.Asignatura.ToLower().Contains(asignatura.ToLower()));
        }

        public List<Reserva> BuscarReservasPorLaboratorio(int idLaboratorio)
        {
            return repositorio.Buscar(r => r.IdLaboratorio == idLaboratorio);
        }
    }
}