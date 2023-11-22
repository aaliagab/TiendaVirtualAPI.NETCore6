using Microsoft.Extensions.Localization;

namespace APICore.Services.Exceptions
{
    public class ProductoNotFoundException : BaseNotFoundException
    {
        public ProductoNotFoundException(IStringLocalizer<object> localizer) : base()
        {
            CustomCode = 404005;
            CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}