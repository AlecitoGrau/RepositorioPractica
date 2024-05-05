using System;
using System.Collections.Generic;

namespace PracticaAsignacion.Core.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public virtual ICollection<TareaAsignada> TareaAsignada { get; set; } = new List<TareaAsignada>();
}
