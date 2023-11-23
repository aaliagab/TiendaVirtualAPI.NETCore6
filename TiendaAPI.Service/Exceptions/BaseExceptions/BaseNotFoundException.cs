using System.Net;

namespace TiendaAPI.Services.Exceptions.BaseExceptions
{
    public class BaseNotFoundException : CustomBaseException
    {
        public BaseNotFoundException() : base()
        {
            HttpCode = (int)HttpStatusCode.NotFound;
        }
    }
}