using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Entities;
using PracticaAsignacion.Core.Exceptions;
using PracticaAsignacion.Core.Interfaces;
using PracticaAsignacion.Infrastructure.Data;

namespace PracticaAsignacion.Infrastructure.Repositories
{
    public class TareaAsignadaRepository : ITareaAsignadaRepository
    {
        private readonly PruebaAsignacionContext _context;

        public TareaAsignadaRepository(PruebaAsignacionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TareaAsignada>> GetTareas() 
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR")
                };

                string sql = $"[dbo].[Sp_TareaAsignada] @opc = @opc";
                var response = await _context.TareaAsignada.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<TareaAsignada>> GetTarea(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR_ID"),
                    new SqlParameter("@IdTarea", id)
                };

                string sql = "[dbo].[Sp_TareaAsignada] @opc, @IdTarea = @IdTarea";
                var response = await _context.TareaAsignada.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> InsertarTarea(TareaAsignadaDto tarea)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                new SqlParameter("@opc", "CREAR"),
                new SqlParameter("@IdUsuario", tarea.IdUsuario),
                new SqlParameter("@IdTicket", tarea.IdTicket),
                //new SqlParameter("@Fecha", tarea.Fecha),
                new SqlParameter("@IdEstado", tarea.IdEstado)
                };

                string sql = $"[dbo].[Sp_TareaAsignada] @opc = @opc, @IdUsuario = @IdUsuario, @IdTicket = @IdTicket, @IdEstado = @IdEstado";
                var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> PutTarea(TareaAsignadaDto tarea)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("opc", "ACTUALIZAR"),
                    new SqlParameter("@IdTarea", tarea.IdTarea),
                    new SqlParameter("@IdUsuario", tarea.IdUsuario),
                    new SqlParameter("@IdTicket", tarea.IdTicket),
                    new SqlParameter("@IdEstado", tarea.IdEstado)
                };

                string sql = $"[dbo].[Sp_TareaAsignada] @opc = @opc, @IdTarea = @IdTarea, @IdUsuario = @IdUsuario, @IdTicket = @IdTicket, @IdEstado = @IdEstado";
                var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> DeleteTarea(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ELIMINAR"),
                    new SqlParameter("@IdTarea", id)
                };

                string sql = $"[dbo].[Sp_TareaAsignada] @opc, @IdTarea = @IdTarea";
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
