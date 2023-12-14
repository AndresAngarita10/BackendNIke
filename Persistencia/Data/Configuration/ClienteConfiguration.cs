using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.Documento)
        .HasColumnName("Documento")
        .HasColumnType("varchar")
        .HasMaxLength(30)
        .IsRequired();

        builder.HasIndex(d => d.Documento).IsUnique();
        builder.HasIndex(d => d.IdUsuarioFk).IsUnique();

        builder.Property(d => d.PrimerNombre)
        .HasColumnName("PrimerNombre")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(d => d.SegundoNombre)
        .HasColumnName("SegundoNombre")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(d => d.PrimerApellido)
        .HasColumnName("PrimerApellido")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(d => d.SegundoApellido)
        .HasColumnName("SegundoApellido")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(d => d.Telefono)
        .HasColumnName("Telefono")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(d => d.Email)
        .HasColumnName("Email")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.HasOne(c => c.Usuario)
        .WithMany(c => c.Clientes)
        .HasForeignKey(c => c.IdUsuarioFk)
        .IsRequired(false);

        /* builder.HasOne(e => e.Usuario)
        .WithOne(e => e.Cliente)
        .HasForeignKey<Cliente>(e => e.IdClienteFk)
        .IsRequired(); */
        /* builder
        .HasOne(e => e.Usuario)
        .WithOne(e => e.Cliente)
        .HasForeignKey<Cliente>(e => e.IdUsuarioFk)
        .IsRequired(false); // Indica que la relación es opcional */

    }
}