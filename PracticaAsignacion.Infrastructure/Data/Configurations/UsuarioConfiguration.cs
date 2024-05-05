using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticaAsignacion.Core.Entities;

namespace PracticaAsignacion.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97895A2958");

            builder.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
