﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using PhoneAnalyzer;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Helpers;
using Excel = Microsoft.Office.Interop.Excel;

namespace CursProject.Doc
{
    public class ExcelGenerator
    {
        private static readonly string Dir = Application.StartupPath + "\\ExcelFiles";
        private static PaDbDataContext db = DataBase.Context;
        private static object _ = System.Reflection.Missing.Value;
        public static void ExportTrips(DateTime from, DateTime to)
        {
            string fileName = Dir + "\\" + GetFileName();
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

            Excel.Application xla = new Excel.Application();
            xla.Visible = true;
            Excel.Workbook wb = xla.Workbooks.Add(Excel.XlSheetType.xlWorksheet);

            Excel.Worksheet ws = (Excel.Worksheet)xla.ActiveSheet;

            // Now create the chart.
            Excel.ChartObjects chartObjs = (Excel.ChartObjects)ws.ChartObjects();
            Excel.ChartObject chartObj = chartObjs.Add(512, 80, 300, 300);
            Excel.Chart xlChart = chartObj.Chart;
            xlChart.ChartType = Excel.XlChartType.xlLine;

            // generate some random data
            from = from.Date.AddDays(1 - from.Day);
            to = to.Date.AddMonths(1).AddDays(-to.Day);

            ws.Cells[2, 2] = string.Format("Расходы на связь с {0} по {1}", from, to);
            ws.Cells[4, 3] = "Месяц";

            int index = 1;

            int rows = 0;
            for (var dateFrom = from; dateFrom <= to; dateFrom = dateFrom.AddMonths(1), rows++);

            var numbers = db.Numbers;
            foreach (var sub in db.Subdivisions)
            {
                ws.Cells[4, 3 + index] = sub.Name;
                int row = 5;
                for (var dateFrom = from; dateFrom <= to; dateFrom = dateFrom.AddMonths(1))
                {
                    ws.Cells[row, 3] = StringHelper.GetMonth(dateFrom.Month) + " " + dateFrom.Year;

                    var dateTo = dateFrom.AddMonths(1).AddDays(-1);
                    var calls = db.Calls.Where(p => numbers.Any(n => n.PhoneNumber == p.ToNumber))
                                                     .Where(p => dateFrom <= p.Date.Date && p.Date.Date <= dateTo)
                                                     .Where(p => p.Number.Worker.Subdivision.Id == sub.Id);

                    ws.Cells[row, 3 + index] = calls.Any() ? calls.Sum(p => p.Price) : 0;
                    row++;
                }

                index++;
            }


            Excel.SeriesCollection seriesCollection = xlChart.SeriesCollection();

            int cell = 1;
            foreach (var sub in db.Subdivisions)
            {
                Excel.Series series = seriesCollection.NewSeries();
                series.XValues = ws.Range[GetRange(5, 3), GetRange(4 + rows, 3)];
                series.Values = ws.Range[GetRange(5, 3 + cell), GetRange(6, 3 + cell)];
                series.Name = sub.Name;
                cell++;
            }
        }

        private static string GetRange(int row, int col)
        {
            char strCol = 'A';

            strCol = (char)(strCol + col);

            return strCol.ToString() + row;
        }

        private static string GetFileName()
        {
            return string.Format("{0}.xls", Guid.NewGuid()).Replace(" ", "_");
        }


    }
}