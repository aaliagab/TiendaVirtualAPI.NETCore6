using Microsoft.Extensions.Localization;

namespace APICore.Services.Exceptions
{
    public class PedidoNotFoundException : BaseNotFoundException
    {
        public PedidoNotFoundException(IStringLocalizer<object> localizer) : base()
        {
            CustomCode = 404003;
            CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}