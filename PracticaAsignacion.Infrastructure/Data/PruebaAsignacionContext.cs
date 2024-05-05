using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PracticaAsignacion.Core.Entities;
using PracticaAsignacion.Infrastructure.Data.Configurations;

namespace PracticaAsignacion.Infrastructure.Data;

public partial class PruebaAsignacionContext : DbContext
{
    public PruebaAsignacionContext()
    {
    }

    public PruebaAsignacionContext(DbContextOptions<PruebaAsignacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EstadoTicket> EstadoTickets { get; set; }

    public virtual DbSet<TareaAsignada> TareaAsignada { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Respuesta> Respuesta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EstadoTicketConfiguration());

        modelBuilder.ApplyConfiguration(new TareaAsignadaConfiguration());

        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

    }

}
