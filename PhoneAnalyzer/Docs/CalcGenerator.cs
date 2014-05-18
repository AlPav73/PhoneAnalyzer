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
                    File.Delete((string)fileName);
                }
                catch (System.Exception)
                {
                    MessageBox.Show(string.Format("В настоящий момент используется файл:\r\n{0}\r\nДля создания договора закройте пожалуйста файл.", fileName),
                        "Невозможно создать договор", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var oStrap = uno.util.Bootstrap.bootstrap();
            var oServMan = (XMultiServiceFactory)oStrap.getServiceManager();
            var oDesk = (XComponentLoader)oServMan.createInstance("com.sun.star.frame.Desktop");

            string fileUrl = @"private:factory/scalc";
            var propVals = new PropertyValue[1];
            propVals[0] = new PropertyValue { Name = "Hidden", Value = new Any(true) };

            var oDoc = oDesk.loadComponentFromURL(fileUrl, "_blank", 0, propVals);

            var oSheets = ((XSpreadsheetDocument)oDoc).getSheets();
            var oSheetsIA = (XIndexAccess)oSheets;
            var oSheet = (XSpreadsheet)oSheetsIA.getByIndex(0).Value;


            var oCell = oSheet.getCellByPosition(0, 0);
            ((XText)oCell).setString("Расчётная ведомость за " + StringHelper.GetMonth(DateTime.Now.Month) + " сотрудника " + worker.Fio);


            oCell = oSheet.getCellByPosition(0, 2); 
            ((XText)oCell).setString("Посещённый сайт");

            oCell = oSheet.getCellByPosition(1, 2);
            ((XText)oCell).setString("Дата");

            oCell = oSheet.getCellByPosition(2, 2); 
            ((XText)oCell).setString("Штраф");


            var gc = new GoogleChrome();
            var urls = gc.GetHistory();
            var closeSites = db.CloseSites.ToList();
            int i = 0;
            int taxes = 0;
            foreach (var url in urls)
            {
                if (closeSites.Any(s => url.Url.Contains(s.Url)))
                {
                    oCell = oSheet.getCellByPosition(0, i + 3);
                    ((XText) oCell).setString(url.Url);

                    oCell = oSheet.getCellByPosition(1, i + 3);
                    ((XText) oCell).setString(url.LastVisit.ToString());

                    oCell = oSheet.getCellByPosition(2, i + 3);
                    ((XText) oCell).setString("15 руб.");

                    i++;
                    taxes += 15;
                }
            }
            oCell = oSheet.getCellByPosition(1, i + 3);
            ((XText)oCell).setString("Итого штрафов:");

            oCell = oSheet.getCellByPosition(2, i + 3);
            ((XText)oCell).setString(taxes + " руб.");
            i++;
            
            oCell = oSheet.getCellByPosition(1, i + 3);
            ((XText)oCell).setString("Зарплата:");

            oCell = oSheet.getCellByPosition(2, i + 3);
            ((XText)oCell).setString(worker.Salary + " руб.");
            i++;

            oCell = oSheet.getCellByPosition(1, i + 3);
            ((XText)oCell).setString("К выплате:");

            oCell = oSheet.getCellByPosition(2, i + 3);
            ((XText)oCell).setString((worker.Salary - taxes) + " руб.");

            ((XStorable)oDoc).storeAsURL("file:///" + fileName.Replace("\\", "/"), propVals);
            oDoc.dispose();

            Process.Start(fileName);
        }

        private static string GetFileName()
        {
            return string.Format("{0}.ods", Guid.NewGuid()).Replace(" ", "_");
        }
    }
}