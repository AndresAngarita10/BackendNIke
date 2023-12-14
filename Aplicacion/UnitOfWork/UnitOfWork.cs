using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork  : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;

    private RolRepository _Rol;
    private UsuarioRepository _usuarios;
    private CarritoRepository _Carritos;
    private CarritoProductoRepository _CarritoProductos;
    private CategoriaRepository _Categorias;
    private ClienteRepository _Clientes;
    private DetalleFacturaRepository _DetalleFacturas;
    private FacturaRepository _Facturas;
    private ProductoRepository _Productos;

    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }
    
    public IRol Roles
    {
        get{
            if(_Rol== null)
            {
                _Rol= new RolRepository(_context);
            }
            return _Rol;
        }
    }
    
    public IUsuario Usuarios
    {
        get{
            if(_usuarios== null)
            {
                _usuarios= new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public ICarrito Carritos 
    {
        get{
            if(_Carritos== null)
            {
                _Carritos= new CarritoRepository(_context);
            }
            return _Carritos;
        }
    }

    public ICarritoProducto CarritoProductos 
    {
        get{
            if(_CarritoProductos== null)
            {
                _CarritoProductos= new CarritoProductoRepository(_context);
            }
            return _CarritoProductos;
        }
    }

    public ICategoria Categorias 
    {
        get{
            if(_Categorias== null)
            {
                _Categorias= new CategoriaRepository(_context);
            }
            return _Categorias;
        }
    }

    public ICliente Clientes 
    {
        get{
            if(_Clientes== null)
            {
                _Clientes= new ClienteRepository(_context);
            }
            return _Clientes;
        }
    }

    public IDetalleFactura DetalleFacturas 
    {
        get{
            if(_DetalleFacturas== null)
            {
                _DetalleFacturas= new DetalleFacturaRepository(_context);
            }
            return _DetalleFacturas;
        }
    }

    public IFactura Facturas
    {
        get{
            if(_Facturas== null)
            {
                _Facturas= new FacturaRepository(_context);
            }
            return _Facturas;
        }
    }

    public IProducto Productos
    {
        get{
            if(_Productos== null)
            {
                _Productos= new ProductoRepository(_context);
            }
            return _Productos;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
