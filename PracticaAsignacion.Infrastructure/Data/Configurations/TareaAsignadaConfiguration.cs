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
    public class TareaAsignadaConfiguration : IEntityTypeConfiguration<TareaAsignada>
    {
        public void Configure(EntityTypeBuilder<TareaAsignada> builder)
        {
            builder.ToTable("TareaAsignada");

            builder.HasKey(e => e.IdTarea).HasName("PK__TareaAsi__EADE9098C7862FBA");

            builder.Property(e => e.Fecha).HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.TareaAsignada)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Usuario_Estado");

            builder.HasOne(d => d.IdTicketNavigation).WithMany(p => p.TareaAsignada)
                .HasForeignKey(d => d.IdTicket)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Ticket_Asignada");

            builder.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TareaAsignada)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Usuario_Asignada");
        }
    }
}
