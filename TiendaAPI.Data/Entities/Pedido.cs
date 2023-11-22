using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaAPI.Data.Entities.Enums;

namespace TiendaAPI.Data.Entities
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        public List<ProductoPedido> ProductosPedido { get; set; }
        public double Total { get; set; }
        public EstadoPedidoEnum Estado { get; set; }
    }
}
