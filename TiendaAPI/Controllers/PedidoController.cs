using Microsoft.AspNetCore.Mvc;
using System.Net;
using TiendaAPI.Common.DTO.Request;
using TiendaAPI.Common.DTO.Response;
using TiendaAPI.Data.Entities.Enums;
using TiendaAPI.Services;
using TiendaAPI.Services.Exceptions.NotFound;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/Pedidos")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _PedidoService;

        public PedidoController(IPedidoService PedidoService)
        {
            _PedidoService = PedidoService ?? throw new ArgumentNullException(nameof(PedidoService));
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> create(PedidoRequest Pedido) {
            
            PedidoResponse PedidoResponse = 
                await _PedidoService.CreatePedidoAsync(Pedido.ClienteId, Pedido.Estado);

            return Ok(PedidoResponse);
        }

        [HttpGet("list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> list() { 
            List<PedidoResponse> PedidoResponses = 
                await _PedidoService.GetPedidoList();
            return Ok(PedidoResponses);
        }

        [HttpGet("by-id")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> byId(int PedidoId)
        {
            try {
                var PedidoResponse =
                await _PedidoService.GetPedidoById(PedidoId);
                return Ok(PedidoResponse);
            }
            catch (PedidoNotFoundException ex)
            {
                return NotFound("No existe un Pedido con ese Id");
            }
        }

        [HttpDelete("delete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> delete(int PedidoId) {
            var wasDelete =  await _PedidoService.DeletePedido(PedidoId);
            if(wasDelete)
            {
                return NoContent();
            }
            return BadRequest("No se ha eliminado el Pedido, debido algun problema en su entrada");
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> update(int PedidoId, int ClienteId, EstadoPedidoEnum estado) {
            try {
                var PedidoResponse = await _PedidoService.UpdatePedido(PedidoId, ClienteId, estado);
                return Ok(PedidoResponse);
            }catch(PedidoNotFoundException ex) { 
                return NotFound("No existe un Pedido con ese Id");
            }
        }

    }
}
