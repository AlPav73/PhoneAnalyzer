using PhoneAnalyzer.Grids;

namespace PhoneAnalyzer.Classes
{
    partial class Subdivision
    {
        public GridSubdivision ToGrid()
        {
            return new GridSubdivision { Id = Id, Fio = DirectorFio, Name = Name, Email = Email };
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
