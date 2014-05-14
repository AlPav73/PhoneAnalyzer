using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhoneAnalyzer.Classes;

namespace PhoneAnalyzer.Forms
{
    public partial class AddCallForm : ValidateForm
    {
        private readonly int Id;
        private readonly PaDbDataContext db = DataBase.Context;

        public AddCallForm(int _Id = 0)
        {
            InitializeComponent();

            FillComboBox(ddlOutNumber, OutNumbers.ToArray());

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
                Call call = GetFromControls();
                if (Id <= 0)
                {
                    db.Calls.InsertOnSubmit(call);
                }

                db.SubmitChanges(); 
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            Call call = db.Calls.SingleOrDefault(o => o.Id == Id);

            CurrentOutNumber = call.OutNumber;
            txtNumber.Text = call.Number;
            dtpDate.Value = call.Date;
            txtTime.Text = call.Time.ToString();
        }

        // Получаем объект из формы
        private Call GetFromControls()
        {
            Call call = db.Calls.SingleOrDefault(o => o.Id == Id) ?? new Call();

            call.OutNumber = CurrentOutNumber;
            call.Number = txtNumber.Text;
            call.Date = dtpDate.Value;
            call.Time = int.Parse(txtTime.Text);

            return call;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(ddlOutNumber);
            isValid &= ValidateControl(txtNumber, false);
            isValid &= ValidateControl(txtTime, true);

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
    }
}