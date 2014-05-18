using System;
using System.Linq;
using PhoneAnalyzer.Classes;

namespace PhoneAnalyzer.Forms
{
    public partial class AddSubdivisionForm : ValidateForm
    {
        private readonly int Id;
        private readonly PaDbDataContext db = DataBase.Context;

        public AddSubdivisionForm(int _Id = 0)
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
                Subdivision subdivision = GetFromControls();
                if (Id <= 0)
                {
                    db.Subdivisions.InsertOnSubmit(subdivision);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            Subdivision subdivision = db.Subdivisions.FirstOrDefault(o => o.Id == Id);

            txtName.Text = subdivision.Name;
            txtDirectorFio.Text = subdivision.DirectorFio;
            txtEmail.Text = subdivision.Email;
        }

        // Получаем объект из формы
        private Subdivision GetFromControls()
        {
            Subdivision subdivision = db.Subdivisions.FirstOrDefault(o => o.Id == Id) ?? new Subdivision();

            subdivision.Name = txtName.Text;
            subdivision.Email = txtEmail.Text;
            subdivision.DirectorFio = txtDirectorFio.Text;

            return subdivision;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(txtEmail, false);
            isValid &= ValidateControl(txtDirectorFio, false);

            return isValid;
        }
    }
}