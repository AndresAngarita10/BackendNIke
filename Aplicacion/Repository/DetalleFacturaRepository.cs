
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class DetalleFacturaRepository : GenericRepo<DetalleFactura>, IDetalleFactura
{
    protected readonly ApiContext _context;

    public DetalleFacturaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleFactura>> GetAllAsync()
    {
        return await _context.DetalleFacturas
            .ToListAsync();
    }

    public override async Task<DetalleFactura> GetByIdAsync(int id)
    {
        return await _context.DetalleFacturas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

}