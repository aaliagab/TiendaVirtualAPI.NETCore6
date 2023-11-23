using System.Net;

namespace TiendaAPI.Services.Exceptions.BaseExceptions
{
    public class BaseBadRequestException : CustomBaseException
    {
        public BaseBadRequestException() : base()
        {
            HttpCode = (int)HttpStatusCode.BadRequest;
        }
    }
}