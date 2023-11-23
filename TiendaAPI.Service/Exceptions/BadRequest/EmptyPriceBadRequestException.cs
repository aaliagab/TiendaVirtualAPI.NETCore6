using TiendaAPI.Services.Exceptions.BaseExceptions;

namespace TiendaAPI.Services.Exceptions.BadRequest
{
    public class EmptyPriceBadRequestException : BaseBadRequestException
    {
        public EmptyPriceBadRequestException() : base()
        {
        }
    }
}