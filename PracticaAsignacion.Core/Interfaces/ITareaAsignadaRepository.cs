using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Entities;

namespace PracticaAsignacion.Core.Interfaces
{
    public interface ITareaAsignadaRepository
    {
        Task<IEnumerable<TareaAsignada>> GetTareas();
        Task<IEnumerable<TareaAsignada>> GetTarea(int id);
        Task<IEnumerable<Respuesta>> InsertarTarea(TareaAsignadaDto tarea);
        Task<IEnumerable<Respuesta>> PutTarea(TareaAsignadaDto tarea);
        Task<IEnumerable<Respuesta>> DeleteTarea(int id);
    }
}
