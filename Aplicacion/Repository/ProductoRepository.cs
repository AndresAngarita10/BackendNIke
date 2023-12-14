
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class ProductoRepository : GenericRepo<Producto>, IProducto
{
    protected readonly ApiContext _context;

    public ProductoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos
            .ToListAsync();
    }

    public override async Task<Producto> GetByIdAsync(int id)
    {
        return await _context.Productos
        .FirstOrDefaultAsync(p => p.Id == id);
    }

}