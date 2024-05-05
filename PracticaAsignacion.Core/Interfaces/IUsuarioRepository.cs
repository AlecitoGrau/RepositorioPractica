using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Entities;
using PracticaAsignacion.Core.QueryFilters;

namespace PracticaAsignacion.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<IEnumerable<Usuario>> GetUsuario(int id);
        Task<IEnumerable<Respuesta>> InsertarUsuario(UsuarioDto usuario);
        Task<IEnumerable<Respuesta>> PutUsuario(UsuarioDto usuario);
        Task<IEnumerable<Respuesta>> DeleteUsuario(int id);
    }
}
