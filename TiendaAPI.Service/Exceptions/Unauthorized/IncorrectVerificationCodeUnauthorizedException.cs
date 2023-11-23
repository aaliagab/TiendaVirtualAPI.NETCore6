using TiendaAPI.Services.Exceptions.BaseExceptions;

namespace TiendaAPI.Services.Exceptions.Unauthorized
{
    public class IncorrectVerificationCodeUnauthorizedException : BaseUnauthorizedException
    {
        public IncorrectVerificationCodeUnauthorizedException() : base()
        {
        }
    }
}