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
    public class RepositorioLaboratorio : IRepositorio<Laboratorio>
    {
        // Lista en memoria para operaciones antes de persistir
        private List<Laboratorio> laboratoriosEnMemoria;
        private bool cambiosPendientes;

        public RepositorioLaboratorio()
        {
            laboratoriosEnMemoria = new List<Laboratorio>();
            cambiosPendientes = false;
            CargarDesdeBaseDatos();
        }

        private void CargarDesdeBaseDatos()
        {
            laboratoriosEnMemoria.Clear();

            string query = "SELECT IdLaboratorio, NumeroAsignado, UbicacionPiso, CapacidadPuestos, Activo FROM Laboratorios WHERE Activo = 1";

            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Laboratorio lab = new Laboratorio
                        {
                            IdLaboratorio = reader.GetInt32(0),
                            NumeroAsignado = reader.GetInt32(1),
                            UbicacionPiso = reader.GetString(2),
                            CapacidadPuestos = reader.GetInt32(3),
                            Activo = reader.GetBoolean(4)
                        };
                        laboratoriosEnMemoria.Add(lab);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new LaboratorioException($"Error al cargar laboratorios desde la base de datos: {ex.Message}", ex);
            }
        }

        public void Agregar(Laboratorio entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException(nameof(entidad));

            // Validar que no exista el número asignado
            if (laboratoriosEnMemoria.Any(l => l.NumeroAsignado == entidad.NumeroAsignado))
                throw new LaboratorioException($"Ya existe un laboratorio con el número {entidad.NumeroAsignado}");

            laboratoriosEnMemoria.Add(entidad);
            cambiosPendientes = true;
        }

        public void Modificar(Laboratorio entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException(nameof(entidad));

            var labExistente = laboratoriosEnMemoria.FirstOrDefault(l => l.IdLaboratorio == entidad.IdLaboratorio);

            if (labExistente == null)
                throw new LaboratorioException("El laboratorio a modificar no existe.");

            // Validar número asignado único (excepto el actual)
            if (laboratoriosEnMemoria.Any(l => l.NumeroAsignado == entidad.NumeroAsignado && l.IdLaboratorio != entidad.IdLaboratorio))
                throw new LaboratorioException($"Ya existe otro laboratorio con el número {entidad.NumeroAsignado}");

            labExistente.NumeroAsignado = entidad.NumeroAsignado;
            labExistente.UbicacionPiso = entidad.UbicacionPiso;
            labExistente.CapacidadPuestos = entidad.CapacidadPuestos;

            cambiosPendientes = true;
        }

        public void Eliminar(int id)
        {
            var laboratorio = laboratoriosEnMemoria.FirstOrDefault(l => l.IdLaboratorio == id);

            if (laboratorio == null)
                throw new LaboratorioException("El laboratorio a eliminar no existe.");

            // Verificar si tiene reservas
            if (TieneReservasAsignadas(id))
            {
                throw new LaboratorioException("No se puede eliminar el laboratorio porque tiene reservas asignadas.");
            }

            laboratorio.Activo = false;
            cambiosPendientes = true;
        }

        private bool TieneReservasAsignadas(int idLaboratorio)
        {
            string query = "SELECT COUNT(*) FROM Reservas WHERE IdLaboratorio = @IdLaboratorio AND Activo = 1";

            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdLaboratorio", idLaboratorio);
                    int count = (int)comando.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new LaboratorioException($"Error al verificar reservas del laboratorio: {ex.Message}", ex);
            }
        }

        public Laboratorio ObtenerPorId(int id)
        {
            return laboratoriosEnMemoria.FirstOrDefault(l => l.IdLaboratorio == id);
        }

        public List<Laboratorio> ObtenerTodos()
        {
            return laboratoriosEnMemoria.Where(l => l.Activo).ToList();
        }

        public List<Laboratorio> Buscar(Expression<Func<Laboratorio, bool>> predicado)
        {
            return laboratoriosEnMemoria.AsQueryable().Where(predicado).ToList();
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

                foreach (var lab in laboratoriosEnMemoria)
                {
                    if (lab.IdLaboratorio == 0) // Nuevo
                    {
                        string queryInsert = @"INSERT INTO Laboratorios (NumeroAsignado, UbicacionPiso, CapacidadPuestos, Activo) 
                                              VALUES (@NumeroAsignado, @UbicacionPiso, @CapacidadPuestos, @Activo);
                                              SELECT SCOPE_IDENTITY();";

                        using (SqlCommand cmd = new SqlCommand(queryInsert, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@NumeroAsignado", lab.NumeroAsignado);
                            cmd.Parameters.AddWithValue("@UbicacionPiso", lab.UbicacionPiso);
                            cmd.Parameters.AddWithValue("@CapacidadPuestos", lab.CapacidadPuestos);
                            cmd.Parameters.AddWithValue("@Activo", lab.Activo);

                            lab.IdLaboratorio = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    else // Actualizar
                    {
                        string queryUpdate = @"UPDATE Laboratorios 
                                              SET NumeroAsignado = @NumeroAsignado, 
                                                  UbicacionPiso = @UbicacionPiso, 
                                                  CapacidadPuestos = @CapacidadPuestos,
                                                  Activo = @Activo
                                              WHERE IdLaboratorio = @IdLaboratorio";

                        using (SqlCommand cmd = new SqlCommand(queryUpdate, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@IdLaboratorio", lab.IdLaboratorio);
                            cmd.Parameters.AddWithValue("@NumeroAsignado", lab.NumeroAsignado);
                            cmd.Parameters.AddWithValue("@UbicacionPiso", lab.UbicacionPiso);
                            cmd.Parameters.AddWithValue("@CapacidadPuestos", lab.CapacidadPuestos);
                            cmd.Parameters.AddWithValue("@Activo", lab.Activo);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                transaccion.Commit();
                cambiosPendientes = false;
            }
            catch (Exception ex)
            {
                transaccion?.Rollback();
                throw new LaboratorioException($"Error al guardar cambios en la base de datos: {ex.Message}", ex);
            }
            finally
            {
                ConexionBD.CerrarConexion(conexion);
            }
        }

        public void DescartarCambios()
        {
            CargarDesdeBaseDatos();
            cambiosPendientes = false;
        }
    }
}