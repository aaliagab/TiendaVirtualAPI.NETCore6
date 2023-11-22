using System;
using System.Threading.Tasks;
using TiendaAPI.Data.Entities;
using TiendaAPI.Data.Repository;

namespace TiendaAPI.Data.UoW
{
    public interface IUnitOfWork
    {
        IGenericRepository<Cliente> ClienteRepository { get; set; }
        IGenericRepository<Pedido> PedidoRepository { get; set; }
        IGenericRepository<Producto> ProductoRepository { get; set; }
        IGenericRepository<ProductoPedido> ProductoPedidoRepository { get; set; }

        Task<int> CommitAsync();
    }
}