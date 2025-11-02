using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;
using SistemaReservasLaboratorio.Data.Interfaces;
using SistemaReservasLaboratorio.Exceptions;
using SistemaReservasLaboratorio.Models;

namespace SistemaReservasLaboratorio.Data.Repositorios
{
    public class RepositorioReserva : IRepositorio<Reserva>
    {
        private List<Reserva> reservasEnMemoria;
        private bool cambiosPendientes;

        public RepositorioReserva()
        {
            reservasEnMemoria = new List<Reserva>();
            cambiosPendientes = false;
            CargarDesdeBaseDatos();
        }

        private void CargarDesdeBaseDatos()
        {
            reservasEnMemoria.Clear();

            string query = @"SELECT r.IdReserva, r.IdLaboratorio, r.TipoReserva, r.FechaHoraInicio, 
                                   r.FechaHoraFin, r.Carrera, r.Asignatura, r.Anio, r.Comision, 
                                   r.Profesor, r.Activo,
                                   rc.IdReservaCuatrimestral, rc.Periodicidad,
                                   re.IdReservaEventual, re.CantidadSemanas
                            FROM Reservas r
                            LEFT JOIN ReservasCuatrimestrales rc ON r.IdReserva = rc.IdReserva
                            LEFT JOIN ReservasEventuales re ON r.IdReserva = re.IdReserva
                            WHERE r.Activo = 1";

            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tipoReserva = reader.GetString(2);
                        Reserva reserva = null;

                        if (tipoReserva == "Cuatrimestral")
                        {
                            var periodicidad = reader.GetString(12);
                            reserva = new ReservaCuatrimestral
                            {
                                IdReservaCuatrimestral = reader.GetInt32(11),
                                Periodicidad = periodicidad == "Semanal" ?
                                    ReservaCuatrimestral.TipoPeriodicidad.Semanal :
                                    ReservaCuatrimestral.TipoPeriodicidad.Quincenal
                            };
                        }
                        else if (tipoReserva == "Eventual")
                        {
                            reserva = new ReservaEventual
                            {
                                IdReservaEventual = reader.GetInt32(13),
                                CantidadSemanas = reader.GetInt32(14)
                            };
                        }

                        if (reserva != null)
                        {
                            reserva.IdReserva = reader.GetInt32(0);
                            reserva.IdLaboratorio = reader.GetInt32(1);
                            reserva.FechaHoraInicio = reader.GetDateTime(3);
                            reserva.FechaHoraFin = reader.GetDateTime(4);
                            reserva.Carrera = reader.GetString(5);
                            reserva.Asignatura = reader.GetString(6);
                            reserva.Anio = reader.GetInt32(7);
                            reserva.Comision = reader.GetString(8);
                            reserva.Profesor = reader.GetString(9);
                            reserva.Activo = reader.GetBoolean(10);

                            reservasEnMemoria.Add(reserva);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ReservaException($"Error al cargar reservas desde la base de datos: {ex.Message}", ex);
            }
        }

        public void Agregar(Reserva entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException(nameof(entidad));

            entidad.ValidarReserva();

            // Verificar solapamiento de horarios
            if (ExisteSolapamiento(entidad))
                throw new ReservaException("Ya existe una reserva en ese horario para el laboratorio seleccionado.");

            reservasEnMemoria.Add(entidad);
            cambiosPendientes = true;
        }

        public void Modificar(Reserva entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException(nameof(entidad));

            var reservaExistente = reservasEnMemoria.FirstOrDefault(r => r.IdReserva == entidad.IdReserva);

            if (reservaExistente == null)
                throw new ReservaException("La reserva a modificar no existe.");

            entidad.ValidarReserva();

            // Verificar solapamiento (excluyendo la reserva actual)
            if (ExisteSolapamiento(entidad, entidad.IdReserva))
                throw new ReservaException("Ya existe una reserva en ese horario para el laboratorio seleccionado.");

            // Actualizar propiedades
            int index = reservasEnMemoria.IndexOf(reservaExistente);
            reservasEnMemoria[index] = entidad;

            cambiosPendientes = true;
        }

