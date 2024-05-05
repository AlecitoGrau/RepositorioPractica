using AutoMapper;
using PracticaAsignacion.Core.DTOs;
using PracticaAsignacion.Core.Entities;

namespace PracticaAsignacion.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();
            CreateMap<EstadoTicket, EstadoTicketDto>();
            CreateMap<EstadoTicketDto, EstadoTicket>();
            CreateMap<TareaAsignada, TareaAsignadaDto>();
            CreateMap<TareaAsignadaDto, TareaAsignada>();
        }
    }
}
