using TiendaAPI.Services.Exceptions.BaseExceptions;

namespace TiendaAPI.Services.Exceptions.BadRequest
{
    public class EmptyNameBadRequestException : BaseBadRequestException
    {
        public EmptyNameBadRequestException() : base()
        {
        }
    }
}