using System;
using System.Threading.Tasks;
using TiendaAPI.Data.Entities;
using TiendaAPI.Data.Repository;

namespace TiendaAPI.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CoreDbContext _context;

        public UnitOfWork(CoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ClienteRepository ??= new GenericRepository<Cliente>(context);
            PedidoRepository ??= new GenericRepository<Pedido>(context);
            ProductoRepository ??= new GenericRepository<Producto>(context);
            ProductoPedidoRepository ??= new GenericRepository<ProductoPedido>(_context);
        }

        public IGenericRepository<Cliente> ClienteRepository { get; set; }
        public IGenericRepository<Pedido> PedidoRepository { get; set; }
        public IGenericRepository<Producto> ProductoRepository { get; set; }
        public IGenericRepository<ProductoPedido> ProductoPedidoRepository { get; set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}