using TiendaAPI.Services.Exceptions.BaseExceptions;

namespace TiendaAPI.Services.Exceptions.Forbidden
{
    public class AccountInactiveForbiddenException : BaseForbiddenException
    {
        public AccountInactiveForbiddenException() : base()
        {
        }
    }
}