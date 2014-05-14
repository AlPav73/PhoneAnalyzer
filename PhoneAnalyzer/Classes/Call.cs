using PhoneAnalyzer.Grids
;
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
                Duration = Duration + " сек",
                Price = Price + " руб."
            };
        }
    }
}
