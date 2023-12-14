using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Producto");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);
        
        builder.Property(d => d.Titulo)
        .HasColumnName("Titulo")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired();
        
        builder.Property(d => d.Imagen)
        .HasColumnName("Imagen")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();
        
        builder.Property(d => d.Precio)
        .HasColumnName("Precio")
        .HasColumnType("decimal(10.2)")
        .IsRequired();
        
        builder.Property(d => d.Stok)
        .HasColumnName("Stok")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.HasOne(d => d.Categoria)
        .WithMany(d => d.Productos)
        .HasForeignKey(d => d.IdCategoriaFk);

    }
}