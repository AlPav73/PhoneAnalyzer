using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhoneAnalyzer.Classes;

namespace PhoneAnalyzer.Forms
{
    public partial class AddInNumberForm : ValidateForm
    {
        private readonly int Id;
        private readonly PaDbDataContext db = DataBase.Context;

        public AddInNumberForm(int _Id = 0)
        {
            InitializeComponent();
            
            FillComboBox(ddlOutNumber, OutNumbers.ToArray());
            FillComboBox(ddlWorker, Workers.ToArray());

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

        private OutNumber CurrentOutNumber
        {
            get
            {
                int index = ddlOutNumber.SelectedIndex;
                return OutNumberByIndex(index);
            }
            set { ddlOutNumber.SelectedIndex = IndexByOutNumber(value); }
        }

        private List<OutNumber> OutNumbers
        {
            get { return db.OutNumbers.ToList(); }
        }

        private Worker CurrentWorker
        {
            get
            {
                int index = ddlWorker.SelectedIndex;
                return WorkerByIndex(index);
            }
            set { ddlWorker.SelectedIndex = IndexByWorker(value); }
        }

        private List<Worker> Workers
        {
            get { return db.Workers.ToList(); }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                InNumber inNumber = GetFromControls();
                if (Id <= 0)
                {
                    db.InNumbers.InsertOnSubmit(inNumber);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            InNumber inNumber = db.InNumbers.SingleOrDefault(o => o.Id == Id);

            CurrentOutNumber = inNumber.OutNumber;
            CurrentWorker = inNumber.Worker;
            txtNumber.Text = inNumber.Number;
        }

        // Получаем объект из формы
        private InNumber GetFromControls()
        {
            InNumber inNumber = db.InNumbers.SingleOrDefault(o => o.Id == Id) ?? new InNumber();

            inNumber.OutNumber = CurrentOutNumber;
            inNumber.Worker = CurrentWorker;
            inNumber.Number = txtNumber.Text;

            return inNumber;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(ddlOutNumber);
            isValid &= ValidateControl(ddlWorker);
            isValid &= ValidateControl(txtNumber, false);

            return isValid;
        }


        private int IndexByOutNumber(OutNumber outNumber)
        {
            return outNumber != null ? OutNumbers.FindIndex(c => c.Id == outNumber.Id) : -1;
        }

        private OutNumber OutNumberByIndex(int index)
        {
            if ((index >= 0) && (index < OutNumbers.Count))
            {
                return OutNumbers[index];
            }

            return null;
        }


        private int IndexByWorker(Worker worker)
        {
            return worker != null ? Workers.FindIndex(c => c.Id == worker.Id) : -1;
        }

        private Worker WorkerByIndex(int index)
        {
            if ((index >= 0) && (index < Workers.Count))
            {
                return Workers[index];
            }

            return null;
        }
    }
}