using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhoneAnalyzer.Classes;
using PhoneAnalyzer.Helpers;
using PhoneAnalyzer.Type;

namespace PhoneAnalyzer.Forms
{
    public partial class AddNumberForm : ValidateForm
    {
        private readonly int Id;
        private readonly PaDbDataContext db = DataBase.Context;

        public AddNumberForm(int _Id = 0)
        {
            InitializeComponent();
            
            FillComboBox(ddlNumberTypes, NumberTypes);
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

        private string[] NumberTypes
        {
            get { return (from NumberType p in Enum.GetValues(typeof(NumberType)) select EnumHelper.Huminize(p)).ToArray(); }
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
                var inNumber = GetFromControls();
                if (Id <= 0)
                {
                    db.Numbers.InsertOnSubmit(inNumber);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            var number = db.Numbers.FirstOrDefault(o => o.Id == Id);

            CurrentWorker = number.Worker;
            ddlNumberTypes.SelectedIndex = IndexByNumberType(number.NumberType);
            txtNumber.Text = number.PhoneNumber;
        }

        // Получаем объект из формы
        private Number GetFromControls()
        {
            var number = db.Numbers.FirstOrDefault(o => o.Id == Id) ?? new Number();

            number.NumberType = NumberTypeByIndex(ddlNumberTypes.SelectedIndex);
            number.Worker = CurrentWorker;
            number.PhoneNumber = txtNumber.Text;

            return number;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(ddlNumberTypes);
            isValid &= ValidateControl(ddlWorker);
            isValid &= ValidateControl(txtNumber, false);

            return isValid;
        }


        private int IndexByNumberType(NumberType numberType)
        {
            return Enum.GetValues(typeof(NumberType)).Cast<NumberType>().TakeWhile(r => r != numberType).Count();
        }

        private NumberType NumberTypeByIndex(int index)
        {
            Array numberTypes = Enum.GetValues(typeof(NumberType));
            if ((index >= 0) && (index < numberTypes.Length))
            {
                return (NumberType)numberTypes.GetValue(index);
            }

            return NumberType.In;
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