namespace PhoneAnalyzer.Helpers
{
    /// <summary>
    /// Содержит методы, которые помогают работать со строками
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// Возвращает строку месяца
        /// </summary>
        /// <param name="month">Месяц</param>
        /// <returns>Строка месяца</returns>
        public static string GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "январь";
                case 2:
                    return "февраль";
                case 3:
                    return "март";
                case 4:
                    return "апрель";
                case 5:
                    return "май";
                case 6:
                    return "июнь";
                case 7:
                    return "июль";
                case 8:
                    return "август";
                case 9:
                    return "сентябрь";
                case 10:
                    return "октябрь";
                case 11:
                    return "ноябрь";
                case 12:
                    return "декабрь";
                default:
                    return "нет такого месяца";
            }
        }

        #region RurPhrase

        /// <summary>
        /// Возвращает цену прописью
        /// </summary>
        /// <param name="money">Цена в рублях</param>
        /// <returns>Цена прописью</returns>
        public static string RurPhrase(decimal money)
        {
            return CurPhrase(money, "рубль", "рубля", "рублей", "копейка", "копейки", "копеек");
        }

        private static string NumPhrase(ulong value, bool isMale)
        {
            if (value == 0UL)
            {
                return "Ноль";
            }
            string[] dek1 =
            {
                "", " од", " дв", " три", " четыре", " пять", " шесть", " семь", " восемь", " девять", " десять", " одиннадцать", " двенадцать",
                " тринадцать", " четырнадцать", " пятнадцать", " шестнадцать", " семнадцать", " восемнадцать", " девятнадцать"
            };
            string[] dek2 = { "", "", " двадцать", " тридцать", " сорок", " пятьдесят", " шестьдесят", " семьдесят", " восемьдесят", " девяносто" };
            string[] dek3 = { "", " сто", " двести", " триста", " четыреста", " пятьсот", " шестьсот", " семьсот", " восемьсот", " девятьсот" };
            string[] Th = { "", "", " тысяч", " миллион", " миллиард", " триллион", " квадрилион", " квинтилион" };
            string str = "";
            for (byte th = 1; value > 0; th++)
            {
                var gr = (ushort) (value % 1000);
                value = (value - gr) / 1000;
                if (gr > 0)
                {
                    var d3 = (byte) ((gr - gr % 100) / 100);
                    var d1 = (byte) (gr % 10);
                    var d2 = (byte) ((gr - d3 * 100 - d1) / 10);
                    if (d2 == 1)
                    {
                        d1 += 10;
                    }
                    bool ismale = (th > 2) || ((th == 1) && isMale);
                    str = dek3[d3] + dek2[d2] + dek1[d1] + EndDek1(d1, ismale) + Th[th] + EndTh(th, d1) + str;
                }
            }

            str = str.Substring(1, 1).ToUpper() + str.Substring(2);
            return str;
        }

        public static string CurPhrase(decimal money, string word1, string word234, string wordmore, string sword1, string sword234, string swordmore)
        {
            money = decimal.Round(money, 2);
            decimal decintpart = decimal.Truncate(money);
            ulong intpart = decimal.ToUInt64(decintpart);
            string str = NumPhrase(intpart, true) + " ";
            var endpart = (byte) (intpart % 100UL);
            if (endpart > 19)
            {
                endpart = (byte) (endpart % 10);
            }
            switch (endpart)
            {
                case 1:
                    str += word1;
                    break;
                case 2:
                case 3:
                case 4:
                    str += word234;
                    break;
                default:
                    str += wordmore;
                    break;
            }
            byte fracpart = decimal.ToByte((money - decintpart) * 100M);
            str += " " + ((fracpart < 10) ? "0" : "") + fracpart + " ";
            if (fracpart > 19)
            {
                fracpart = (byte) (fracpart % 10);
            }
            switch (fracpart)
            {
                case 1:
                    str += sword1;
                    break;
                case 2:
                case 3:
                case 4:
                    str += sword234;
                    break;
                default:
                    str += swordmore;
                    break;
            }
            
            return str;
        }

        private static string EndTh(byte thNum, byte dek)
        {
            bool in234 = ((dek >= 2) && (dek <= 4));
            bool more4 = ((dek > 4) || (dek == 0));
            if (((thNum > 2) && in234) || ((thNum == 2) && (dek == 1)))
            {
                return "а";
            }
            if ((thNum > 2) && more4)
            {
                return "ов";
            }
            if ((thNum == 2) && in234)
            {
                return "и";
            }
            return "";
        }

        private static string EndDek1(byte dek, bool isMale)
        {
            if ((dek > 2) || (dek == 0))
            {
                return "";
            }

            if (dek == 1)
            {
                if (isMale)
                {
                    return "ин";
                }
                return "на";
            }

            if (isMale)
            {
                return "а";
            }
            return "е";
        }

        #endregion
    }
}