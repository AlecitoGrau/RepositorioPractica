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
    public class TareaAsignadaController : ControllerBase
    {
        private readonly ITareaAsignadaRepository _tareaAsignadaRepository;
        private readonly IMapper _mapper;

        public TareaAsignadaController(ITareaAsignadaRepository tareaAsignadaRepository, IMapper mapper)
        {
            _tareaAsignadaRepository = tareaAsignadaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTareas()
        {
            var tareas = await _tareaAsignadaRepository.GetTareas();
            var tareasDto = _mapper.Map<IEnumerable<TareaAsignadaDto>>(tareas);
            return Ok(tareasDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarTicket(int id)
        {
            var tarea = await _tareaAsignadaRepository.GetTarea(id);
            var tareaDto = _mapper.Map<IEnumerable<TicketDto>>(tarea);
            return Ok(tareaDto);
        }

        [HttpPost]
        public async Task<IActionResult> CrearTarea(TareaAsignadaDto tareas)
        {
            var tarea = await _tareaAsignadaRepository.InsertarTarea(tareas);
            var tareaDto = _mapper.Map<IEnumerable<Respuesta>>(tarea);
            var response = new ApiResponses<IEnumerable<Respuesta>>(tareaDto);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> ActualizarTarea(TareaAsignadaDto tarea)
        {
            var tareas = await _tareaAsignadaRepository.PutTarea(tarea);
            var tareaDto = _mapper.Map<IEnumerable<Respuesta>>(tareas);
            var response = new ApiResponses<IEnumerable<Respuesta>>(tareaDto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarTarea(int id)
        {
            var tarea = await _tareaAsignadaRepository.DeleteTarea(id);
            var tareaDto = _mapper.Map<IEnumerable<Respuesta>>(tarea);
            var response = new ApiResponses<IEnumerable<Respuesta>>(tareaDto);
            return Ok(response);
        }
    }
}
