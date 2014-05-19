namespace PhoneAnalyzer.Forms
{
    partial class AddCallForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelOutNumberId = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.ddlNumber = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSeconds = new System.Windows.Forms.TextBox();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.ddlTariff = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(207, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(126, 191);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelOutNumberId
            // 
            this.labelOutNumberId.AutoSize = true;
            this.labelOutNumberId.Location = new System.Drawing.Point(41, 11);
            this.labelOutNumberId.Name = "labelOutNumberId";
            this.labelOutNumberId.Size = new System.Drawing.Size(47, 13);
            this.labelOutNumberId.TabIndex = 0;
            this.labelOutNumberId.Text = "Номер: ";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(6, 37);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(82, 13);
            this.labelNumber.TabIndex = 2;
            this.labelNumber.Text = "Куда звонили: ";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(94, 34);
            this.txtNumber.MaxLength = 255;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(188, 20);
            this.txtNumber.TabIndex = 3;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(49, 63);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(39, 13);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "Дата: ";
            // 
            // ddlNumber
            // 
            this.ddlNumber.FormattingEnabled = true;
            this.ddlNumber.Location = new System.Drawing.Point(94, 7);
            this.ddlNumber.Name = "ddlNumber";
            this.ddlNumber.Size = new System.Drawing.Size(188, 21);
            this.ddlNumber.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(94, 60);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(188, 20);
            this.dtpDate.TabIndex = 5;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(94, 165);
            this.txtPrice.MaxLength = 255;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(188, 20);
            this.txtPrice.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Сумма: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = ":";
            // 
            // txtSeconds
            // 
            this.txtSeconds.Location = new System.Drawing.Point(162, 86);
            this.txtSeconds.MaxLength = 2;
            this.txtSeconds.Name = "txtSeconds";
            this.txtSeconds.Size = new System.Drawing.Size(22, 20);
            this.txtSeconds.TabIndex = 9;
            // 
            // txtMinutes
            // 
            this.txtMinutes.Location = new System.Drawing.Point(128, 86);
            this.txtMinutes.MaxLength = 2;
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(22, 20);
            this.txtMinutes.TabIndex = 11;
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(94, 86);
            this.txtHours.MaxLength = 2;
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(22, 20);
            this.txtHours.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Время: ";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(94, 112);
            this.txtDuration.MaxLength = 255;
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(188, 20);
            this.txtDuration.TabIndex = 13;
            this.txtDuration.TextChanged += new System.EventHandler(this.txtDuration_TextChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(2, 115);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(86, 13);
            this.labelTime.TabIndex = 12;
            this.labelTime.Text = "Длительность: ";
            // 
            // ddlTariff
            // 
            this.ddlTariff.FormattingEnabled = true;
            this.ddlTariff.Location = new System.Drawing.Point(94, 138);
            this.ddlTariff.Name = "ddlTariff";
            this.ddlTariff.Size = new System.Drawing.Size(188, 21);
            this.ddlTariff.TabIndex = 18;
            this.ddlTariff.SelectedIndexChanged += new System.EventHandler(this.ddlTariff_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Оператор: ";
            // 
            // AddCallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 222);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ddlTariff);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSeconds);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.ddlNumber);
            this.Controls.Add(this.labelOutNumberId);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "звонок";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelOutNumberId;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.ComboBox ddlNumber;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSeconds;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.ComboBox ddlTariff;
        private System.Windows.Forms.Label label5;

    }
}
