﻿using Microsoft.Extensions.Localization;

namespace APICore.Services.Exceptions
{
    public class EmptyPriceBadRequestException : BaseBadRequestException
    {
        public EmptyPriceBadRequestException(IStringLocalizer<object> localizer) : base()
        {
            CustomCode = 400011;
            CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}