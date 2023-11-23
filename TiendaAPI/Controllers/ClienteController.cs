using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TiendaAPI.Common.DTO.Request;
using TiendaAPI.Common.DTO.Response;
using TiendaAPI.Services;

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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> create(ClienteRequest cliente) {
            
            ClienteResponse clienteResponse = 
                await _clienteService.CreateClienteAsync(cliente.Nombre, cliente.Direccion);

            return Ok(clienteResponse);
        }
    }
}
