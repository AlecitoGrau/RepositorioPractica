using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Entities;
using PracticaAsignacion.Core.Exceptions;
using PracticaAsignacion.Core.Interfaces;
using PracticaAsignacion.Infrastructure.Data;

namespace PracticaAsignacion.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PruebaAsignacionContext _context;

        public UsuarioRepository(PruebaAsignacionContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios() 
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR")
                };

                string sql = $"[dbo].[Sp_Usuario] @opc = @opc";
                var response = await _context.Usuarios.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Usuario>> GetUsuario(int id) 
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR_ID"),
                    new SqlParameter("@IdUsuario", id)
                };

                string sql = "[dbo].[Sp_Usuario] @opc, @IdUsuario = @IdUsuario";
                var response = await _context.Usuarios.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> InsertarUsuario(UsuarioDto usuario)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                new SqlParameter("@opc", "CREAR"),
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Cedula", usuario.Cedula)
                };

                string sql = $"[dbo].[Sp_Usuario] @opc = @opc, @Nombre = @Nombre, @Cedula = @Cedula";
                var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> PutUsuario(UsuarioDto usuario)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("opc", "ACTUALIZAR"),
                    new SqlParameter("@IdUsuario", usuario.IdUsuario),
                    new SqlParameter("@Nombre", usuario.Nombre),
                    new SqlParameter("@Cedula", usuario.Cedula)
                };

                string sql = $"[dbo].[Sp_Usuario] @opc = @opc, @IdUsuario = @IdUsuario, @Nombre = @Nombre, @Cedula = @Cedula";
                var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> DeleteUsuario(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ELIMINAR"),
                    new SqlParameter("@IdUsuario", id)
                };

                string sql = $"[dbo].[Sp_Usuario] @opc, @IdUsuario = @IdUsuario";
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
