using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Interfaces;
using PracticaAsignacion.Infrastructure.Repositories;

namespace PracticaAsignacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoTicketController : ControllerBase
    {
        private readonly IEstadoTicketRepository _estadoTicketRepository;
        private readonly IMapper _mapper;

        public EstadoTicketController(IEstadoTicketRepository estadoTicketRepository, IMapper mapper)
        {
            _estadoTicketRepository = estadoTicketRepository;
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<IActionResult> ListarEstados() 
        {
            var estados = await _estadoTicketRepository.GetEstados();
            var estadosDto = _mapper.Map<IEnumerable<EstadoTicketDto>>(estados);
            return Ok(estadosDto);
        }
    }
}
