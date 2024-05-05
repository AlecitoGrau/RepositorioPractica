namespace PracticaAsignacion.Core.DTOs
{
    public class TareaAsignadaDto
    {
        public int IdTarea { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdTicket { get; set; }

        public DateTime? Fecha { get; set; }

        public int? IdEstado { get; set; }
    }
}
