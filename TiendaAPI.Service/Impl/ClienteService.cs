using APICore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using TiendaAPI.Common.DTO.Response;
using TiendaAPI.Data.UoW;

namespace TiendaAPI.Service.Impl
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _uow;
        private readonly IStringLocalizer<IClienteService> _localizer;

        public ClienteService(IUnitOfWork uow, IStringLocalizer<IClienteService> localizer)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        }

        public Task<ClienteResponse> CreateClienteAsync(string nombre, string direccion)
        {
            throw new NotImplementedException();
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