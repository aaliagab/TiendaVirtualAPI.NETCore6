using Microsoft.Extensions.Localization;
using TiendaAPI.Services.Exceptions.BaseExceptions;

namespace TiendaAPI.Services.Exceptions.NotFound
{
    public class ClienteNotFoundException : BaseNotFoundException
    {
        public ClienteNotFoundException() : base()
        {
        }
    }
}