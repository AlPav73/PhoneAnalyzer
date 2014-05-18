using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Properties;

namespace PhoneAnalyzer
{
    internal static class DataBase
    {
        public static PaDbDataContext Context
        {
            get { return new PaDbDataContext(Settings.Default.PaDbConnectionString); }
        }
    }
}