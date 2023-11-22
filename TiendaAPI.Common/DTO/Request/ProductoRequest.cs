using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAPI.Common.DTO.Request
{
    public class ProductoRequest
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int StockDisponible { get; set; }
    }
}
