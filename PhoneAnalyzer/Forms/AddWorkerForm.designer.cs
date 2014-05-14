namespace PhoneAnalyzer.Forms
{
    partial class AddWorkerForm
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
            this.labelSubdivisionId = new System.Windows.Forms.Label();
            this.labelSalary = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtFio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlSubdivision = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(225, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(144, 90);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelSubdivisionId
            // 
            this.labelSubdivisionId.AutoSize = true;
            this.labelSubdivisionId.Location = new System.Drawing.Point(14, 68);
            this.labelSubdivisionId.Name = "labelSubdivisionId";
            this.labelSubdivisionId.Size = new System.Drawing.Size(93, 13);
            this.labelSubdivisionId.TabIndex = 4;
            this.labelSubdivisionId.Text = "Подразделение: ";
            // 
            // labelSalary
            // 
            this.labelSalary.AutoSize = true;
            this.labelSalary.Location = new System.Drawing.Point(61, 41);
            this.labelSalary.Name = "labelSalary";
            this.labelSalary.Size = new System.Drawing.Size(45, 13);
            this.labelSalary.TabIndex = 2;
            this.labelSalary.Text = "Оклад: ";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(112, 38);
            this.txtSalary.MaxLength = 255;
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(188, 20);
            this.txtSalary.TabIndex = 3;
            // 
            // txtFio
            // 
            this.txtFio.Location = new System.Drawing.Point(111, 12);
            this.txtFio.MaxLength = 255;
            this.txtFio.Name = "txtFio";
            this.txtFio.Size = new System.Drawing.Size(188, 20);
            this.txtFio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фио: ";
            // 
            // ddlSubdivision
            // 
            this.ddlSubdivision.FormattingEnabled = true;
            this.ddlSubdivision.Location = new System.Drawing.Point(113, 64);
            this.ddlSubdivision.Name = "ddlSubdivision";
            this.ddlSubdivision.Size = new System.Drawing.Size(187, 21);
            this.ddlSubdivision.TabIndex = 5;
            // 
            // AddWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 125);
            this.Controls.Add(this.ddlSubdivision);
            this.Controls.Add(this.txtFio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSubdivisionId);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.labelSalary);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddWorkerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "сотрудника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelSubdivisionId;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label labelSalary;
        private System.Windows.Forms.TextBox txtFio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlSubdivision;

    }
}
