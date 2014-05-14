using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhoneAnalyzer.Classes;

namespace PhoneAnalyzer.Forms
{
    public partial class AddOutNumberForm : ValidateForm
    {
        private readonly int Id;
        private readonly PaDbDataContext db = DataBase.Context;

        public AddOutNumberForm(int _Id = 0)
        {
            InitializeComponent();

            FillComboBox(ddlProvider, Providers.ToArray());

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

        private Provider CurrentProvider
        {
            get
            {
                int index = ddlProvider.SelectedIndex;
                return ProviderByIndex(index);
            }
            set { ddlProvider.SelectedIndex = IndexByProvider(value); }
        }

        private List<Provider> Providers
        {
            get { return db.Providers.ToList(); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                OutNumber outNumber = GetFromControls();
                if (Id <= 0)
                {
                    db.OutNumbers.InsertOnSubmit(outNumber);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            OutNumber outNumber = db.OutNumbers.SingleOrDefault(o => o.Id == Id);

            CurrentProvider = outNumber.Provider;
            txtNumber.Text = outNumber.Number;
        }

        // Получаем объект из формы
        private OutNumber GetFromControls()
        {
            OutNumber outNumber = db.OutNumbers.SingleOrDefault(o => o.Id == Id) ?? new OutNumber();

            outNumber.Provider = CurrentProvider;
            outNumber.Number = txtNumber.Text;

            return outNumber;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(ddlProvider);
            isValid &= ValidateControl(txtNumber, false);

            return isValid;
        }

        private int IndexByProvider(Provider provider)
        {
            return provider != null ? Providers.FindIndex(c => c.Id == provider.Id) : -1;
        }

        private Provider ProviderByIndex(int index)
        {
            if ((index >= 0) && (index < Providers.Count))
            {
                return Providers[index];
            }

            return null;
        }
    }
}