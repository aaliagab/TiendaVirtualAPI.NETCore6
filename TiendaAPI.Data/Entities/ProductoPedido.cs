using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAPI.Data.Entities
{
    public class ProductoPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoPedidoId { get; set; }
        public int ProductoId { get; set; }
        public int PedidoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }
        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }
    }
}
