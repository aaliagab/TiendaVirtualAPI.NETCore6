using TiendaAPI.Services.Exceptions.BaseExceptions;

namespace TiendaAPI.Services.Exceptions.Forbidden
{
    public class AccountDeactivatedForbiddenException : BaseForbiddenException
    {
        public AccountDeactivatedForbiddenException() : base()
        {
        }
    }
}