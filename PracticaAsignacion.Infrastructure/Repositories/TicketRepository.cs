using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Entities;
using PracticaAsignacion.Core.Exceptions;
using PracticaAsignacion.Core.Interfaces;
using PracticaAsignacion.Infrastructure.Data;

namespace PracticaAsignacion.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly PruebaAsignacionContext _context;

        public TicketRepository(PruebaAsignacionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR")
                };

                string sql = $"[dbo].[Sp_Ticket] @opc = @opc";
                var response = await _context.Tickets.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> InsertarTicket(TicketDto ticket)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                new SqlParameter("@opc", "CREAR"),
                new SqlParameter("@Descripcion", ticket.Descripcion),
                new SqlParameter("@Prioridad", ticket.Prioridad)
                };

                string sql = $"[dbo].[Sp_Ticket] @opc = @opc, @Descripcion = @Descripcion, @Prioridad = @Prioridad";
                var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Ticket>> GetTicket(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR_ID"),
                    new SqlParameter("@IdTicket", id)
                };

                string sql = "[dbo].[Sp_Ticket] @opc, @IdTicket = @IdTicket";
                var response = await _context.Tickets.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> PutTicket(TicketDto ticket)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("opc", "ACTUALIZAR"),
                    new SqlParameter("@IdTicket", ticket.IdTicket),
                    new SqlParameter("@Descripcion", ticket.Descripcion),
                    new SqlParameter("@Prioridad", ticket.Prioridad)
                };

                string sql = $"[dbo].[Sp_Ticket] @opc = @opc, @IdTicket = @IdTicket, @Descripcion = @Descripcion, @Prioridad = @Prioridad";
                var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> DeleteTicket(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ELIMINAR"),
                    new SqlParameter("@IdTicket", id)
                };

                string sql = $"[dbo].[Sp_Ticket] @opc, @IdTicket = @IdTicket";
                var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

    }
}
