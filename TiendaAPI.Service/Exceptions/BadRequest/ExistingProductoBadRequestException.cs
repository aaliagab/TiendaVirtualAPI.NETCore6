using Microsoft.Extensions.Localization;

namespace APICore.Services.Exceptions
{
    public class ExistingProductoBadRequestException : BaseBadRequestException
    {
        public ExistingProductoBadRequestException(IStringLocalizer<object> localizer) : base()
        {
            CustomCode = 400001;
            CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}