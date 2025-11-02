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
    public class ControladorLaboratorio
    {
        private RepositorioLaboratorio repositorio;

        public ControladorLaboratorio()
        {
            repositorio = new RepositorioLaboratorio();
        }

        public void AgregarLaboratorio(int numeroAsignado, string ubicacionPiso, int capacidadPuestos)
        {
            try
            {
                Laboratorio nuevoLab = new Laboratorio(numeroAsignado, ubicacionPiso, capacidadPuestos);
                repositorio.Agregar(nuevoLab);
                repositorio.GuardarCambios();
            }
            catch (Exception ex)
            {
                throw new LaboratorioException($"Error al agregar laboratorio: {ex.Message}", ex);
            }
        }

        public void ModificarLaboratorio(int id, int numeroAsignado, string ubicacionPiso, int capacidadPuestos)
        {
            try
            {
                var laboratorio = repositorio.ObtenerPorId(id);

                if (laboratorio == null)
                    throw new LaboratorioException("El laboratorio no existe.");

                laboratorio.NumeroAsignado = numeroAsignado;
                laboratorio.UbicacionPiso = ubicacionPiso;
                laboratorio.CapacidadPuestos = capacidadPuestos;

                repositorio.Modificar(laboratorio);
                repositorio.GuardarCambios();
            }
            catch (Exception ex)
            {
                throw new LaboratorioException($"Error al modificar laboratorio: {ex.Message}", ex);
            }
        }

        public void EliminarLaboratorio(int id)
        {
            try
            {
                repositorio.Eliminar(id);
                repositorio.GuardarCambios();
            }
            catch (Exception ex)
            {
                throw new LaboratorioException($"Error al eliminar laboratorio: {ex.Message}", ex);
            }
        }

        public Laboratorio ObtenerLaboratorioPorId(int id)
        {
            return repositorio.ObtenerPorId(id);
        }

        public List<Laboratorio> ObtenerTodosLosLaboratorios()
        {
            return repositorio.ObtenerTodos();
        }

        public List<Laboratorio> BuscarLaboratoriosPorNumero(int numero)
        {
            return repositorio.Buscar(l => l.NumeroAsignado == numero);
        }

        public List<Laboratorio> BuscarLaboratoriosPorPiso(string piso)
        {
            return repositorio.Buscar(l => l.UbicacionPiso.Contains(piso));
        }
    }
}