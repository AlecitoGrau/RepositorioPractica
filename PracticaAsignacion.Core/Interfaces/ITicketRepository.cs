using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Entities;

namespace PracticaAsignacion.Core.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTickets();
        Task<IEnumerable<Respuesta>> InsertarTicket(TicketDto ticket);
        Task<IEnumerable<Ticket>> GetTicket(int id);
        Task<IEnumerable<Respuesta>> PutTicket(TicketDto ticket);
        Task<IEnumerable<Respuesta>> DeleteTicket(int id);
    }
}
