using System.Net;

namespace TiendaAPI.Services.Exceptions.BaseExceptions
{
    public class BaseUnauthorizedException : CustomBaseException
    {
        public BaseUnauthorizedException() : base()
        {
            HttpCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}