using PhoneAnalyzer.Grids
;
namespace PhoneAnalyzer.Classes
{
    partial class AtcCall
    {
        public GridAtcCall ToGrid()
        {
            return new GridAtcCall
            {
                Id = Id,
                Subdivision = Subdivision.ToString(),
                ToNumber = ToNumber,
                Date = Date.ToShortDateString(),
                Duration = Duration + " сек",
            };
        }
    }
}
