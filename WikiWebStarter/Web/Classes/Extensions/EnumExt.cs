﻿using System;

namespace WikiWebStarter.Web.Classes.Extensions
{
    public static class EnumExt
    {

        public static bool ParseEnum<TEnum>(this TEnum iEnum, string enumValue, out TEnum parsedValue) where TEnum : struct
        {
            bool result = false;
            parsedValue = default(TEnum);


            if (Enum.TryParse(enumValue, out parsedValue))
            {
                if (Enum.IsDefined(typeof(TEnum), parsedValue))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
