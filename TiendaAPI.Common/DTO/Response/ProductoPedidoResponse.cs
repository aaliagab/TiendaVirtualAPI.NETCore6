using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAPI.Common.DTO.Response
{
    public class ProductoPedidoResponse
    {
        public int ProductoPedidoId { get; set; }
        public ProductoResponse Producto { get; set; }
        public PedidoResponse Pedido { get; set; }
    }
}
