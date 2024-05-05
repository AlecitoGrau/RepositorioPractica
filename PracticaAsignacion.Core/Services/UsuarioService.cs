using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Entities;
using PracticaAsignacion.Core.Interfaces;
using PracticaAsignacion.Core.QueryFilters;

namespace PracticaAsignacion.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios(UsuarioQueryFilter filters)
        {
            var usuarios = await _usuarioRepository.GetUsuarios();
            if (filters.Nombre != null) 
            {
                //usuarios = usuarios.Where(x => x.Nombre == filters.Nombre);
                usuarios = usuarios.Where(x => x.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
            }

            if (filters.Cedula != null)
            {
                //usuarios = usuarios.Where(x => x.Cedula == filters.Cedula);
                usuarios = usuarios.Where(x => x.Cedula.ToLower().Contains(filters.Cedula.ToLower()));
            }

            return usuarios;
        }

        public async Task<IEnumerable<Usuario>> GetUsuario(int id)
        {
            return await _usuarioRepository.GetUsuario(id);
        }

        public async Task<IEnumerable<Respuesta>> InsertarUsuario(UsuarioDto usuario)
        {
            return await _usuarioRepository.InsertarUsuario(usuario);
        }

        public async Task<IEnumerable<Respuesta>> PutUsuario(UsuarioDto usuario)
        {
            return await _usuarioRepository.PutUsuario(usuario);
        }

        public async Task<IEnumerable<Respuesta>> DeleteUsuario(int id)
        {
            return await _usuarioRepository.DeleteUsuario(id);
        }

    }
}
