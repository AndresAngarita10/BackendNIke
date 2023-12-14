
namespace Dominio.Entities;

public class Producto : BaseEntity
{
    public string Titulo { get; set; }
    public string Imagen { get; set; }
    public int IdCategoriaFk { get; set; }
    public Categoria Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stok { get; set; }
    public ICollection<CarritoProducto> CarritoProductos { get; set; }
}
