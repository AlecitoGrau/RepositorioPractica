using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticaAsignacion.Api.Responses;
using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Entities;
using PracticaAsignacion.Core.Interfaces;

namespace PracticaAsignacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketController(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTickets()
        {
            var tickets = await _ticketRepository.GetTickets();
            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(tickets);
            return Ok(ticketsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CrearTicket(TicketDto tickets)
        {
            var ticket = await _ticketRepository.InsertarTicket(tickets);
            var ticketDto = _mapper.Map<IEnumerable<Respuesta>>(ticket);
            var response = new ApiResponses<IEnumerable<Respuesta>>(ticketDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarTicket(int id)
        {
            var ticket = await _ticketRepository.GetTicket(id);
            var ticketDto = _mapper.Map<IEnumerable<TicketDto>>(ticket);
            return Ok(ticketDto);
        }

        [HttpPut]

        public async Task<IActionResult> ActualizarTicket(TicketDto ticket)
        {
            var tickets = await _ticketRepository.PutTicket(ticket);
            var ticketDto = _mapper.Map<IEnumerable<Respuesta>>(tickets);
            var response = new ApiResponses<IEnumerable<Respuesta>>(ticketDto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarTicket(int id)
        {
            var ticket = await _ticketRepository.DeleteTicket(id);
            var ticketDto = _mapper.Map<IEnumerable<Respuesta>>(ticket);
            var response = new ApiResponses<IEnumerable<Respuesta>>(ticketDto);
            return Ok(response);
        }
    }
}
