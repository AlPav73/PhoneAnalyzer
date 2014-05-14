using System;
using System.Linq;
using System.Windows.Forms;
using PhoneAnalyzer.Classes;
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
            GridHelper.SetHeaders(atcCallGrid, new[] { "ID", "Подразделение", "Куда звонили", "Дата", "Длительность" });
            GridHelper.SetInvisible(atcCallGrid, new[] { 0 });
        }

        private void RefreshNumber()
        {
            outNumberGrid.DataSource = db.Numbers.OrderBy(p => p.PhoneNumber).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(outNumberGrid, new[] { "ID", "Сотрудник", "Номер", "Тип" });
            GridHelper.SetInvisible(outNumberGrid, new[] { 0 });
        }

        private void RefreshSubdivision()
        {
            subdivisionGrid.DataSource = db.Subdivisions.OrderBy(p => p.Name).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(subdivisionGrid, new[] { "ID", "Название", "ФИО руководителя", "Email" });
            GridHelper.SetInvisible(subdivisionGrid, new[] { 0 });
        }

        private void RefreshWorker()
        {
            workerGrid.DataSource = db.Workers.OrderBy(p => p.Fio).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(workerGrid, new[] { "ID", "ФИО", "Подразделение", "Оклад" });
            GridHelper.SetInvisible(workerGrid, new[] { 0 });
        }

        private void RefreshCall()
        {
            callGrid.DataSource = db.Calls.OrderBy(p => p.Date).Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(callGrid, new[] { "ID", "Номер", "Куда звонили", "Дата", "Длительность", "Сумма" });
            GridHelper.SetInvisible(callGrid, new[] { 0 });
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
    }

    public class ComboBoxItem
    {
        public ComboBoxItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}