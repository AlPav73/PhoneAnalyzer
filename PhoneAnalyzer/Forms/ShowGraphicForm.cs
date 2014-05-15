using System;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Helpers;

namespace PhoneAnalyzer.Forms
{
    public partial class ShowGraphicForm : Form
    {
        private readonly PaDbDataContext db = DataBase.Context;

        public ShowGraphicForm(DateTime from, DateTime to)
        {
            InitializeComponent();

            from = from.Date.AddDays(1 - from.Day);
            to = to.Date.AddMonths(1).AddDays(-to.Day);

            var numbers = db.Numbers;

            int index = 1;
            foreach (Subdivision sub in db.Subdivisions)
            {
                chart.Series.Add(index + " - " + sub.Name);
                for (var dateFrom = from; dateFrom <= to; dateFrom = dateFrom.AddMonths(1))
                {
                    var dateTo = dateFrom.AddMonths(1).AddDays(-1);
                    var calls = db.Calls.Where(p => numbers.Any(n => n.PhoneNumber == p.ToNumber))
                                                     .Where(p => dateFrom <= p.Date.Date && p.Date.Date <= dateTo)
                                                     .Where(p => p.Number.Worker.Subdivision.Id == sub.Id);

                    decimal sum = calls.Any() ? calls.Sum(p => p.Price) : 0;
                    chart.Series[index - 1].Points.AddXY(StringHelper.GetMonth(dateFrom.Month), sum);
                }

                index++;
            }
        }
    }
}