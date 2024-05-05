using PracticaAsignacion.Core.Entities;

namespace PracticaAsignacion.Core.Interfaces
{
    public interface IEstadoTicketRepository
    {
        Task<IEnumerable<EstadoTicket>> GetEstados();
    }
}
