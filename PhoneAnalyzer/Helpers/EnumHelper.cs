using System;

namespace PhoneAnalyzer.Helpers
{
    public static class EnumHelper
    {
        public static T FromString<T>(string value)
        {
            return (T) Enum.Parse(typeof (T), value);
        }
        /*

        public static string Huminize(MealType mealType)
        {
            switch (mealType)
            {
                case MealType.No:
                    return "No";

                case MealType.BB:
                    return "BB - завтрак";

                case MealType.HB:
                    return "HB - двухразовое";

                case MealType.FB:
                    return "FB - трехразовое";

                default:
                    return "Error";
            }
        }

        public static string Huminize(TransportType transportType)
        {
            switch (transportType)
            {
                case TransportType.Air:
                    return "Авиатранспорт";

                case TransportType.Train:
                    return "Ж/Д транспорт";

                case TransportType.Auto:
                    return "Автотранспорт";

                default:
                    return "Error";
            }
        }

        public static string Huminize(HotelType hotelType)
        {
            switch (hotelType)
            {
                case HotelType.Stars2:
                    return "2*";

                case HotelType.Stars3:
                    return "3*";

                case HotelType.Stars4:
                    return "4*";

                case HotelType.Stars5:
                    return "5*";

                default:
                    return "Error";
            }
        }
         * */
    }
}