using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace PhoneAnalyzer.Helpers
{
    internal class GoogleChrome
    {
        public List<URL> URLs = new List<URL>();

        public IEnumerable<URL> GetHistory()
        {
            // Get Current Users App Data
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string[] tempstr = documentsFolder.Split('\\');
            string tempstr1 = "";
            documentsFolder += "\\Google\\Chrome\\User Data\\Default";
            if (tempstr[tempstr.Length - 1] != "Local")
            {
                for (int i = 0; i < tempstr.Length - 1; i++)
                {
                    tempstr1 += tempstr[i] + "\\";
                }
                documentsFolder = tempstr1 + "Local\\Google\\Chrome\\User Data\\Default";
            }

            try
            {
                // Check if directory exists
                if (Directory.Exists(documentsFolder))
                {
                    return ExtractUserHistory(documentsFolder);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удаётся прочитать историю сайтов. Закройте GoogleChrome и проведите перерасчёт.");
            }
            return null;
        }

        private IEnumerable<URL> ExtractUserHistory(string folder)
        {
            // Get User history info
            DataTable historyDT = ExtractFromTable("urls", folder);

            // Loop each history entry

            DateTime dateFrom = DateTime.Now.Date.AddDays(1 - DateTime.Now.Date.Day);
            DateTime dateTo = DateTime.Now.Date.AddMonths(1).AddDays(1 - DateTime.Now.Date.Day);

            URLs.Clear();
            foreach (DataRow row in historyDT.Rows)
            {
                // Obtain URL and Title strings
                string url = row["url"].ToString();
                string title = row["title"].ToString();
                DateTime lastVisit = DateTime.FromFileTime(Int64.Parse(row["visit_time"].ToString()) * 10);

                if (dateFrom <= lastVisit && lastVisit <= dateTo)
                {
                    URLs.Add(new URL(url.Replace('\'', ' '), title.Replace('\'', ' '), "Google Chrome", lastVisit));
                }
            }

            return URLs;
        }

        private void DeleteFromTable(string table, string folder)
        {
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;

            // FireFox database file
            string dbPath = folder + "\\History";

            // If file exists
            if (File.Exists(dbPath))
            {
                // Data connection
                sql_con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;New=False;Compress=True;");

                // Open the Conn
                sql_con.Open();

                // Delete Query
                string CommandText = "delete from " + table;

                // Create command
                sql_cmd = new SQLiteCommand(CommandText, sql_con);

                sql_cmd.ExecuteNonQuery();

                // Clean up
                sql_con.Close();
            }
        }

        private DataTable ExtractFromTable(string table, string folder)
        {
            var dt = new DataTable();

            // FireFox database file
            string dbPath = folder + "\\History";

            // If file exists
            if (File.Exists(dbPath))
            {
                // Data connection
                var sqlCon = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;New=False;Compress=True;");

                // Open the Connection
                sqlCon.Open();
                sqlCon.CreateCommand();

                // Select Query


                string commandText = @"SELECT urls.url, urls.title, urls.visit_count, urls.typed_count, urls.last_visit_time, urls.hidden, visits.visit_time, visits.from_visit, visits.transition
FROM urls, visits
WHERE
 urls.id = visits.url";

                //string commandText = string.Format("select * from {0} where [last_visit_time] BETWEEN {1} AND {2}", table, dateFrom.ToString("yyyy-MM-dd"), dateTo.ToString("yyyy-MM-dd"));

                // Populate Data Table
                var db = new SQLiteDataAdapter(commandText, sqlCon);
                db.Fill(dt);

                // Clean up
                sqlCon.Close();
            }
            return dt;
        }
    }

    public class URL
    {
        public readonly string Browser;
        public readonly string Title;
        public readonly string Url;
        public readonly DateTime LastVisit;

        public URL(string url, string title, string browser, DateTime lastVisit)
        {
            Url = url.ToLower();
            Title = title;
            Browser = browser;
            LastVisit = lastVisit;
        }

        public string getData()
        {
            return Browser + " - " + Title + " - " + Url;
        }
    }
}