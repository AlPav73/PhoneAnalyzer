using System;
using PhoneAnalyzer.Type;

namespace PhoneAnalyzer.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Переводит строкове значение enum в enum
        /// </summary>
        /// <typeparam name="T">Тип enum</typeparam>
        /// <param name="value">Строковое значение enum</param>
        /// <returns></returns>
        public static T FromString<T>(string value)
        {
            return (T) Enum.Parse(typeof (T), value);
        }

        /// <summary>
        /// Преобразование enum в строку понятную человеку
        /// </summary>
        /// <param name="numberType">Enum</param>
        /// <returns></returns>
        public static string Huminize(NumberType numberType)
        {
            switch (numberType)
            {
                case NumberType.In:
                    return "Внутренний";

                case NumberType.Out:
                    return "Внешний";

                default:
                    return "Error";
            }
        }

        public static string Huminize(TariffType tariffType)
        {
            switch (tariffType)
            {
                case TariffType.One:
                    return "МирТелеком";

                case TariffType.Two:
                    return "ГородТелеком";

                case TariffType.Three:
                    return "МестныйТелеком";

                default:
                    return "Error";
            }
        }
    }
}