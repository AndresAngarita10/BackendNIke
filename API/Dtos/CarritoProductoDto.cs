
using Dominio.Entities;

namespace API.Dtos;

public class CarritoProductoDto : BaseEntity
{
    public int IdCarritoFk { get; set; }
    public int IdProductoFk { get; set; }
    public int Cantidad { get; set; }
}