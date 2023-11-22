using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAPI.Common.DTO.Request
{
    public class ProductoPedidoRequest
    {
        public int ProductoId { get; set; }
        public int PedidoId { get; set; }
    }
}
