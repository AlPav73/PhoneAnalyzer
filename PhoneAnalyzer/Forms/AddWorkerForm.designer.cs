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
            this.txtLimitOne = new System.Windows.Forms.TextBox();
            this.txtLimitTwo = new System.Windows.Forms.TextBox();
            this.txtLimitThree = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(225, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(144, 169);
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
            this.labelSubdivisionId.Location = new System.Drawing.Point(13, 67);
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
            this.txtFio.Location = new System.Drawing.Point(112, 12);
            this.txtFio.MaxLength = 255;
            this.txtFio.Name = "txtFio";
            this.txtFio.Size = new System.Drawing.Size(188, 20);
            this.txtFio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фио: ";
            // 
            // ddlSubdivision
            // 
            this.ddlSubdivision.FormattingEnabled = true;
            this.ddlSubdivision.Location = new System.Drawing.Point(112, 64);
            this.ddlSubdivision.Name = "ddlSubdivision";
            this.ddlSubdivision.Size = new System.Drawing.Size(188, 21);
            this.ddlSubdivision.TabIndex = 5;
            // 
            // txtLimitOne
            // 
            this.txtLimitOne.Location = new System.Drawing.Point(112, 91);
            this.txtLimitOne.Name = "txtLimitOne";
            this.txtLimitOne.Size = new System.Drawing.Size(188, 20);
            this.txtLimitOne.TabIndex = 8;
            // 
            // txtLimitTwo
            // 
            this.txtLimitTwo.Location = new System.Drawing.Point(112, 117);
            this.txtLimitTwo.Name = "txtLimitTwo";
            this.txtLimitTwo.Size = new System.Drawing.Size(188, 20);
            this.txtLimitTwo.TabIndex = 9;
            // 
            // txtLimitThree
            // 
            this.txtLimitThree.Location = new System.Drawing.Point(112, 143);
            this.txtLimitThree.Name = "txtLimitThree";
            this.txtLimitThree.Size = new System.Drawing.Size(188, 20);
            this.txtLimitThree.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Лим. Миртелек.: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Лим. Городтелек.: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Лим. Мест.телек.: ";
            // 
            // AddWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 200);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLimitThree);
            this.Controls.Add(this.txtLimitTwo);
            this.Controls.Add(this.txtLimitOne);
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
        private System.Windows.Forms.TextBox txtLimitOne;
        private System.Windows.Forms.TextBox txtLimitTwo;
        private System.Windows.Forms.TextBox txtLimitThree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

    }
}
