using TiendaAPI.Common.DTO.Response;
using TiendaAPI.Data;
using TiendaAPI.Data.Entities;
using TiendaAPI.Data.UoW;
using TiendaAPI.Services.Exceptions.NotFound;

namespace TiendaAPI.Services.Impl
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _uow;
        private readonly CoreDbContext _dbContext;

        public ClienteService(IUnitOfWork uow, CoreDbContext dbContext)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<ClienteResponse> CreateClienteAsync(string nombre, string direccion)
        {
            var cliente = new Cliente
            {
                Nombre = nombre,
                Direccion = direccion
            };

            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();

            return new ClienteResponse
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion
            };
        }

        public async Task<bool> DeleteCliente(int clienteId)
        {
            var cliente = await _uow.ClienteRepository.GetAsync(clienteId);
            if (cliente != null)
            {
                _uow.ClienteRepository.Delete(cliente);
                await _uow.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<ClienteResponse> GetClienteById(int clienteId)
        {
            var cliente = await _uow.ClienteRepository.GetAsync(clienteId);
            var clienteResponse = await mapCliente(cliente);
            return clienteResponse;
        }

        public async Task<List<ClienteResponse>> GetClienteList()
        {
            List<ClienteResponse> clienteResponses = new List<ClienteResponse>();
            var clientes = await _uow.ClienteRepository.GetAllAsync();
            foreach (var cliente in clientes)
            {
                clienteResponses.Add(await mapCliente(cliente));
            }

            return clienteResponses;
        }

        public async Task<ClienteResponse> UpdateCliente(int ClienteId, string nombre, string direccion)
        {
            if (_uow.ClienteRepository.GetAsync(ClienteId) != null)
            {
                await _uow.ClienteRepository.UpdateAsync(new Cliente
                {
                    ClienteId = ClienteId,
                    Nombre = nombre,
                    Direccion = direccion
                }, ClienteId);
                await _uow.CommitAsync();

                var cliente = await _uow.ClienteRepository.GetAsync(ClienteId);
                return await mapCliente(cliente);
            }
            else {
                throw new ClienteNotFoundException();
            }
            
        }

        public async Task<ClienteResponse> mapCliente(Cliente cliente) {
            //pedidos
            int clienteIdDeseado = cliente.ClienteId;
            var pedidos = await _uow.PedidoRepository.FindAllAsync
                (
                pedido => pedido.ClienteId == clienteIdDeseado
                );
            List<PedidoResponse> pedidoResponses = new List<PedidoResponse>();
            foreach (var pedido in pedidos)
            {
                //ProductoPedido
                int pedidoIdDeseado = pedido.PedidoId;
                var productosPedidos = await _uow.ProductoPedidoRepository.FindAllAsync
                    (
                    pp => pp.PedidoId == pedidoIdDeseado
                    );
                List<ProductoPedidoResponse> ppResponses = new List<ProductoPedidoResponse>();
                foreach (var productoPedido in productosPedidos)
                {
                    ppResponses.Add(new ProductoPedidoResponse
                    {
                        ProductoPedidoId = productoPedido.ProductoPedidoId,
                        ProductoId = productoPedido.ProductoId,
                        PedidoId = productoPedido.PedidoId
                    });
                }

                pedidoResponses.Add(new PedidoResponse
                {
                    PedidoId = pedido.PedidoId,
                    ClienteId = pedido.ClienteId,
                    ProductosPedido = ppResponses,
                    Total = pedido.Total,
                    Estado = pedido.Estado
                });
            }
            return new ClienteResponse
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                PedidosRealizados = pedidoResponses
            };
        }
    }
}