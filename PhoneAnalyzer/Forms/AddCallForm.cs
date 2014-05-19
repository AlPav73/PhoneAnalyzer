using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Helpers;
using PhoneAnalyzer.Properties;
using PhoneAnalyzer.Type;

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
            FillComboBox(ddlTariff, TariffTypes.ToArray());

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
            Call call = db.Calls.FirstOrDefault(o => o.Id == Id);

            CurrentNumber = call.Number;
            CurrentDate = call.Date;
            CurrentTariff = (TariffType) call.Tariff;
            txtNumber.Text = call.ToNumber;
            txtDuration.Text = call.Duration.ToString();
            txtPrice.Text = call.Price.ToString();
        }

        // Получаем объект из формы
        private Call GetFromControls()
        {
            Call call = db.Calls.FirstOrDefault(o => o.Id == Id) ?? new Call();

            call.Number = CurrentNumber;
            call.ToNumber = txtNumber.Text;
            call.Date = CurrentDate;
            call.Duration = int.Parse(txtDuration.Text);
            call.Price = decimal.Parse(txtPrice.Text);
            call.Tariff = (int) CurrentTariff;

            return call;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(ddlNumber);
            isValid &= ValidateControl(ddlTariff);
            isValid &= ValidateControl(txtNumber, false);
            isValid &= ValidateControl(txtDuration, true);
            isValid &= ValidateDecimalControl(txtPrice);
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


        private string[] TariffTypes
        {
            get { return (from TariffType TariffType in Enum.GetValues(typeof(TariffType)) select EnumHelper.Huminize(TariffType)).ToArray(); }
        }

        private TariffType CurrentTariff
        {
            get
            {
                int index = ddlTariff.SelectedIndex;
                Array TariffTypes = Enum.GetValues(typeof(TariffType));
                if ((index >= 0) && (index < TariffTypes.Length))
                {
                    return (TariffType)TariffTypes.GetValue(index);
                }

                return TariffType.One;
            }
            set
            {
                ddlTariff.SelectedIndex = IndexByTariffType(value);
            }
        }

        private int IndexByTariffType(TariffType TariffType)
        {
            return Enum.GetValues(typeof(TariffType)).Cast<TariffType>().TakeWhile(r => r != TariffType).Count();
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

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            CalcTotalPrice();
        }

        private void ddlTariff_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcTotalPrice();
        }

        private void CalcTotalPrice()
        {
            int duration = 0;
            int.TryParse(txtDuration.Text, out duration);

            decimal totalPrice = 0;

            switch (CurrentTariff)
            {
                case TariffType.One:
                    totalPrice = duration * Setting.TariffOne;
                    break;

                case TariffType.Two:
                    totalPrice = duration * Setting.TariffTwo;
                    break;

                case TariffType.Three:
                    totalPrice = duration * Setting.TariffThree;
                    break;
            }

            txtPrice.Text = decimal.Round(totalPrice / 60, 2).ToString();
        }
    }
}