using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categoria");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.Nombre)
        .HasColumnName("Nombre")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

    }
}