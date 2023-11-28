using TiendaAPI.Common.DTO.Response;

namespace TiendaAPI.Services
{
    public interface IProductoPedidoService
    {
        Task<ProductoPedidoResponse> CreateProductoPedidoAsync(int ProductoId, int PedidoId);
        Task<List<ProductoPedidoResponse>> GetProductoPedidoList();
        Task<bool> DeleteProductoPedido(int ProductoPedidoId);
        Task<ProductoPedidoResponse> GetProductoPedidoById(int ProductoPedidoId);
    }
}
