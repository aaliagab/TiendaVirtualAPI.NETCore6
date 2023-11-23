using TiendaAPI.Common.DTO.Response;
using TiendaAPI.Data;
using TiendaAPI.Data.Entities;
using TiendaAPI.Data.UoW;

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

        public Task<bool> DeleteCliente(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteResponse> GetClienteById(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClienteResponse>> GetClienteList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCliente(int ClienteId, string nombre, string direccion)
        {
            throw new NotImplementedException();
        }
    }
}