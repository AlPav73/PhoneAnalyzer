using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Type;

namespace PhoneAnalyzer
{
    internal class Generator
    {
        private static readonly PaDbDataContext db = DataBase.Context;

        private static readonly int SubCount = 5;
        private static readonly Random R = new Random(DateTime.Now.Second);

        public static void GenerateDb()
        {
            Setting.TariffOne = (decimal)R.Next(1000, 5000) / 100;
            Setting.TariffTwo = (decimal)R.Next(300, 1000) / 100;
            Setting.TariffThree = (decimal)R.Next(100, 300) / 100;

            var subs = GenerateSub();
            db.Subdivisions.InsertAllOnSubmit(subs);
            db.SubmitChanges();

            var workers = GenerateWorkers();
            db.Workers.InsertAllOnSubmit(workers);
            db.SubmitChanges();

            var numbers = GenerateNumbers();
            db.Numbers.InsertAllOnSubmit(numbers);
            db.SubmitChanges();

            var atcCalls = GenerateAtcCalls();
            db.AtcCalls.InsertAllOnSubmit(atcCalls);
            db.SubmitChanges();

            var calls = GenerateCalls();
            db.Calls.InsertAllOnSubmit(calls);
            db.SubmitChanges();

            MessageBox.Show("Генерация завершена", "Генерация");
        }

        public static IEnumerable<Call> GenerateCalls()
        {
            var list = new List<Call>();

            var outNumbes = db.Numbers.Where(p => p.Type == (int)NumberType.Out).ToList();
            foreach (var number in outNumbes)
            {
                int callsCount = R.Next(5, 21);

                for (int i = 0; i < callsCount; i++)
                {
                    var date = new DateTime(2014, R.Next(1, 6), R.Next(1, 29));
                    var phoneNumber = outNumbes[R.Next(0, outNumbes.Count)].PhoneNumber;
                    int duration = R.Next(30, 300);
                    int tariff = R.Next(0, 3);
                    decimal price = 0;
                    switch (tariff)
                    {
                        case 0 :
                            price = decimal.Round(duration * Setting.TariffOne / 60, 2);
                            break;

                        case 1:
                            price = decimal.Round(duration * Setting.TariffTwo / 60, 2);
                            break;

                        case 2:
                            price = decimal.Round(duration * Setting.TariffThree / 60, 2);
                            break;
                    }

                    list.Add(new Call { Number = number, ToNumber = phoneNumber, Date = date, Duration = duration, Price = price, Tariff = tariff});
                }
            }

            return list;
        }

        public static List<AtcCall> GenerateAtcCalls()
        {
            var list = new List<AtcCall>();

            var inNumbes = db.Numbers.Where(p => p.Type == (int)NumberType.In).ToList();
            foreach (var number in inNumbes)
            {
                int callsCount = R.Next(2, 6);

                for (int i = 0; i < callsCount; i++)
                {
                    var date = new DateTime(2014, R.Next(1, 6), R.Next(1, 29));
                    var phoneNumber = inNumbes[R.Next(0, inNumbes.Count)].PhoneNumber;
                    var sub = number.Worker.Subdivision;

                    list.Add(new AtcCall { Subdivision = sub, ToNumber = phoneNumber, Date = date, Duration = R.Next(30, 151) });
                }
            }

            return list;
        }

        public static List<Number> GenerateNumbers()
        {
            var list = new List<Number>();

            foreach (var worker in db.Workers.ToList())
            {
                list.Add(new Number { PhoneNumber = GenerateInNumber(), NumberType = NumberType.In, Worker = worker });

                if (R.Next(0, 10) > 3)
                {
                    list.Add(new Number { PhoneNumber = GenerateOutNumber(), NumberType = NumberType.Out, WorkerId = worker.Id });
                }
            }

            return list;
        }

        public static List<Worker> GenerateWorkers()
        {
            var list = new List<Worker>();

            foreach (var sub in  db.Subdivisions.ToList())
            {
                var workersCount = R.Next(3, 5);
                for (int i = 0; i < workersCount; i++)
                {
                    list.Add(new Worker { SubdivisionId = sub.Id, Fio = GenerateFio(), Salary = R.Next(15, 46) * 1000 });
                }
            }

            return list;
        }

        public static List<Subdivision> GenerateSub()
        {
            var list = new List<Subdivision>();

            for (int i = 0; i < SubCount; i++)
            {
                list.Add(new Subdivision { Name = "Подразделение №" + (i + 1), Email = "subdivivion" + (i + 1) + "@gmail.com", DirectorFio = GenerateFio() });
            }

            return list;
        }

        private static string GenerateOutNumber()
        {
            return string.Format("8-({0})-{1}-{2}-{3}", R.Next(100, 999), R.Next(100, 999), R.Next(10, 100), R.Next(10, 100));
        }

        private static string GenerateInNumber()
        {
            return string.Format("{0}-{1}", R.Next(0, 10), R.Next(100, 999));
        }

        private static string GenerateFio()
        {
            var F = new[]
            {
                "Абдулина", "Андрианова", "Бегичев", "Булавинова", "Габовский", "Графов", "Дормидонтова", "Захваткина", "Каменская", "Козлова", "Крылова", "Лайко",
                "Мальцева", "Милицина", "Никифорова", "Панфилова", "Похлебкина", "Савина", "Сивакова", "Степанович", "Ушакова", "Цветков", "Шинкарюк"
            };

            var I = new[]
            {
                "Назия", "Лидия", "Александр", "Алла", "Сергей", "Валерий", "Любовь", "Ольга", "Галия", "Людмила", "Светлана", "Михаил", "Любовь", "Татьяна",
                "Светлана", "Елена", "Марина", "Ольга", "Галина", "Нина", "Алла", "Сергей", "Марина"
            };

            var O = new[]
            {
                "Абдульхаковна", "Васильевна", "Валерьевич", "Павловна", "Иванович", "Владимирович", "Юрьевна", "Александровна", "Адиятулловна", "Михайловна",
                "Ивановна", "Васильевич", "Александровна", "Сергеевна", "Александровна", "Викторовна", "Григорьевна", "Николаевна", "Ивановна", "Валентиновна",
                "Константиновна", "Александрович", "Юрьевна"
            };

            return F[R.Next(0, 23)] + " " + I[R.Next(0, 23)] + " " + O[R.Next(0, 23)];
        }
    }
}