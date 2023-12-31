
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class FacturaRepository : GenericRepo<Factura>, IFactura
{
    protected readonly ApiContext _context;

    public FacturaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Factura>> GetAllAsync()
    {
        return await _context.Facturas
            .ToListAsync();
    }

    public override async Task<Factura> GetByIdAsync(int id)
    {
        return await _context.Facturas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

}