using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhoneAnalyzer.Classes;

namespace PhoneAnalyzer.Forms
{
    public partial class AddAtcCallForm : ValidateForm
    {
        private readonly int Id;
        private readonly PaDbDataContext db = DataBase.Context;

        public AddAtcCallForm(int _Id = 0)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                AtcCall atcCall = GetFromControls();
                if (Id <= 0)
                {
                    db.AtcCalls.InsertOnSubmit(atcCall);
                }

                db.SubmitChanges(); 
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            AtcCall atcCall = db.AtcCalls.SingleOrDefault(o => o.Id == Id);

            CurrentSubdivision = atcCall.Subdivision;
            txtNumber.Text = atcCall.ToNumber;
            CurrentDate = atcCall.Date;
            txtDuration.Text = atcCall.Duration.ToString();
        }

        // Получаем объект из формы
        private AtcCall GetFromControls()
        {
            AtcCall atcCall = db.AtcCalls.SingleOrDefault(o => o.Id == Id) ?? new AtcCall();

            atcCall.Subdivision = CurrentSubdivision;
            atcCall.ToNumber = txtNumber.Text;
            atcCall.Date = CurrentDate;
            atcCall.Duration = int.Parse(txtDuration.Text);

            return atcCall;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(ddlSubdivision);
            isValid &= ValidateControl(txtNumber, false);
            isValid &= ValidateControl(txtDuration, true);
            isValid &= ValidateControl(txtHours, true);
            isValid &= ValidateControl(txtSeconds, true);
            isValid &= ValidateControl(txtMinutes, true);

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