        public void Eliminar(int id)
        {
            var reserva = reservasEnMemoria.FirstOrDefault(r => r.IdReserva == id);

            if (reserva == null)
                throw new ReservaException("La reserva a eliminar no existe.");

            reserva.Activo = false;
            cambiosPendientes = true;
        }

        public Reserva ObtenerPorId(int id)
        {
            return reservasEnMemoria.FirstOrDefault(r => r.IdReserva == id);
        }

        public List<Reserva> ObtenerTodos()
        {
            return reservasEnMemoria.Where(r => r.Activo).ToList();
        }

        public List<Reserva> Buscar(Expression<Func<Reserva, bool>> predicado)
        {
            return reservasEnMemoria.AsQueryable().Where(predicado).ToList();
        }

        private bool ExisteSolapamiento(Reserva nuevaReserva, int idReservaExcluir = 0)
        {
            return reservasEnMemoria.Any(r =>
                r.Activo &&
                r.IdReserva != idReservaExcluir &&
                r.IdLaboratorio == nuevaReserva.IdLaboratorio &&
                ((nuevaReserva.FechaHoraInicio >= r.FechaHoraInicio && nuevaReserva.FechaHoraInicio < r.FechaHoraFin) ||
                 (nuevaReserva.FechaHoraFin > r.FechaHoraInicio && nuevaReserva.FechaHoraFin <= r.FechaHoraFin) ||
                 (nuevaReserva.FechaHoraInicio <= r.FechaHoraInicio && nuevaReserva.FechaHoraFin >= r.FechaHoraFin))
            );
        }

        public void GuardarCambios()
        {
            if (!cambiosPendientes)
                return;

            SqlConnection conexion = null;
            SqlTransaction transaccion = null;

            try
            {
                conexion = ConexionBD.ObtenerConexion();
                transaccion = conexion.BeginTransaction();

                foreach (var reserva in reservasEnMemoria)
                {
                    if (reserva.IdReserva == 0) // Nueva reserva
                    {
                        InsertarReserva(reserva, conexion, transaccion);
                    }
                    else // Actualizar reserva
                    {
                        ActualizarReserva(reserva, conexion, transaccion);
                    }
                }

                transaccion.Commit();
                cambiosPendientes = false;
            }
            catch (Exception ex)
            {
                transaccion?.Rollback();
                throw new ReservaException($"Error al guardar cambios en la base de datos: {ex.Message}", ex);
            }
            finally
            {
                ConexionBD.CerrarConexion(conexion);
            }
        }

