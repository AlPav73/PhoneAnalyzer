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

            FillComboBox(ddlNumber, Numbers.ToArray());

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

            CurrentNumber = call.Number;
            CurrentDate = call.Date;
            txtNumber.Text = call.ToNumber;
            txtDuration.Text = call.Duration.ToString();
            txtPrice.Text = call.Price.ToString();
        }

        // Получаем объект из формы
        private Call GetFromControls()
        {
            Call call = db.Calls.SingleOrDefault(o => o.Id == Id) ?? new Call();

            call.Number = CurrentNumber;
            call.ToNumber = txtNumber.Text;
            call.Date = CurrentDate;
            call.Duration = int.Parse(txtDuration.Text);
            call.Price = int.Parse(txtPrice.Text);

            return call;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(ddlNumber);
            isValid &= ValidateControl(txtNumber, false);
            isValid &= ValidateControl(txtDuration, true);
            isValid &= ValidateControl(txtPrice, true);
            isValid &= ValidateControl(txtHours, true);
            isValid &= ValidateControl(txtMinutes, true);
            isValid &= ValidateControl(txtSeconds, true);

            return isValid;
        }



        private DateTime CurrentDate
        {
            get
            {
                var date = dtpDate.Value.Date;
                date = date.AddHours(int.Parse(txtHours.Text));
                date = date.AddMinutes(int.Parse(txtMinutes.Text));
                date = date.AddSeconds(int.Parse(txtSeconds.Text));
                return date;
            }
            set
            {
                dtpDate.Value = value.Date;
                txtHours.Text = value.Hour.ToString();
                txtMinutes.Text = value.Minute.ToString();
                txtSeconds.Text = value.Second.ToString();
            }
        }





        private Number CurrentNumber
        {
            get
            {
                int index = ddlNumber.SelectedIndex;
                return NumberByIndex(index);
            }
            set { ddlNumber.SelectedIndex = IndexByNumber(value); }
        }

        private List<Number> Numbers
        {
            get { return db.Numbers.ToList(); }
        }

        private int IndexByNumber(Number number)
        {
            return number != null ? Numbers.FindIndex(c => c.Id == number.Id) : -1;
        }

        private Number NumberByIndex(int index)
        {
            if ((index >= 0) && (index < Numbers.Count))
            {
                return Numbers[index];
            }

            return null;
        }
    }
}