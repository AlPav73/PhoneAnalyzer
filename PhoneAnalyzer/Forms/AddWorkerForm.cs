using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhoneAnalyzer.Classes;

namespace PhoneAnalyzer.Forms
{
    public partial class AddWorkerForm : ValidateForm
    {
        private readonly int Id;
        private readonly PaDbDataContext db = DataBase.Context;

        public AddWorkerForm(int _Id = 0)
        {
            InitializeComponent();

            FillComboBox(ddlSubdivision, Subdivisions.ToArray());

            Id = _Id;

            if (Id > 0)
            {
                SetToControls();
                Text = "Изменить " + Text;
                btnAdd.Text = "Изменить";
            }
            else
            {
                Id = 0;
                Text = "Добавить " + Text;
            }
        }

        private void FillComboBox(ComboBox ddl, object[] array)
        {
            ddl.Items.Clear();
            ddl.Items.AddRange(array);
            if (ddl.Items.Count > 0)
            {
                ddl.SelectedIndex = 0;
            }
        }  

        private Subdivision CurrentSubdivision
        {
            get
            {
                int index = ddlSubdivision.SelectedIndex;
                return SubdivisionByIndex(index);
            }
            set { ddlSubdivision.SelectedIndex = IndexBySubdivision(value); }
        }

        private List<Subdivision> Subdivisions
        {
            get { return db.Subdivisions.ToList(); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                Worker worker = GetFromControls();
                if (Id <= 0)
                {
                    db.Workers.InsertOnSubmit(worker);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            Worker worker = db.Workers.FirstOrDefault(o => o.Id == Id);

            CurrentSubdivision = worker.Subdivision;
            txtSalary.Text = worker.Salary.ToString();
            txtFio.Text = worker.Fio;
            txtLimitOne.Text = worker.LimitOne.ToString();
            txtLimitTwo.Text = worker.LimitTwo.ToString();
            txtLimitThree.Text = worker.LimitThree.ToString();
        }

        // Получаем объект из формы
        private Worker GetFromControls()
        {
            Worker worker = db.Workers.FirstOrDefault(o => o.Id == Id) ?? new Worker();

            worker.Subdivision = CurrentSubdivision;
            worker.Salary = int.Parse(txtSalary.Text);
            worker.LimitOne = int.Parse(txtLimitOne.Text);
            worker.LimitTwo = int.Parse(txtLimitTwo.Text);
            worker.LimitThree = int.Parse(txtLimitThree.Text);
            worker.LimitIn = 0;
            worker.Fio = txtFio.Text;

            return worker;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(ddlSubdivision);
            isValid &= ValidateControl(txtSalary, true);

            return isValid;
        }


        private int IndexBySubdivision(Subdivision subdivision)
        {
            return subdivision != null ? Subdivisions.FindIndex(c => c.Id == subdivision.Id) : -1;
        }

        private Subdivision SubdivisionByIndex(int index)
        {
            if ((index >= 0) && (index < Subdivisions.Count))
            {
                return Subdivisions[index];
            }

            return null;
        }
    }
}