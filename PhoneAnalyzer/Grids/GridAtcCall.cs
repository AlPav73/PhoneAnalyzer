﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAnalyzer.Grids
{
    public class GridAtcCall
    {
        public int Id { get; set; }
        public string Subdivision { get; set; }
        public string ToNumber { get; set; }
        public string Date { get; set; }
        public string Duration { get; set; }
    }
}
