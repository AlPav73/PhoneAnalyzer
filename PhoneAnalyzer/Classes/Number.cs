using System;
using PhoneAnalyzer.Grids;
using PhoneAnalyzer.Helpers;
using PhoneAnalyzer.Type;

namespace PhoneAnalyzer.Classes
{
    partial class Number
    {
        public NumberType NumberType
        {
            get{return (NumberType) Type;}
            set{Type = (int)value;}
        }

        public GridNumber ToGrid()
        {
            return new GridNumber
            {
                Id = Id, 
                Worker = Worker.ToString(),
                PhoneNumber = PhoneNumber, 
                NumberType = EnumHelper.Huminize(NumberType)
            };
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", PhoneNumber, EnumHelper.Huminize(NumberType));
        }
    }
}
