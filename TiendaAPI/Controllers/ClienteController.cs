using Microsoft.AspNetCore.Mvc;
using System.Net;
using TiendaAPI.Common.DTO.Request;
using TiendaAPI.Common.DTO.Response;
using TiendaAPI.Services;
using TiendaAPI.Services.Exceptions.NotFound;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> create(ClienteRequest cliente) {
            
            ClienteResponse clienteResponse = 
                await _clienteService.CreateClienteAsync(cliente.Nombre, cliente.Direccion);

            return Ok(clienteResponse);
        }

        [HttpGet("list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> list() { 
            List<ClienteResponse> clienteResponses = 
                await _clienteService.GetClienteList();
            return Ok(clienteResponses);
        }

        [HttpGet("by-id")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> byId(int clienteId)
        {
            try {
                var clienteResponse =
                await _clienteService.GetClienteById(clienteId);
                return Ok(clienteResponse);
            }
            catch (ClienteNotFoundException ex)
            {
                return NotFound("No existe un cliente con ese Id");
            }
        }

        [HttpDelete("delete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> delete(int clienteId) {
            var wasDelete =  await _clienteService.DeleteCliente(clienteId);
            if(wasDelete)
            {
                return NoContent();
            }
            return BadRequest("No se ha eliminado el cliente, debido algun problema en su entrada");
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> update(int ClienteId, string nombre, string direccion) {
            try {
                var clienteResponse = await _clienteService.UpdateCliente(ClienteId, nombre, direccion);
                return Ok(clienteResponse);
            }catch(ClienteNotFoundException ex) { 
                return NotFound("No existe un cliente con ese Id");
            }
        }

    }
}
