using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticaAsignacion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaAsignacion.Infrastructure.Data.Configurations
{
    public class EstadoTicketConfiguration : IEntityTypeConfiguration<EstadoTicket>
    {
        public void Configure(EntityTypeBuilder<EstadoTicket> builder)
        {
            builder.ToTable("EstadoTicket");

            builder.HasKey(e => e.IdEstado).HasName("PK__EstadoTi__FBB0EDC181330E01");

            builder.Property(e => e.IdEstado).ValueGeneratedNever();
            builder.Property(e => e.NombreEstado)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
