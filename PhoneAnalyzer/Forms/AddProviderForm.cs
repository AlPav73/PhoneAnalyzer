using System;
using System.Linq;
using PhoneAnalyzer.Classes;

namespace PhoneAnalyzer.Forms
{
    public partial class AddProviderForm : ValidateForm
    {
        private readonly int Id;
        private readonly PaDbDataContext db = DataBase.Context;

        public AddProviderForm(int _Id = 0)
        {
            InitializeComponent();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                Provider provider = GetFromControls();
                if (Id <= 0)
                {
                    db.Providers.InsertOnSubmit(provider);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            Provider provider = db.Providers.SingleOrDefault(o => o.Id == Id);

            txtName.Text = provider.Name;
            txtTariff.Text = provider.Tariff.ToString();
        }

        // Получаем объект из формы
        private Provider GetFromControls()
        {
            Provider provider = db.Providers.SingleOrDefault(o => o.Id == Id) ?? new Provider();

            provider.Name = txtName.Text;
            provider.Tariff = int.Parse(txtTariff.Text);

            return provider;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(txtTariff, true);

            return isValid;
        }
    }
}