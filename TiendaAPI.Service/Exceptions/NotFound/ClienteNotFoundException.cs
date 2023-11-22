using Microsoft.Extensions.Localization;

namespace APICore.Services.Exceptions
{
    public class ClienteNotFoundException : BaseNotFoundException
    {
        public ClienteNotFoundException(IStringLocalizer<object> localizer) : base()
        {
            CustomCode = 404004;
            CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}