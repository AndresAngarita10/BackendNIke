
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CarritoProductoConfiguration : IEntityTypeConfiguration<CarritoProducto>
{
    public void Configure(EntityTypeBuilder<CarritoProducto> builder)
    {
        builder.ToTable("CarritoProducto");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.Cantidad)
        .HasColumnName("Cantidad")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.HasOne(c => c.Carrito)
        .WithMany(c => c.CarritoProductos)
        .HasForeignKey(c => c.IdCarritoFk);
        
        builder.HasOne(c => c.Producto)
        .WithMany(c => c.CarritoProductos)
        .HasForeignKey(c => c.IdProductoFk);

    }
}