using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAnalyzer.Grids
{
    public class GridCall
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string ToNumber { get; set; }
        public string Date { get; set; }
        public string Tariff { get; set; }
        public string Duration { get; set; }
        public string Price { get; set; }
    }
}
