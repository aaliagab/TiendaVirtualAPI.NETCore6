using Microsoft.AspNetCore.Mvc;
using System.Net;
using TiendaAPI.Common.DTO.Request;
using TiendaAPI.Common.DTO.Response;
using TiendaAPI.Services;
using TiendaAPI.Services.Exceptions.NotFound;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/ProductoPedidos")]
    public class ProductoPedidoController : Controller
    {
        private readonly IProductoPedidoService _ProductoPedidoService;

        public ProductoPedidoController(IProductoPedidoService ProductoPedidoService)
        {
            _ProductoPedidoService = ProductoPedidoService ?? throw new ArgumentNullException(nameof(ProductoPedidoService));
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> create(ProductoPedidoRequest ProductoPedido) {
            
            ProductoPedidoResponse ProductoPedidoResponse = 
                await _ProductoPedidoService.CreateProductoPedidoAsync(ProductoPedido.ProductoId, ProductoPedido.PedidoId);

            return Ok(ProductoPedidoResponse);
        }

        [HttpGet("list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> list() { 
            List<ProductoPedidoResponse> ProductoPedidoResponses = 
                await _ProductoPedidoService.GetProductoPedidoList();
            return Ok(ProductoPedidoResponses);
        }

        [HttpGet("by-id")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> byId(int ProductoPedidoId)
        {
            try {
                var ProductoPedidoResponse =
                await _ProductoPedidoService.GetProductoPedidoById(ProductoPedidoId);
                return Ok(ProductoPedidoResponse);
            }
            catch (ProductoPedidoNotFoundException ex)
            {
                return NotFound("No existe un ProductoPedido con ese Id");
            }
        }

        [HttpDelete("delete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> delete(int ProductoPedidoId) {
            var wasDelete =  await _ProductoPedidoService.DeleteProductoPedido(ProductoPedidoId);
            if(wasDelete)
            {
                return NoContent();
            }
            return BadRequest("No se ha eliminado el ProductoPedido, debido algun problema en su entrada");
        }

    }
}
