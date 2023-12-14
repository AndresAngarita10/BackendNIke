
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DetalleFacturaConfiguration : IEntityTypeConfiguration<DetalleFactura>
{
    public void Configure(EntityTypeBuilder<DetalleFactura> builder)
    {
        builder.ToTable("DetalleFactura");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.PrecioUnitario)
        .HasColumnName("PrecioUnitario")
        .HasColumnType("decimal(10.2)")
        .IsRequired();
        
        builder.Property(d => d.Cantidad)
        .HasColumnName("Cantidad")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.HasOne(d => d.Factura)
        .WithMany(d => d.DetalleFacturas)
        .HasForeignKey(d => d.IdFacturaFk);
        
        builder.HasOne(d => d.CarritoProducto)
        .WithMany(d => d.DetalleFacturas)
        .HasForeignKey(d => d.IdCarritoProductoFk);

    }
}