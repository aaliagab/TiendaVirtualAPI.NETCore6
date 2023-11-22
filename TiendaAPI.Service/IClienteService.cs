using TiendaAPI.Common.DTO.Response;

namespace APICore.Services
{
    public interface IClienteService
    {
        Task<ClienteResponse> CreateClienteAsync(string nombre, string direccion);
        Task<List<ClienteResponse>> GetClienteList();
        Task<bool> UpdateCliente(int ClienteId, string nombre, string direccion);
        Task<bool> DeleteCliente(int clienteId);
        Task<ClienteResponse> GetClienteById(int clienteId);
    }
}