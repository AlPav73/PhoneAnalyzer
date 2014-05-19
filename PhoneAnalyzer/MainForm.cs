using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using CursProject.Doc;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Docs;
using PhoneAnalyzer.Forms;
using PhoneAnalyzer.Helpers;
using PhoneAnalyzer.Properties;

namespace PhoneAnalyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var dtn = DateTime.Now.Date;
            dtpReportFrom.Value = DateTime.Now.Date.AddDays(1 - dtn.Day);
            dtpReportTo.Value = DateTime.Now.Date.AddDays(DateTime.DaysInMonth(dtn.Year, dtn.Month) - dtn.Day + 1);

            dtpSubReportFrom.Value = DateTime.Now.Date.AddDays(1 - dtn.Day);
            dtpSubReportTo.Value = DateTime.Now.Date.AddDays(DateTime.DaysInMonth(dtn.Year, dtn.Month) - dtn.Day + 1);

            LoadSettings();
            RefreshAllGrids();
        }

        /*
         *********************************** 
         **********   Refresher   **********
         *********************************** 
         */

        private void RefreshAllGrids()
        {
            RefreshAtcCall();
            RefreshNumber();
            RefreshSubdivision();
            RefreshWorker();
            RefreshCall();
            RefreshSites();
        }

        private void RefreshAtcCall()
        {
            var db = DataBase.Context;
            atcCallGrid.DataSource = db.AtcCalls.OrderBy(p => p.Date).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(atcCallGrid, new[] { "ID", "�������������", "���� �������", "����", "������������" });
            GridHelper.SetInvisible(atcCallGrid, new[] { 0 });
            db.Dispose();
        }

        private void RefreshNumber()
        {
            var db = DataBase.Context;
            outNumberGrid.DataSource = db.Numbers.OrderBy(p => p.PhoneNumber).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(outNumberGrid, new[] { "ID", "���������", "�����", "���" });
            GridHelper.SetInvisible(outNumberGrid, new[] { 0 });
            db.Dispose();
        }

        private void RefreshSubdivision()
        {
            var db = DataBase.Context;
            subdivisionGrid.DataSource = db.Subdivisions.OrderBy(p => p.Name).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(subdivisionGrid, new[] { "ID", "��������", "��� ������������", "Email" });
            GridHelper.SetInvisible(subdivisionGrid, new[] { 0 });
            db.Dispose();
        }

        private void RefreshWorker()
        {
            var db = DataBase.Context;
            workerGrid.DataSource = db.Workers.OrderBy(p => p.Fio).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(workerGrid, new[] { "ID", "���", "�������������", "�����" });
            GridHelper.SetInvisible(workerGrid, new[] { 0 });
            db.Dispose();
        }

        private void RefreshCall()
        {
            var db = DataBase.Context;
            callGrid.DataSource = db.Calls.OrderBy(p => p.Date).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(callGrid, new[] { "ID", "�����", "���� �������", "����", "������������", "�����" });
            GridHelper.SetInvisible(callGrid, new[] { 0 });
            db.Dispose();
        }


        private void RefreshSites()
        {
            var db = DataBase.Context;
            listSite.Items.Clear();
            listSite.Items.AddRange(db.CloseSites.OrderBy(p => p.Url).Select(p => p.Url).ToArray());
            db.Dispose();
        }


        //
        //**********   Subdivision   **********
        //

        private void btnAddSubdivision_Click(object sender, EventArgs e)
        {
            var form = new AddSubdivisionForm();
            form.ShowDialog();
            RefreshSubdivision();
        }

        private void btnEditSubdivision_Click(object sender, EventArgs e)
        {
            if (subdivisionGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(subdivisionGrid.SelectedRows[0], 0);
            EditSubdivision(id);
        }

        private void EditSubdivision(int id)
        {
            var form = new AddSubdivisionForm(id);
            form.ShowDialog();
            RefreshSubdivision();
        }

        private void btnDeleteSubdivision_Click(object sender, EventArgs e)
        {
            if (subdivisionGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(subdivisionGrid.SelectedRows[0], 0);

            var db = DataBase.Context;
            db.Subdivisions.DeleteAllOnSubmit(db.Subdivisions.Where(t => t.Id == id));
            db.SubmitChanges();
            db.Dispose();

            RefreshSubdivision();
        }

        private void btnSubReport_Click(object sender, EventArgs e)
        {
            var db = DataBase.Context;

            var numbers = db.Numbers;
            var dateFrom = dtpReportFrom.Value.Date;
            var dateTo = dtpReportTo.Value.Date;

            var calls = db.Calls.Where(p => numbers.Any(n => n.PhoneNumber == p.ToNumber)).Where(p => dateFrom <= p.Date.Date && p.Date.Date <= dateTo);

            foreach (var sub in db.Subdivisions)
            {
                var fileName = PdfGenerator.MakeReport(calls.Where(p => p.Number.Worker.Subdivision.Id == sub.Id), dtpReportFrom.Value.Date,
                    dtpReportTo.Value.Date);

                Mailer.SendReport(sub, dateFrom, dateTo, fileName);
            }

            db.Dispose();
        }

        private void btnMakeGraph_Click(object sender, EventArgs e)
        {
            var form = new ShowGraphicForm(dtpSubReportFrom.Value.Date, dtpSubReportTo.Value.Date);
            form.ShowDialog();
        }

        private void btnMakeGraphExcel_Click(object sender, EventArgs e)
        {
            var dateFrom = dtpSubReportFrom.Value.Date;
            var dateTo = dtpSubReportTo.Value.Date;
            ExcelGenerator.ExportTrips(dateFrom, dateTo);
        }

        //
        //**********   OutNumber   **********
        //

        private void btnAddOutNumber_Click(object sender, EventArgs e)
        {
            var form = new AddNumberForm();
            form.ShowDialog();
            RefreshNumber();
        }

        private void btnEditOutNumber_Click(object sender, EventArgs e)
        {
            if (outNumberGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(outNumberGrid.SelectedRows[0], 0);
            EditOutNumber(id);
        }

        private void EditOutNumber(int id)
        {
            var form = new AddNumberForm(id);
            form.ShowDialog();
            RefreshNumber();
            RefreshCall();
            RefreshAtcCall();
        }

        private void btnDeleteOutNumber_Click(object sender, EventArgs e)
        {
            if (outNumberGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(outNumberGrid.SelectedRows[0], 0);

            var db = DataBase.Context;
            db.Numbers.DeleteAllOnSubmit(db.Numbers.Where(t => t.Id == id));
            db.SubmitChanges();
            db.Dispose();

            RefreshNumber();
        }

        //
        //**********   Worker   **********
        //

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            var form = new AddWorkerForm();
            form.ShowDialog();
            RefreshWorker();
        }

        private void btnEditWorker_Click(object sender, EventArgs e)
        {
            if (workerGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(workerGrid.SelectedRows[0], 0);
            EditWorker(id);
        }

        private void EditWorker(int id)
        {
            var form = new AddWorkerForm(id);
            form.ShowDialog();
            RefreshWorker();
        }

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {
            if (workerGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(workerGrid.SelectedRows[0], 0);

            var db = DataBase.Context;
            db.Workers.DeleteAllOnSubmit(db.Workers.Where(t => t.Id == id));
            db.SubmitChanges();
            db.Dispose();

            RefreshWorker();
        }


        private void btnGenerateWorkerReport_Click(object sender, EventArgs e)
        {
            if (workerGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(workerGrid.SelectedRows[0], 0);

            var db = DataBase.Context;
            var worker = db.Workers.FirstOrDefault(t => t.Id == id);
            db.Dispose();

            CalcGenerator.MakeReport(worker);
        }

        //
        //**********   Call   **********
        //

        private void btnAddCall_Click(object sender, EventArgs e)
        {
            var form = new AddCallForm();
            form.ShowDialog();
            RefreshCall();
        }

        private void btnEditCall_Click(object sender, EventArgs e)
        {
            if (callGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(callGrid.SelectedRows[0], 0);
            EditCall(id);
        }

        private void EditCall(int id)
        {
            var form = new AddCallForm(id);
            form.ShowDialog();
            RefreshCall();
        }

        private void btnDeleteCall_Click(object sender, EventArgs e)
        {
            if (callGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(callGrid.SelectedRows[0], 0);

            var db = DataBase.Context;
            db.Calls.DeleteAllOnSubmit(db.Calls.Where(t => t.Id == id));
            db.SubmitChanges();
            db.Dispose();

            RefreshCall();
        }

        private void btnCallReport_Click(object sender, EventArgs e)
        {
            var db = DataBase.Context;

            var numbers = db.Numbers;
            var calls =
                db.Calls.Where(p => numbers.Any(n => n.PhoneNumber == p.ToNumber)).Where(
                                                                                         p =>
                                                                                             dtpReportFrom.Value.Date <= p.Date.Date &&
                                                                                             p.Date.Date <= dtpReportTo.Value.Date);

            var fileName = PdfGenerator.MakeReport(calls, dtpReportFrom.Value.Date, dtpReportTo.Value.Date);
            Process.Start(fileName);

            db.Dispose();
        }

        private void btnSendFinDir_Click(object sender, EventArgs e)
        {
            var db = DataBase.Context;

            var numbers = db.Numbers;
            var calls =
                db.Calls.Where(p => numbers.Any(n => n.PhoneNumber == p.ToNumber)).Where(
                                                                                         p =>
                                                                                             dtpReportFrom.Value.Date <= p.Date.Date &&
                                                                                             p.Date.Date <= dtpReportTo.Value.Date);

            var fileName = PdfGenerator.MakeReport(calls, dtpReportFrom.Value.Date, dtpReportTo.Value.Date);
            Mailer.SendReport(Setting.FinEmail, dtpReportFrom.Value.Date, dtpReportTo.Value.Date, fileName);

            db.Dispose();
        }

        private void btnLoadCallsFromFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = ".xls|*.xls";
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                ExcelLoader.LoadCalls(dialog.FileName);
                MessageBox.Show("�������� ���������", "��������");

                RefreshCall();
            }
        }

        //
        //**********   AtcCall   **********
        //

        private void btnAddAtcCall_Click(object sender, EventArgs e)
        {
            var form = new AddAtcCallForm();
            form.ShowDialog();
            RefreshAtcCall();
        }

        private void btnEditAtcCall_Click(object sender, EventArgs e)
        {
            if (atcCallGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(atcCallGrid.SelectedRows[0], 0);
            EditAtcCall(id);
        }

        private void EditAtcCall(int id)
        {
            var form = new AddAtcCallForm(id);
            form.ShowDialog();
            RefreshAtcCall();
        }

        private void btnDeleteAtcCall_Click(object sender, EventArgs e)
        {
            if (atcCallGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(atcCallGrid.SelectedRows[0], 0);

            var db = DataBase.Context;
            db.AtcCalls.DeleteAllOnSubmit(db.AtcCalls.Where(t => t.Id == id));
            db.SubmitChanges();
            db.Dispose();

            RefreshAtcCall();
        }

        private void btnLoadAtcCallsFromFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = ".xls|*.xls";
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                ExcelLoader.LoadAtcCalls(dialog.FileName);
                MessageBox.Show("�������� ���������", "��������");

                RefreshAtcCall();
            }
        }

        //
        //**********   Site   **********
        //

        private void btnAddSite_Click(object sender, EventArgs e)
        {
            var db = DataBase.Context;

            var site = new CloseSite { Url = txtSite.Text.ToLower().Trim() };
            db.CloseSites.InsertOnSubmit(site);
            db.SubmitChanges();

            txtSite.Clear();
            RefreshSites();

            db.Dispose();
        }


        private void btnDeleteSite_Click(object sender, EventArgs e)
        {
            var db = DataBase.Context;

            if (listSite.SelectedIndex != -1)
            {
                var site = db.CloseSites.FirstOrDefault(p => p.Url == listSite.SelectedItem);

                if (site != null)
                {
                    db.CloseSites.DeleteOnSubmit(site);
                    db.SubmitChanges();

                    RefreshSites();
                }
            }

            db.Dispose();
        }

        //
        //**********   Settings   **********
        //

        private void LoadSettings()
        {
            txtHost.Text = Setting.Host;
            txtPort.Text = Setting.Port.ToString();
            txtPopHost.Text = Setting.PopHost;
            txtPopPort.Text = Setting.PopPort.ToString();
            txtLogin.Text = Setting.Login;
            txtPassword.Text = Setting.Password;
            txtFinEmail.Text = Setting.FinEmail;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            var port = 0;
            Int32.TryParse(txtPort.Text, out port);

            var popPort = 0;
            Int32.TryParse(txtPopPort.Text, out popPort);

            Setting.Host = txtHost.Text;
            Setting.Port = port;
            Setting.PopHost = txtPopHost.Text;
            Setting.PopPort = popPort;
            Setting.Login = txtLogin.Text;
            Setting.Password = txtPassword.Text;
            Setting.FinEmail = txtFinEmail.Text;
        }

        private void btnMakeTest_Click(object sender, EventArgs e)
        {
            if (rbtnGenerateDb.Checked)
            {
                Generator.GenerateDb();
                RefreshAllGrids();
            }

            if (rbtnGenerateCalls.Checked)
            {
                var calls = Generator.GenerateCalls().ToList();
                var fileName = ExcelGenerator.SaveCalls(calls);
                Mailer.SendMail(Setting.Login, "Calls", "����� � �������", fileName);

                MessageBox.Show("���� ������������ � ��������� �� �����", "���������");
            }

            if (rbtnGenerateAtcCalls.Checked)
            {
                var atcCalls = Generator.GenerateAtcCalls().ToList();
                var fileName = ExcelGenerator.SaveAtcCalls(atcCalls);
                Mailer.SendMail(Setting.Login, "AtcCalls", "����� � �������", fileName);

                MessageBox.Show("���� ������������ � ��������� �� �����", "���������");
            }

            if (rbtnGetMails.Checked)
            {
                Mailer.GetMails();

                MessageBox.Show("�������� ���������", "��������");
                RefreshAllGrids();
            }
        }

        private void workerTab_Click(object sender, EventArgs e)
        {

        }
    }
}