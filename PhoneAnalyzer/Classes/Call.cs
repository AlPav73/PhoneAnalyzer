using PhoneAnalyzer.Grids
;
using PhoneAnalyzer.Helpers;
using PhoneAnalyzer.Type;

namespace PhoneAnalyzer.Classes
{
    partial class Call
    {
        public GridCall ToGrid()
        {
            return new GridCall
            {
                Id = Id,
                Number = Number.PhoneNumber,
                ToNumber = ToNumber,
                Date = Date.ToString(),
                Tariff = EnumHelper.Huminize((TariffType)Tariff),
                Duration = Duration + " сек",
                Price = Price + " руб."
            };
        }
    }
}
