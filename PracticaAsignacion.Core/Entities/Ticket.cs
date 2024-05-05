using System.ComponentModel.DataAnnotations;

namespace PracticaAsignacion.Core.Entities;

public partial class Ticket
{
    [Key]
    public int IdTicket { get; set; }

    public string? Descripcion { get; set; }

    public string? Prioridad { get; set; }

    public virtual ICollection<TareaAsignada> TareaAsignada { get; set; } = new List<TareaAsignada>();
}
