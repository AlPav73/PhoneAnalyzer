using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Properties;

namespace PhoneAnalyzer
{
    internal static class DataBase
    {
        private static readonly PaDbDataContext Db = new PaDbDataContext(Settings.Default.PaDbConnectionString);

        public static PaDbDataContext Context
        {
            get { return Db; }
        }
    }
}