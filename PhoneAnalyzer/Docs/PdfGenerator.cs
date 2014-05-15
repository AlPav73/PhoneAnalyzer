using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Helpers;
using BorderStyle = MigraDoc.DocumentObjectModel.BorderStyle;
using TabAlignment = MigraDoc.DocumentObjectModel.TabAlignment;

namespace PhoneAnalyzer.Docs
{
    public class PdfGenerator
    {
        private static readonly string Dir = Application.StartupPath + "\\PdfFiles";

        public static string MakeReport(IQueryable<Call> calls, DateTime dateFrom, DateTime dateTo)
        {
            FileHelper.CreateDirectory(Dir);
            string fileName = Dir + "\\" + Guid.NewGuid() + ".pdf";
            if (File.Exists(fileName))
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Счёт на оплату {0} уже существует. Пересоздать новый счёт?", fileName),
                    "Замена договора", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dialogResult != DialogResult.OK)
                {
                    return "";
                }

                try
                {
                    File.Delete(fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(string.Format("В настоящий момент используется файл:\r\n{0}\r\nДля создания счёта закройте пожалуйста файл.", fileName),
                        "Невозможно создать счёт", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }
            }

            // Create a MigraDoc document
            Document document = Documents.CreateReport(calls, dateFrom, dateTo);

            //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
            DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            var renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);
            renderer.Document = document;

            renderer.RenderDocument();

            // Save the document...
            renderer.PdfDocument.Save(fileName);
            // ...and start a viewer.
            return fileName;
        }
    }

    internal class Documents
    {
        private static PaDbDataContext db = DataBase.Context;

        public static Document CreateReport(IQueryable<Call> calls, DateTime dateFrom, DateTime dateTo)
        {
            // Create a new MigraDoc document
            var document = new Document
            {
                Info = { Title = string.Format("Отчёт по связи с {0} по {1}", dateFrom.ToShortDateString(), dateTo.ToShortDateString()) }
            };

            DefineStyles(document);
            DefineContentSection(document);

            Paragraph paragraph =
                document.LastSection.AddParagraph(string.Format("Отчёт по связи с {0} по {1}", dateFrom.ToShortDateString(), dateTo.ToShortDateString()),
                    "Heading3");
            paragraph.Format.Alignment = ParagraphAlignment.Center;


            foreach (var sub in db.Subdivisions)
            {
                var subCalls = calls.Where(p => p.Number.Worker.SubdivisionId == sub.Id);
                if (subCalls.Any())
                {
                    document.LastSection.AddParagraph(" ");
                    paragraph = document.LastSection.AddParagraph();
                    paragraph.AddText(string.Format("Подразделение {0}", sub.Name));
                    AddTable(document, subCalls.ToList());
                }
            }

            return document;
        }

        private static void AddTable(Document document, List<Call> calls)
        {
            document.LastSection.AddParagraph();

            var table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(3));
            column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn(Unit.FromCentimeter(3));
            table.AddColumn(Unit.FromCentimeter(3));
            table.AddColumn(Unit.FromCentimeter(3));
            table.AddColumn(Unit.FromCentimeter(3));
            table.AddColumn(Unit.FromCentimeter(3));

            Row row = table.AddRow();
            row.Shading.Color = Colors.PaleGoldenrod;
            row.Cells[0].AddParagraph("Подразделение");
            row.Cells[1].AddParagraph("Номер");
            row.Cells[2].AddParagraph("Куда звонили");
            row.Cells[3].AddParagraph("Дата");
            row.Cells[4].AddParagraph("Длительность");
            row.Cells[5].AddParagraph("Стоимость");

            decimal totalPrice = 0;
            foreach (var call in calls)
            {
                row = table.AddRow();
                row.Cells[0].AddParagraph(call.Number.Worker.Subdivision.Name);
                row.Cells[1].AddParagraph(call.Number.PhoneNumber);
                row.Cells[2].AddParagraph(call.ToNumber);
                row.Cells[3].AddParagraph(call.Date.ToString());
                row.Cells[4].AddParagraph(call.Duration.ToString());
                row.Cells[5].AddParagraph(call.Price.ToString());

                totalPrice += call.Price;
            }

            row = table.AddRow();
            Paragraph paragraf = row.Cells[0].AddParagraph("Итого:");
            paragraf.Format.Alignment = ParagraphAlignment.Right;
            row.Cells[0].MergeRight = 4;
            row.Cells[5].AddParagraph(totalPrice.ToString());

            table.SetEdge(0, 0, 6, calls.Count + 2, Edge.Box, BorderStyle.Single, 1.5, Colors.Black);

            document.LastSection.Add(table);
            document.LastSection.AddParagraph(" ");
        }

        private static void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Times New Roman";

            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.

            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 20;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading2"];
            style.Font.Size = 18;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading3"];
            style.Font.Size = 16;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.Font.Size = 14;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";

            //TODO: Colors
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;
        }

        /// <summary>
        ///     Defines page setup, headers, and footers.
        /// </summary>
        private static void DefineContentSection(Document document)
        {
            Section section = document.AddSection();
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.StartingNumber = 1;

            // Create a paragraph with centered page number. See definition of style "Footer".
            var paragraph = new Paragraph();
            paragraph.AddTab();
            paragraph.AddPageField();

            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());
        }
    }
}