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
            this.labelTime = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.ddlOutNumber = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(207, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(126, 112);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
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
            this.labelOutNumberId.TabIndex = 6;
            this.labelOutNumberId.Text = "Номер: ";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(6, 37);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(82, 13);
            this.labelNumber.TabIndex = 6;
            this.labelNumber.Text = "Куда звонили: ";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(94, 34);
            this.txtNumber.MaxLength = 255;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(188, 20);
            this.txtNumber.TabIndex = 1;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(49, 63);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(39, 13);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = "Дата: ";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(42, 89);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(46, 13);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "Время: ";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(94, 86);
            this.txtTime.MaxLength = 255;
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(188, 20);
            this.txtTime.TabIndex = 3;
            // 
            // ddlOutNumber
            // 
            this.ddlOutNumber.FormattingEnabled = true;
            this.ddlOutNumber.Location = new System.Drawing.Point(94, 7);
            this.ddlOutNumber.Name = "ddlOutNumber";
            this.ddlOutNumber.Size = new System.Drawing.Size(188, 21);
            this.ddlOutNumber.TabIndex = 0;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(94, 60);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(188, 20);
            this.dtpDate.TabIndex = 2;
            // 
            // AddCallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 142);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.ddlOutNumber);
            this.Controls.Add(this.labelOutNumberId);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.labelTime);
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
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.ComboBox ddlOutNumber;
        private System.Windows.Forms.DateTimePicker dtpDate;

    }
}
