using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticaAsignacion.Api.Responses;
using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Entities;
using PracticaAsignacion.Core.Interfaces;
using PracticaAsignacion.Core.QueryFilters;

namespace PracticaAsignacion.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios([FromQuery] UsuarioQueryFilter filters)
        {
            var usuarios = await _usuarioService.GetUsuarios(filters);
            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
            return Ok(usuariosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarUsuario(int id) 
        {
            var usuario = await _usuarioService.GetUsuario(id);
            var usuarioDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuario);
            return Ok(usuarioDto);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario(UsuarioDto usuarios)
        {
            var usuario = await _usuarioService.InsertarUsuario(usuarios);
            var usuarioDto = _mapper.Map<IEnumerable<Respuesta>>(usuario);
            var response = new ApiResponses<IEnumerable<Respuesta>>(usuarioDto);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> ActualizarUsuario(UsuarioDto usuario) 
        {
            var usuarios = await _usuarioService.PutUsuario(usuario);
            var usuarioDto = _mapper.Map<IEnumerable<Respuesta>>(usuarios);
            var response = new ApiResponses<IEnumerable<Respuesta>>(usuarioDto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarUsuario(int id) 
        {
            var usuario = await _usuarioService.DeleteUsuario(id);
            var usuarioDto = _mapper.Map<IEnumerable<Respuesta>>(usuario);
            var response = new ApiResponses<IEnumerable<Respuesta>>(usuarioDto);
            return Ok(response);
        }
    }
}
