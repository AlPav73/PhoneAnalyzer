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

            RefreshAllGrids();
        }

        /*
         *********************************** 
         **********   Refresher   **********
         *********************************** 
         */

        private void RefreshAllGrids()
        {
            RefreshProvider();
            RefreshOutNumber();
            RefreshInNumber();
            RefreshSubdivision();
            RefreshWorker();
            RefreshCall();
        }

        private void RefreshProvider()
        {
            providerGrid.DataSource = db.Providers.ToList(); //.Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(providerGrid, new[] { "ID", "Название", "Тариф" });
            GridHelper.SetInvisible(providerGrid, new[] { 0 });
        }

        private void RefreshOutNumber()
        {
            outNumberGrid.DataSource = db.OutNumbers.ToList(); //.Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(outNumberGrid, new[] { "ID", "Провайдер", "Номер" });
            GridHelper.SetInvisible(outNumberGrid, new[] { 0 });
        }

        private void RefreshInNumber()
        {
            inNumberGrid.DataSource = db.InNumbers.ToList(); //.Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(inNumberGrid, new[] { "ID", "Внешний номер", "Сотрудник", "Номер" });
            GridHelper.SetInvisible(inNumberGrid, new[] { 0 });
        }

        private void RefreshSubdivision()
        {
            subdivisionGrid.DataSource = db.Subdivisions.ToList(); //.Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(subdivisionGrid, new[] { "ID", "Название", "ФИО руководителя" });
            GridHelper.SetInvisible(subdivisionGrid, new[] { 0 });
        }

        private void RefreshWorker()
        {
            workerGrid.DataSource = db.Workers.ToList(); //.Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(workerGrid, new[] { "ID", "Подразделение", "ФИО", "Оклад" });
            GridHelper.SetInvisible(workerGrid, new[] { 0 });
        }

        private void RefreshCall()
        {
            callGrid.DataSource = db.Calls.ToList(); //.Select(p => p.ToGrid()).ToList();
            GridHelper.SetHeaders(callGrid, new[] { "ID", "Номер", "Куда звонили", "Дата", "Время" });
            GridHelper.SetInvisible(callGrid, new[] { 0 });
        }


        //
        //**********   Provider   **********
        //

        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            var form = new AddProviderForm();
            form.ShowDialog();
            RefreshProvider();
        }

        private void btnEditProvider_Click(object sender, EventArgs e)
        {
            if (providerGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(providerGrid.SelectedRows[0], 0);
            EditProvider(id);
        }

        private void EditProvider(int id)
        {
            var form = new AddProviderForm(id);
            form.ShowDialog();
            RefreshProvider();
        }

        private void btnDeleteProvider_Click(object sender, EventArgs e)
        {
            if (providerGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(providerGrid.SelectedRows[0], 0);

            db.Providers.DeleteAllOnSubmit(db.Providers.Where(t => t.Id == id));
            db.SubmitChanges();

            RefreshProvider();
        }

        //
        //**********   OutNumber   **********
        //

        private void btnAddOutNumber_Click(object sender, EventArgs e)
        {
            var form = new AddOutNumberForm();
            form.ShowDialog();
            RefreshOutNumber();
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
            var form = new AddOutNumberForm(id);
            form.ShowDialog();
            RefreshOutNumber();
        }

        private void btnDeleteOutNumber_Click(object sender, EventArgs e)
        {
            if (outNumberGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(outNumberGrid.SelectedRows[0], 0);

            db.OutNumbers.DeleteAllOnSubmit(db.OutNumbers.Where(t => t.Id == id));
            db.SubmitChanges();

            RefreshOutNumber();
        }

        //
        //**********   InNumber   **********
        //

        private void btnAddInNumber_Click(object sender, EventArgs e)
        {
            var form = new AddInNumberForm();
            form.ShowDialog();
            RefreshInNumber();
        }

        private void btnEditInNumber_Click(object sender, EventArgs e)
        {
            if (inNumberGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(inNumberGrid.SelectedRows[0], 0);
            EditInNumber(id);
        }

        private void EditInNumber(int id)
        {
            var form = new AddInNumberForm(id);
            form.ShowDialog();
            RefreshInNumber();
        }

        private void btnDeleteInNumber_Click(object sender, EventArgs e)
        {
            if (inNumberGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(inNumberGrid.SelectedRows[0], 0);

            db.InNumbers.DeleteAllOnSubmit(db.InNumbers.Where(t => t.Id == id));
            db.SubmitChanges();

            RefreshInNumber();
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