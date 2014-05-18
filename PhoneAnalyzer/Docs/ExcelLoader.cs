using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using PhoneAnalyzer;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Type;

namespace CursProject.Doc
{
    public class ExcelLoader
    {
        private static readonly PaDbDataContext db = DataBase.Context;
        private static object _ = Missing.Value;

        public static void LoadCalls(string fileName)
        {
            var xla = new Application { Visible = false };
            Workbook wb = xla.Workbooks.Open(fileName);
            var ws = (Worksheet) xla.ActiveSheet;

            var calls = new List<Call>();
            for (int i = 0; i < ws.Rows.Count; i++)
            {
                var phoneNumber = (string)(ws.Cells[i + 2, 1] as Range).Value;
                if (phoneNumber == null || phoneNumber.Trim().Length == 0)
                {
                    break;
                }

                Number number = db.Numbers.FirstOrDefault(p => p.PhoneNumber == phoneNumber && p.Type == (int) NumberType.Out);
                if (number == null) continue;

                var date = new DateTime();
                if (!DateTime.TryParse((string)(ws.Cells[i + 2, 3] as Range).Value, out date)) continue;

                double duration = (ws.Cells[i + 2, 4] as Range).Value;
                decimal price = (decimal)(ws.Cells[i + 2, 5] as Range).Value;

                calls.Add(new Call { Number = number, ToNumber = (string)(ws.Cells[i + 2, 2] as Range).Value, Date = date, Duration = (int)duration, Price = price });
            }

            wb.Close(0);
            xla.Quit();

            db.Calls.InsertAllOnSubmit(calls);
            db.SubmitChanges();
        }

        public static void LoadAtcCalls(string fileName)
        {
            var xla = new Application { Visible = false };
            Workbook wb = xla.Workbooks.Open(fileName);
            var ws = (Worksheet)xla.ActiveSheet;

            var atcCalls = new List<AtcCall>();
            for (int i = 0; i < ws.Rows.Count; i++)
            {
                var subName = (string)(ws.Cells[i + 2, 1] as Range).Value;
                if (subName == null || subName.Trim().Length == 0)
                {
                    break;
                }

                Subdivision sub = db.Subdivisions.FirstOrDefault(p => p.Name == subName);
                if (sub == null) continue;

                var date = new DateTime();
                if (!DateTime.TryParse((string)(ws.Cells[i + 2, 3] as Range).Value, out date)) continue;

                double duration = (ws.Cells[i + 2, 4] as Range).Value;

                atcCalls.Add(new AtcCall { Subdivision = sub, ToNumber = (string)(ws.Cells[i + 2, 2] as Range).Value, Date = date, Duration = (int)duration});
            }

            wb.Close(0);
            xla.Quit();

            db.AtcCalls.InsertAllOnSubmit(atcCalls);
            db.SubmitChanges();
        }
    }
}