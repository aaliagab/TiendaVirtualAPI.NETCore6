using TiendaAPI.Data.Entities.Enums;

namespace TiendaAPI.Common.DTO.Response
{
    public class PedidoResponse
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public List<ProductoPedidoResponse> ProductosPedido { get; set; } = new List<ProductoPedidoResponse>();
        public double Total { get; set; } = 0;
        public EstadoPedidoEnum Estado { get; set; }
    }
}
