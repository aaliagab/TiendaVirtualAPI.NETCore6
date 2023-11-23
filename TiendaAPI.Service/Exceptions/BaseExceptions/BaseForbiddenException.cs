using System.Net;

namespace TiendaAPI.Services.Exceptions.BaseExceptions
{
    public class BaseForbiddenException : CustomBaseException
    {
        public BaseForbiddenException() : base()
        {
            HttpCode = (int)HttpStatusCode.Forbidden;
        }
    }
}