using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Helpers;
using uno;
using unoidl.com.sun.star.beans;
using unoidl.com.sun.star.container;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.sheet;
using unoidl.com.sun.star.text;

namespace PhoneAnalyzer.Docs
{
    public class CalcGenerator
    {
        private static readonly PaDbDataContext db = DataBase.Context;
        private static readonly string Dir = Application.StartupPath + "\\CalcFiles";

        public static void MakeReport(Worker worker)
        {
            string fileName = Dir + "\\" + GetFileName();
            if (File.Exists(fileName))
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Файл {0} уже существует. Пересоздать новый файл?", fileName), "Замена файла",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    File.Delete((string) fileName);
                }
                catch (System.Exception)
                {
                    MessageBox.Show(string.Format("В настоящий момент используется файл:\r\n{0}\r\nДля создания договора закройте пожалуйста файл.", fileName),
                        "Невозможно создать договор", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var oStrap = uno.util.Bootstrap.bootstrap();
            var oServMan = (XMultiServiceFactory) oStrap.getServiceManager();
            var oDesk = (XComponentLoader) oServMan.createInstance("com.sun.star.frame.Desktop");

            string fileUrl = @"private:factory/scalc";
            var propVals = new PropertyValue[1];
            propVals[0] = new PropertyValue { Name = "Hidden", Value = new Any(true) };

            var oDoc = oDesk.loadComponentFromURL(fileUrl, "_blank", 0, propVals);

            var oSheets = ((XSpreadsheetDocument) oDoc).getSheets();
            var oSheetsIA = (XIndexAccess) oSheets;
            var oSheet = (XSpreadsheet) oSheetsIA.getByIndex(0).Value;

            var oCell = oSheet.getCellByPosition(0, 0);
            ((XText) oCell).setString("Расчётная ведомость за " + StringHelper.GetMonth(DateTime.Now.Month) + " сотрудника " + worker.Fio);

            var gc = new GoogleChrome();
            var urls = gc.GetHistory();
            var closeSites = db.CloseSites.ToList();
            int i = 0;
            decimal taxes = 0;

            if (urls != null && urls.Any())
            {
                oCell = oSheet.getCellByPosition(0, 2);
                ((XText) oCell).setString("Посещённый сайт");

                oCell = oSheet.getCellByPosition(1, 2);
                ((XText) oCell).setString("Дата");

                oCell = oSheet.getCellByPosition(2, 2);
                ((XText) oCell).setString("Штраф");

                foreach (var url in urls)
                {
                    if (closeSites.Any(s => url.Url.Contains(s.Url)))
                    {
                        oCell = oSheet.getCellByPosition(0, i + 3);
                        ((XText) oCell).setString(url.Url);

                        oCell = oSheet.getCellByPosition(1, i + 3);
                        ((XText) oCell).setString(url.LastVisit.ToString());

                        oCell = oSheet.getCellByPosition(2, i + 3);
                        ((XText) oCell).setString(Setting.TaxSite + " руб.");

                        i++;
                        taxes += Setting.TaxSite;
                    }
                }
            }

            DateTime dateFrom = DateTime.Now.Date.AddDays(1 - DateTime.Now.Date.Day);
            DateTime dateTo = DateTime.Now.Date.AddMonths(1).AddDays(1 - DateTime.Now.Date.Day);

            var monthCalls = db.Calls.Where(p => dateFrom <= p.Date && p.Date <= dateTo && p.Number.WorkerId == worker.Id);
            int durationOne = monthCalls.Any(p => p.Tariff == 0) ? monthCalls.Where(p => p.Tariff == 0).Sum(p => p.Duration) : 0;
            int durationTwo = monthCalls.Any(p => p.Tariff == 1) ? monthCalls.Where(p => p.Tariff == 1).Sum(p => p.Duration) : 0;
            int durationThree = monthCalls.Any(p => p.Tariff == 2) ? monthCalls.Where(p => p.Tariff == 2).Sum(p => p.Duration) : 0;

            if (durationOne > worker.LimitOne)
            {
                oCell = oSheet.getCellByPosition(0, i + 3);
                ((XText) oCell).setString("Превышение Миртелеком");

                oCell = oSheet.getCellByPosition(1, i + 3);
                ((XText) oCell).setString((durationOne - worker.LimitOne) + " сек");

                oCell = oSheet.getCellByPosition(2, i + 3);
                ((XText) oCell).setString(decimal.Round((durationOne - worker.LimitOne) * Setting.TaxOne / 60, 2) + " руб.");

                taxes += decimal.Round((durationOne - worker.LimitOne) * Setting.TaxOne / 60, 2);
                i++;
            }

            if (durationTwo > worker.LimitTwo)
            {
                oCell = oSheet.getCellByPosition(0, i + 3);
                ((XText) oCell).setString("Превышение Городтелеком");

                oCell = oSheet.getCellByPosition(1, i + 3);
                ((XText)oCell).setString((durationTwo - worker.LimitTwo) + " сек");

                oCell = oSheet.getCellByPosition(2, i + 3);
                ((XText)oCell).setString(decimal.Round((durationTwo - worker.LimitTwo) * Setting.TaxTwo / 60, 2) + " руб.");

                taxes += decimal.Round((durationTwo - worker.LimitTwo) * Setting.TaxTwo / 60, 2);
                i++;
            }

            if (durationThree > worker.LimitThree)
            {
                oCell = oSheet.getCellByPosition(0, i + 3);
                ((XText) oCell).setString("Превышение Городтелеком");

                oCell = oSheet.getCellByPosition(1, i + 3);
                ((XText)oCell).setString((durationThree - worker.LimitThree) + " сек");

                oCell = oSheet.getCellByPosition(2, i + 3);
                ((XText)oCell).setString(decimal.Round((durationThree - worker.LimitThree) * Setting.TaxThree / 60, 2) + " руб.");

                taxes += decimal.Round((durationThree - worker.LimitThree) * Setting.TaxThree / 60, 2);
                i++;
            }

            oCell = oSheet.getCellByPosition(1, i + 3);
            ((XText) oCell).setString("Итого штрафов:");

            oCell = oSheet.getCellByPosition(2, i + 3);
            ((XText) oCell).setString(taxes + " руб.");
            i++;

            oCell = oSheet.getCellByPosition(1, i + 3);
            ((XText) oCell).setString("Зарплата:");

            oCell = oSheet.getCellByPosition(2, i + 3);
            ((XText) oCell).setString(worker.Salary + " руб.");
            i++;

            oCell = oSheet.getCellByPosition(1, i + 3);
            ((XText) oCell).setString("К выплате:");

            oCell = oSheet.getCellByPosition(2, i + 3);
            ((XText) oCell).setString((worker.Salary - taxes) + " руб.");

            ((XStorable) oDoc).storeAsURL("file:///" + fileName.Replace("\\", "/"), propVals);
            oDoc.dispose();

            Process.Start(fileName);
        }

        private static string GetFileName()
        {
            return string.Format("{0}.ods", Guid.NewGuid()).Replace(" ", "_");
        }
    }
}