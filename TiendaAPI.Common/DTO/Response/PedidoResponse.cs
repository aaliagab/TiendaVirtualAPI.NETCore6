using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaAPI.Common.DTO.Enums;

namespace TiendaAPI.Common.DTO.Response
{
    public class PedidoResponse
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public List<ProductoPedidoResponse> ProductosPedido { get; set; } = new List<ProductoPedidoResponse>();
        public double Total { get; set; }
        public EstadoPedidoEnum Estado { get; set; }
    }
}
