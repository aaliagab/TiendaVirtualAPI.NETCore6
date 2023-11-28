using TiendaAPI.Common.DTO.Response;
using TiendaAPI.Data.Entities.Enums;

namespace TiendaAPI.Services
{
    public interface IPedidoService
    {
        Task<PedidoResponse> CreatePedidoAsync(int ClienteId, EstadoPedidoEnum estado);
        Task<List<PedidoResponse>> GetPedidoList();
        Task<PedidoResponse> UpdatePedido(int PedidoId, int ClienteId, EstadoPedidoEnum estado);
        Task<bool> DeletePedido(int PedidoId);
        Task<PedidoResponse> GetPedidoById(int PedidoId);
    }
}