        private void InsertarReserva(Reserva reserva, SqlConnection conexion, SqlTransaction transaccion)
        {
            // Insertar en tabla Reservas
            string queryReserva = @"INSERT INTO Reservas (IdLaboratorio, TipoReserva, FechaHoraInicio, FechaHoraFin, 
                                                         Carrera, Asignatura, Anio, Comision, Profesor, Activo)
                                   VALUES (@IdLaboratorio, @TipoReserva, @FechaHoraInicio, @FechaHoraFin, 
                                           @Carrera, @Asignatura, @Anio, @Comision, @Profesor, @Activo);
                                   SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(queryReserva, conexion, transaccion))
            {
                cmd.Parameters.AddWithValue("@IdLaboratorio", reserva.IdLaboratorio);
                cmd.Parameters.AddWithValue("@TipoReserva", reserva.TipoReserva);
                cmd.Parameters.AddWithValue("@FechaHoraInicio", reserva.FechaHoraInicio);
                cmd.Parameters.AddWithValue("@FechaHoraFin", reserva.FechaHoraFin);
                cmd.Parameters.AddWithValue("@Carrera", reserva.Carrera);
                cmd.Parameters.AddWithValue("@Asignatura", reserva.Asignatura);
                cmd.Parameters.AddWithValue("@Anio", reserva.Anio);
                cmd.Parameters.AddWithValue("@Comision", reserva.Comision);
                cmd.Parameters.AddWithValue("@Profesor", reserva.Profesor);
                cmd.Parameters.AddWithValue("@Activo", reserva.Activo);

                reserva.IdReserva = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // Insertar en tabla específica según tipo
            if (reserva is ReservaCuatrimestral reservaCuatri)
            {
                string queryCuatri = @"INSERT INTO ReservasCuatrimestrales (IdReserva, Periodicidad)
                                      VALUES (@IdReserva, @Periodicidad);
                                      SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(queryCuatri, conexion, transaccion))
                {
                    cmd.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);
                    cmd.Parameters.AddWithValue("@Periodicidad", reservaCuatri.Periodicidad.ToString());
                    reservaCuatri.IdReservaCuatrimestral = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            else if (reserva is ReservaEventual reservaEventual)
            {
                string queryEventual = @"INSERT INTO ReservasEventuales (IdReserva, CantidadSemanas)
                                        VALUES (@IdReserva, @CantidadSemanas);
                                        SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(queryEventual, conexion, transaccion))
                {
                    cmd.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);
                    cmd.Parameters.AddWithValue("@CantidadSemanas", reservaEventual.CantidadSemanas);
                    reservaEventual.IdReservaEventual = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void ActualizarReserva(Reserva reserva, SqlConnection conexion, SqlTransaction transaccion)
        {
            string queryUpdate = @"UPDATE Reservas 
                                  SET IdLaboratorio = @IdLaboratorio,
                                      FechaHoraInicio = @FechaHoraInicio,
                                      FechaHoraFin = @FechaHoraFin,
                                      Carrera = @Carrera,
                                      Asignatura = @Asignatura,
                                      Anio = @Anio,
                                      Comision = @Comision,
                                      Profesor = @Profesor,
                                      Activo = @Activo
                                  WHERE IdReserva = @IdReserva";

            using (SqlCommand cmd = new SqlCommand(queryUpdate, conexion, transaccion))
            {
                cmd.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);
                cmd.Parameters.AddWithValue("@IdLaboratorio", reserva.IdLaboratorio);
                cmd.Parameters.AddWithValue("@FechaHoraInicio", reserva.FechaHoraInicio);
                cmd.Parameters.AddWithValue("@FechaHoraFin", reserva.FechaHoraFin);
                cmd.Parameters.AddWithValue("@Carrera", reserva.Carrera);
                cmd.Parameters.AddWithValue("@Asignatura", reserva.Asignatura);
                cmd.Parameters.AddWithValue("@Anio", reserva.Anio);
                cmd.Parameters.AddWithValue("@Comision", reserva.Comision);
                cmd.Parameters.AddWithValue("@Profesor", reserva.Profesor);
                cmd.Parameters.AddWithValue("@Activo", reserva.Activo);

                cmd.ExecuteNonQuery();
            }

            // Actualizar tablas específicas
            if (reserva is ReservaCuatrimestral reservaCuatri)
            {
                string queryUpdateCuatri = @"UPDATE ReservasCuatrimestrales 
                                            SET Periodicidad = @Periodicidad
                                            WHERE IdReserva = @IdReserva";

                using (SqlCommand cmd = new SqlCommand(queryUpdateCuatri, conexion, transaccion))
                {
                    cmd.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);
                    cmd.Parameters.AddWithValue("@Periodicidad", reservaCuatri.Periodicidad.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
            else if (reserva is ReservaEventual reservaEventual)
            {
                string queryUpdateEventual = @"UPDATE ReservasEventuales 
                                              SET CantidadSemanas = @CantidadSemanas
                                              WHERE IdReserva = @IdReserva";

                using (SqlCommand cmd = new SqlCommand(queryUpdateEventual, conexion, transaccion))
                {
                    cmd.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);
                    cmd.Parameters.AddWithValue("@CantidadSemanas", reservaEventual.CantidadSemanas);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DescartarCambios()
        {
            CargarDesdeBaseDatos();
            cambiosPendientes = false;
        }
    }
}