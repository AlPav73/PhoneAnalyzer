using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhoneAnalyzer.Forms
{
    public class ValidateForm : Form
    {
        public bool ValidateControl(Control control, bool isNumberic)
        {
            return isNumberic ? ValidateNumbericControl(control) : ValidateStringControl(control);
        }

        public bool ValidateControl(ComboBox comboBox)
        {
            comboBox.BackColor = IsValidComboBox(comboBox) ? Color.White : Color.Salmon;
            return IsValidComboBox(comboBox);
        }

        public bool ValidateDecimalControl(Control control)
        {
            string strNumber = control.Text;
            control.BackColor = IsValidDecimal(strNumber) ? Color.White : Color.Salmon;
            return IsValidDecimal(strNumber);
        }


        private bool ValidateStringControl(Control control)
        {
            string text = control.Text;
            control.BackColor = IsValidString(text) ? Color.White : Color.Salmon;
            return IsValidString(text);
        }

        private bool ValidateNumbericControl(Control control)
        {
            string strNumber = control.Text;
            control.BackColor = IsValidNumber(strNumber) ? Color.White : Color.Salmon;
            return IsValidNumber(strNumber);
        }

        private bool IsValidString(string text)
        {
            return text.Trim().Length != 0;
        }

        private bool IsValidNumber(string strNumber)
        {
            int number = 0;
            return IsValidString(strNumber) && Int32.TryParse(strNumber, out number);
        }

        private bool IsValidDecimal(string strNumber)
        {
            decimal number = 0;
            return IsValidString(strNumber) && decimal.TryParse(strNumber, out number);
        }

        private bool IsValidComboBox(ComboBox comboBox)
        {
            return comboBox.SelectedIndex != -1;
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // ValidateForm
            // 
            ClientSize = new Size(292, 273);
            Name = "ValidateForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
        }
    }
}