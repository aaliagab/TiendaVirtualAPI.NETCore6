﻿using Microsoft.Extensions.Localization;

namespace APICore.Services.Exceptions
{
    public class EmptyNameBadRequestException : BaseBadRequestException
    {
        public EmptyNameBadRequestException(IStringLocalizer<object> localizer) : base()
        {
            CustomCode = 400011;
            CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}