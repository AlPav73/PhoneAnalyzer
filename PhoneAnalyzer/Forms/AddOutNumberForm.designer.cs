namespace PhoneAnalyzer.Forms
{
    partial class AddOutNumberForm
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
            this.labelProviderId = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.ddlProvider = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(207, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(126, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelProviderId
            // 
            this.labelProviderId.AutoSize = true;
            this.labelProviderId.Location = new System.Drawing.Point(19, 10);
            this.labelProviderId.Name = "labelProviderId";
            this.labelProviderId.Size = new System.Drawing.Size(69, 13);
            this.labelProviderId.TabIndex = 6;
            this.labelProviderId.Text = "Провайдер: ";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(41, 37);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(47, 13);
            this.labelNumber.TabIndex = 6;
            this.labelNumber.Text = "Номер: ";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(94, 34);
            this.txtNumber.MaxLength = 255;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(188, 20);
            this.txtNumber.TabIndex = 2;
            // 
            // ddlProvider
            // 
            this.ddlProvider.FormattingEnabled = true;
            this.ddlProvider.Location = new System.Drawing.Point(94, 7);
            this.ddlProvider.Name = "ddlProvider";
            this.ddlProvider.Size = new System.Drawing.Size(188, 21);
            this.ddlProvider.TabIndex = 8;
            // 
            // AddOutNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 94);
            this.Controls.Add(this.ddlProvider);
            this.Controls.Add(this.labelProviderId);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddOutNumberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "внешний номер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelProviderId;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.ComboBox ddlProvider;

    }
}
