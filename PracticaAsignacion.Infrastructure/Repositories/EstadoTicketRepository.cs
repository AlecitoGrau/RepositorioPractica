using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticaAsignacion.Core.Entities;
using PracticaAsignacion.Core.Exceptions;
using PracticaAsignacion.Core.Interfaces;
using PracticaAsignacion.Infrastructure.Data;

namespace PracticaAsignacion.Infrastructure.Repositories
{
    public class EstadoTicketRepository : IEstadoTicketRepository
    {
        private readonly PruebaAsignacionContext _context;

        public EstadoTicketRepository(PruebaAsignacionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstadoTicket>> GetEstados() 
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR")
                };

                string sql = $"[dbo].[Sp_EstadoTicket] @opc = @opc";
                var response = await _context.EstadoTickets.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }
    }
}
