using TiendaAPI.Data.Entities.Enums;

namespace TiendaAPI.Common.DTO.Request
{
    public class PedidoRequest
    {
        public int ClienteId { get; set; }
        public EstadoPedidoEnum Estado { get; set; }
    }
}
