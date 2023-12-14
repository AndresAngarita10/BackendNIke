using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{
    public void Configure(EntityTypeBuilder<Factura> builder)
    {
        builder.ToTable("Factura");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);
        
        builder.Property(d => d.PrecioTotal)
        .HasColumnName("PrecioTotal")
        .HasColumnType("decimal(10.2)")
        .IsRequired();
        
        builder.Property(d => d.CantidadTotal)
        .HasColumnName("CantidadTotal")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.HasOne(d => d.Cliente)
        .WithMany(d => d.Facturas)
        .HasForeignKey(d => d.IdClienteFk);

    }
}