using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using PhoneAnalyzer;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Helpers;
using Application = System.Windows.Forms.Application;

namespace CursProject.Doc
{
    public class ExcelGenerator
    {
        private static readonly string Dir = Application.StartupPath + "\\ExcelFiles";
        private static readonly PaDbDataContext db = DataBase.Context;
        private static readonly object _ = Missing.Value;

        public static void ExportTrips(DateTime from, DateTime to)
        {
            string fileName = Dir + "\\" + GetFileName();
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }

            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(string.Format("В настоящий момент используется файл:\r\n{0}\r\nДля создания договора закройте пожалуйста файл.", fileName),
                        "Невозможно создать договор", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Visible = true;
            Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);

            var ws = (Worksheet) xla.ActiveSheet;

            // Now create the chart.
            var chartObjs = (ChartObjects) ws.ChartObjects();
            ChartObject chartObj = chartObjs.Add(512, 80, 300, 300);
            Chart xlChart = chartObj.Chart;
            xlChart.ChartType = XlChartType.xlColumnClustered;

            // generate some random data
            from = from.Date.AddDays(1 - from.Day);
            to = to.Date.AddMonths(1).AddDays(-to.Day);

            ws.Cells[2, 2] = string.Format("Расходы на связь с {0} по {1}", from, to);
            ws.Cells[4, 3] = "Месяц";

            int index = 1;

            int rows = 0;
            for (DateTime dateFrom = from; dateFrom <= to; dateFrom = dateFrom.AddMonths(1), rows++)
            {
                ;
            }

            Table<Number> numbers = db.Numbers;
            foreach (Subdivision sub in db.Subdivisions)
            {
                ws.Cells[4, 3 + index] = sub.Name;
                int row = 5;
                for (DateTime dateFrom = from; dateFrom <= to; dateFrom = dateFrom.AddMonths(1))
                {
                    ws.Cells[row, 3] = StringHelper.GetMonth(dateFrom.Month) + " " + dateFrom.Year;

                    DateTime dateTo = dateFrom.AddMonths(1).AddDays(-1);
                    IQueryable<Call> calls = db.Calls.Where(p => numbers.Any(n => n.PhoneNumber == p.ToNumber))
                                                     .Where(p => dateFrom <= p.Date.Date && p.Date.Date <= dateTo)
                                                     .Where(p => p.Number.Worker.Subdivision.Id == sub.Id);

                    ws.Cells[row, 3 + index] = calls.Any() ? calls.Sum(p => p.Price) : 0;
                    row++;
                }

                index++;
            }

            SeriesCollection seriesCollection = xlChart.SeriesCollection();

            int cell = 1;
            foreach (Subdivision sub in db.Subdivisions)
            {
                Series series = seriesCollection.NewSeries();
                series.XValues = ws.Range[GetRange(5, 2), GetRange(4 + rows, 2)];
                series.Values = ws.Range[GetRange(5, 2 + cell), GetRange(4 + rows, 2 + cell)];
                series.Name = sub.Name;
                cell++;
            }
        }

        public static string SaveCalls(List<Call> calls)
        {
            string fileName = Dir + "\\" + GetFileName();
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }

            var xla = new Microsoft.Office.Interop.Excel.Application { Visible = false };
            Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            var ws = (Worksheet) xla.ActiveSheet;

            ws.Cells[1, 1] = "Номер";
            ws.Cells[1, 2] = "Куда звонили";
            ws.Cells[1, 3] = "Дата";
            ws.Cells[1, 4] = "Длительность";
            ws.Cells[1, 5] = "Сумма";

            for (int i = 0; i < calls.Count; i++)
            {
                ws.Cells[i + 2, 1] = calls[i].Number.PhoneNumber;
                ws.Cells[i + 2, 2] = calls[i].ToNumber;
                ws.Cells[i + 2, 3] = calls[i].Date.ToString();
                ws.Cells[i + 2, 4] = calls[i].Duration;
                ws.Cells[i + 2, 5] = calls[i].Price;
            }

            wb.SaveAs(fileName, _, _, _, _, _, XlSaveAsAccessMode.xlNoChange, _, _, _, _, _);
            wb.Close();
            xla.Quit();

            return fileName;
        }

        public static string SaveAtcCalls(List<AtcCall> calls)
        {
            string fileName = Dir + "\\" + GetFileName();
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }

            var xla = new Microsoft.Office.Interop.Excel.Application { Visible = false };
            Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            var ws = (Worksheet)xla.ActiveSheet;

            ws.Cells[1, 1] = "Подразделение";
            ws.Cells[1, 2] = "Куда звонили";
            ws.Cells[1, 3] = "Дата";
            ws.Cells[1, 4] = "Длительность";

            for (int i = 0; i < calls.Count; i++)
            {
                ws.Cells[i + 2, 1] = calls[i].Subdivision.Name;
                ws.Cells[i + 2, 2] = calls[i].ToNumber;
                ws.Cells[i + 2, 3] = calls[i].Date.ToString();
                ws.Cells[i + 2, 4] = calls[i].Duration;
            }

            wb.SaveAs(fileName, _, _, _, _, _, XlSaveAsAccessMode.xlNoChange, _, _, _, _, _);
            wb.Close();
            xla.Quit();

            return fileName;
        }

        private static string GetRange(int row, int col)
        {
            char strCol = 'A';

            strCol = (char) (strCol + col);

            return strCol.ToString() + row;
        }

        private static string GetFileName()
        {
            return string.Format("{0}.xls", Guid.NewGuid()).Replace("-", "");
        }
    }
}