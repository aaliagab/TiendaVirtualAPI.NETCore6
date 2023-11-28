using Microsoft.AspNetCore.Mvc;
using System.Net;
using TiendaAPI.Common.DTO.Request;
using TiendaAPI.Common.DTO.Response;
using TiendaAPI.Services;
using TiendaAPI.Services.Exceptions.NotFound;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _ProductoService;

        public ProductoController(IProductoService ProductoService)
        {
            _ProductoService = ProductoService ?? throw new ArgumentNullException(nameof(ProductoService));
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> create(ProductoRequest Producto) {
            
            ProductoResponse ProductoResponse = 
                await _ProductoService.CreateProductoAsync(Producto.Nombre, Producto.Precio, Producto.StockDisponible);

            return Ok(ProductoResponse);
        }

        [HttpGet("list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> list() { 
            List<ProductoResponse> ProductoResponses = 
                await _ProductoService.GetProductoList();
            return Ok(ProductoResponses);
        }

        [HttpGet("by-id")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> byId(int ProductoId)
        {
            try {
                var ProductoResponse =
                await _ProductoService.GetProductoById(ProductoId);
                return Ok(ProductoResponse);
            }
            catch (ProductoNotFoundException ex)
            {
                return NotFound("No existe un Producto con ese Id");
            }
        }

        [HttpDelete("delete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> delete(int ProductoId) {
            var wasDelete =  await _ProductoService.DeleteProducto(ProductoId);
            if(wasDelete)
            {
                return NoContent();
            }
            return BadRequest("No se ha eliminado el Producto, debido algun problema en su entrada");
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> update(int ProductoId, string nombre, double precio, int stockDisponible) {
            try {
                var ProductoResponse = await _ProductoService.UpdateProducto(ProductoId, nombre, precio, stockDisponible);
                return Ok(ProductoResponse);
            }catch(ProductoNotFoundException ex) { 
                return NotFound("No existe un Producto con ese Id");
            }
        }

    }
}
