using PhoneAnalyzer.Grids;

namespace PhoneAnalyzer.Classes
{
    partial class Worker
    {
        public GridWorker ToGrid()
        {
            return new GridWorker { Id = Id, Fio = Fio, Subdivision = Subdivision.ToString(), Salary = Salary + " руб." };
        }

        public override string ToString()
        {
            return Fio;
        }
    }
}
