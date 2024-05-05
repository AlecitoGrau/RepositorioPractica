using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticaAsignacion.Core.Entities;

namespace PracticaAsignacion.Infrastructure.Data.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket");

            builder.HasKey(e => e.IdTicket).HasName("PK__Ticket__4B93C7E73ED13C77");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            builder.Property(e => e.Prioridad)
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
