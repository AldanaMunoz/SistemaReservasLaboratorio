using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SistemaReservasLaboratorio.Data.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        // Operaciones CRUD básicas
        void Agregar(T entidad);
        void Modificar(T entidad);
        void Eliminar(int id);
        T ObtenerPorId(int id);
        List<T> ObtenerTodos();

        // Consultas con filtros usando expresiones Lambda
        List<T> Buscar(Expression<Func<T, bool>> predicado);

        // Operaciones de persistencia
        void GuardarCambios();
        void DescartarCambios();
    }
}