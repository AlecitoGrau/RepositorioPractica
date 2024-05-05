using System;
using System.Collections.Generic;

namespace PracticaAsignacion.Core.Entities;

public partial class EstadoTicket
{
    public int IdEstado { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<TareaAsignada> TareaAsignada { get; set; } = new List<TareaAsignada>();
}
