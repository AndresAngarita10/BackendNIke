

using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CarritoConfiguration : IEntityTypeConfiguration<Carrito>
{
    public void Configure(EntityTypeBuilder<Carrito> builder)
    {
        builder.ToTable("carrito");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.Vendido)
        .HasColumnName("Vendido")
        .HasColumnType("TINYINT(1)")
        .IsRequired();

        builder.HasOne(d => d.Cliente)
        .WithMany(d => d.Carritos)
        .HasForeignKey(d => d.IdClienteFk);
    }
}