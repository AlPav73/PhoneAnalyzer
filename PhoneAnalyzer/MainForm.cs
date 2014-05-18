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

namespace PhoneAnalyzer
{
    public partial class MainForm : Form
    {
        private readonly PaDbDataContext db = DataBase.Context;

        public MainForm()
        {
            InitializeComponent();

            var dtn = DateTime.Now.Date;
            dtpReportFrom.Value = DateTime.Now.Date.AddDays(1 - dtn.Day);
            dtpReportTo.Value  = DateTime.Now.Date.AddDays(DateTime.DaysInMonth(dtn.Year, dtn.Month) - dtn.Day + 1);

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
        }

        private void RefreshAtcCall()
        {
            atcCallGrid.DataSource = db.AtcCalls.OrderBy(p => p.Date).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(atcCallGrid, new[] { "ID", "�������������", "���� �������", "����", "������������" });
            GridHelper.SetInvisible(atcCallGrid, new[] { 0 });
        }

        private void RefreshNumber()
        {
            outNumberGrid.DataSource = db.Numbers.OrderBy(p => p.PhoneNumber).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(outNumberGrid, new[] { "ID", "���������", "�����", "���" });
            GridHelper.SetInvisible(outNumberGrid, new[] { 0 });
        }

        private void RefreshSubdivision()
        {
            subdivisionGrid.DataSource = db.Subdivisions.OrderBy(p => p.Name).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(subdivisionGrid, new[] { "ID", "��������", "��� ������������", "Email" });
            GridHelper.SetInvisible(subdivisionGrid, new[] { 0 });
        }

        private void RefreshWorker()
        {
            workerGrid.DataSource = db.Workers.OrderBy(p => p.Fio).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(workerGrid, new[] { "ID", "���", "�������������", "�����" });
            GridHelper.SetInvisible(workerGrid, new[] { 0 });
        }

        private void RefreshCall()
        {
            callGrid.DataSource = db.Calls.OrderBy(p => p.Date).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(callGrid, new[] { "ID", "�����", "���� �������", "����", "������������", "�����" });
            GridHelper.SetInvisible(callGrid, new[] { 0 });
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

            db.Subdivisions.DeleteAllOnSubmit(db.Subdivisions.Where(t => t.Id == id));
            db.SubmitChanges();

            RefreshSubdivision();
        }

        private void btnSubReport_Click(object sender, EventArgs e)
        {
            var numbers = db.Numbers;
            var dateFrom = dtpReportFrom.Value.Date;
            var dateTo = dtpReportTo.Value.Date;

            var calls = db.Calls.Where(p => numbers.Any(n => n.PhoneNumber == p.ToNumber))
                                .Where(p => dateFrom <= p.Date.Date && p.Date.Date <= dateTo);

            foreach (var sub in db.Subdivisions)
            {
                var fileName = PdfGenerator.MakeReport(calls.Where(p => p.Number.Worker.Subdivision.Id == sub.Id), dtpReportFrom.Value.Date, dtpReportTo.Value.Date);

                MailSender.SendReport(sub, dateFrom, dateTo, fileName);
            }
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

            db.Numbers.DeleteAllOnSubmit(db.Numbers.Where(t => t.Id == id));
            db.SubmitChanges();

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

            db.Workers.DeleteAllOnSubmit(db.Workers.Where(t => t.Id == id));
            db.SubmitChanges();

            RefreshWorker();
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

            db.Calls.DeleteAllOnSubmit(db.Calls.Where(t => t.Id == id));
            db.SubmitChanges();

            RefreshCall();
        }

        private void btnCallReport_Click(object sender, EventArgs e)
        {
            var numbers = db.Numbers;
            var calls = db.Calls.Where(p => numbers.Any(n => n.PhoneNumber == p.ToNumber))
                                .Where(p => dtpReportFrom.Value.Date <= p.Date.Date && p.Date.Date <= dtpReportTo.Value.Date);

            var fileName = PdfGenerator.MakeReport(calls, dtpReportFrom.Value.Date, dtpReportTo.Value.Date);
            Process.Start(fileName);
        }

        private void btnSendFinDir_Click(object sender, EventArgs e)
        {
            var numbers = db.Numbers;
            var calls = db.Calls.Where(p => numbers.Any(n => n.PhoneNumber == p.ToNumber))
                                .Where(p => dtpReportFrom.Value.Date <= p.Date.Date && p.Date.Date <= dtpReportTo.Value.Date);

            var fileName = PdfGenerator.MakeReport(calls, dtpReportFrom.Value.Date, dtpReportTo.Value.Date);
            MailSender.SendReport(Setting.FinEmail, dtpReportFrom.Value.Date, dtpReportTo.Value.Date, fileName);
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

            db.AtcCalls.DeleteAllOnSubmit(db.AtcCalls.Where(t => t.Id == id));
            db.SubmitChanges();

            RefreshAtcCall();
        }

        //
        //**********   Settings   **********
        //

        private void LoadSettings()
        {
            txtHost.Text = Setting.Host;
            txtPort.Text = Setting.Port.ToString();
            txtLogin.Text = Setting.Login;
            txtPassword.Text = Setting.Password;
            txtFinEmail.Text = Setting.FinEmail;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            var port = 0;
            Int32.TryParse(txtPort.Text, out port);

            Setting.Host = txtHost.Text;
            Setting.Port = port;
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
                var calls = Generator.GenerateCalls();
            }
        }
    }
}