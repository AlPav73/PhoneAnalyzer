namespace PhoneAnalyzer.Forms
{
    partial class AddNumberForm
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
            this.labelWorkerId = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.ddlNumberTypes = new System.Windows.Forms.ComboBox();
            this.ddlWorker = new System.Windows.Forms.ComboBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(227, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(146, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelOutNumberId
            // 
            this.labelOutNumberId.AutoSize = true;
            this.labelOutNumberId.Location = new System.Drawing.Point(31, 68);
            this.labelOutNumberId.Name = "labelOutNumberId";
            this.labelOutNumberId.Size = new System.Drawing.Size(73, 13);
            this.labelOutNumberId.TabIndex = 4;
            this.labelOutNumberId.Text = "Тип номера: ";
            // 
            // labelWorkerId
            // 
            this.labelWorkerId.AutoSize = true;
            this.labelWorkerId.Location = new System.Drawing.Point(38, 15);
            this.labelWorkerId.Name = "labelWorkerId";
            this.labelWorkerId.Size = new System.Drawing.Size(66, 13);
            this.labelWorkerId.TabIndex = 0;
            this.labelWorkerId.Text = "Сотрудник: ";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(57, 42);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(47, 13);
            this.labelNumber.TabIndex = 2;
            this.labelNumber.Text = "Номер: ";
            // 
            // ddlNumberTypes
            // 
            this.ddlNumberTypes.FormattingEnabled = true;
            this.ddlNumberTypes.Location = new System.Drawing.Point(110, 65);
            this.ddlNumberTypes.Name = "ddlNumberTypes";
            this.ddlNumberTypes.Size = new System.Drawing.Size(192, 21);
            this.ddlNumberTypes.TabIndex = 5;
            // 
            // ddlWorker
            // 
            this.ddlWorker.FormattingEnabled = true;
            this.ddlWorker.Location = new System.Drawing.Point(110, 12);
            this.ddlWorker.Name = "ddlWorker";
            this.ddlWorker.Size = new System.Drawing.Size(192, 21);
            this.ddlWorker.TabIndex = 1;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(110, 39);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(192, 20);
            this.txtNumber.TabIndex = 3;
            // 
            // AddNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 126);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.ddlWorker);
            this.Controls.Add(this.ddlNumberTypes);
            this.Controls.Add(this.labelOutNumberId);
            this.Controls.Add(this.labelWorkerId);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddNumberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "номер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelOutNumberId;
        private System.Windows.Forms.Label labelWorkerId;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.ComboBox ddlNumberTypes;
        private System.Windows.Forms.ComboBox ddlWorker;
        private System.Windows.Forms.TextBox txtNumber;

    }
}
