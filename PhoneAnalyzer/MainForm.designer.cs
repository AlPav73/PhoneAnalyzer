namespace PhoneAnalyzer
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.subdivisionTab = new System.Windows.Forms.TabPage();
            this.subdivisionGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteSubdivision = new System.Windows.Forms.Button();
            this.btnEditSubdivision = new System.Windows.Forms.Button();
            this.btnAddSubdivision = new System.Windows.Forms.Button();
            this.numberTab = new System.Windows.Forms.TabPage();
            this.outNumberGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteOutNumber = new System.Windows.Forms.Button();
            this.btnEditOutNumber = new System.Windows.Forms.Button();
            this.btnAddOutNumber = new System.Windows.Forms.Button();
            this.workerTab = new System.Windows.Forms.TabPage();
            this.workerGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteWorker = new System.Windows.Forms.Button();
            this.btnEditWorker = new System.Windows.Forms.Button();
            this.btnAddWorker = new System.Windows.Forms.Button();
            this.callTab = new System.Windows.Forms.TabPage();
            this.callGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteCall = new System.Windows.Forms.Button();
            this.btnEditCall = new System.Windows.Forms.Button();
            this.btnAddCall = new System.Windows.Forms.Button();
            this.atcCallTab = new System.Windows.Forms.TabPage();
            this.atcCallGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteAtcCall = new System.Windows.Forms.Button();
            this.btnEditAtcCall = new System.Windows.Forms.Button();
            this.btnAddAtcCall = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFinEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.subdivisionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subdivisionGrid)).BeginInit();
            this.numberTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outNumberGrid)).BeginInit();
            this.workerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workerGrid)).BeginInit();
            this.callTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callGrid)).BeginInit();
            this.atcCallTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atcCallGrid)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.subdivisionTab);
            this.tabControl.Controls.Add(this.numberTab);
            this.tabControl.Controls.Add(this.workerTab);
            this.tabControl.Controls.Add(this.callTab);
            this.tabControl.Controls.Add(this.atcCallTab);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(791, 573);
            this.tabControl.TabIndex = 0;
            // 
            // subdivisionTab
            // 
            this.subdivisionTab.Controls.Add(this.subdivisionGrid);
            this.subdivisionTab.Controls.Add(this.btnDeleteSubdivision);
            this.subdivisionTab.Controls.Add(this.btnEditSubdivision);
            this.subdivisionTab.Controls.Add(this.btnAddSubdivision);
            this.subdivisionTab.Location = new System.Drawing.Point(4, 22);
            this.subdivisionTab.Name = "subdivisionTab";
            this.subdivisionTab.Padding = new System.Windows.Forms.Padding(3);
            this.subdivisionTab.Size = new System.Drawing.Size(783, 547);
            this.subdivisionTab.TabIndex = 0;
            this.subdivisionTab.Text = "Подразделения";
            this.subdivisionTab.UseVisualStyleBackColor = true;
            // 
            // subdivisionGrid
            // 
            this.subdivisionGrid.AllowUserToAddRows = false;
            this.subdivisionGrid.AllowUserToDeleteRows = false;
            this.subdivisionGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.subdivisionGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.subdivisionGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subdivisionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.subdivisionGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.subdivisionGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.subdivisionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subdivisionGrid.Location = new System.Drawing.Point(8, 6);
            this.subdivisionGrid.Name = "subdivisionGrid";
            this.subdivisionGrid.ReadOnly = true;
            this.subdivisionGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subdivisionGrid.Size = new System.Drawing.Size(768, 504);
            this.subdivisionGrid.TabIndex = 0;
            // 
            // btnDeleteSubdivision
            // 
            this.btnDeleteSubdivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSubdivision.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteSubdivision.Name = "btnDeleteSubdivision";
            this.btnDeleteSubdivision.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSubdivision.TabIndex = 3;
            this.btnDeleteSubdivision.Text = "Удалить";
            this.btnDeleteSubdivision.UseVisualStyleBackColor = true;
            this.btnDeleteSubdivision.Click += new System.EventHandler(this.btnDeleteSubdivision_Click);
            // 
            // btnEditSubdivision
            // 
            this.btnEditSubdivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSubdivision.Location = new System.Drawing.Point(620, 516);
            this.btnEditSubdivision.Name = "btnEditSubdivision";
            this.btnEditSubdivision.Size = new System.Drawing.Size(75, 23);
            this.btnEditSubdivision.TabIndex = 2;
            this.btnEditSubdivision.Text = "Изменить";
            this.btnEditSubdivision.UseVisualStyleBackColor = true;
            this.btnEditSubdivision.Click += new System.EventHandler(this.btnEditSubdivision_Click);
            // 
            // btnAddSubdivision
            // 
            this.btnAddSubdivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSubdivision.Location = new System.Drawing.Point(539, 516);
            this.btnAddSubdivision.Name = "btnAddSubdivision";
            this.btnAddSubdivision.Size = new System.Drawing.Size(75, 23);
            this.btnAddSubdivision.TabIndex = 1;
            this.btnAddSubdivision.Text = "Добавить";
            this.btnAddSubdivision.UseVisualStyleBackColor = true;
            this.btnAddSubdivision.Click += new System.EventHandler(this.btnAddSubdivision_Click);
            // 
            // numberTab
            // 
            this.numberTab.Controls.Add(this.outNumberGrid);
            this.numberTab.Controls.Add(this.btnDeleteOutNumber);
            this.numberTab.Controls.Add(this.btnEditOutNumber);
            this.numberTab.Controls.Add(this.btnAddOutNumber);
            this.numberTab.Location = new System.Drawing.Point(4, 22);
            this.numberTab.Name = "numberTab";
            this.numberTab.Padding = new System.Windows.Forms.Padding(3);
            this.numberTab.Size = new System.Drawing.Size(783, 547);
            this.numberTab.TabIndex = 0;
            this.numberTab.Text = "Номера";
            this.numberTab.UseVisualStyleBackColor = true;
            // 
            // outNumberGrid
            // 
            this.outNumberGrid.AllowUserToAddRows = false;
            this.outNumberGrid.AllowUserToDeleteRows = false;
            this.outNumberGrid.AllowUserToOrderColumns = true;
            this.outNumberGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.outNumberGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outNumberGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.outNumberGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.outNumberGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.outNumberGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outNumberGrid.Location = new System.Drawing.Point(8, 6);
            this.outNumberGrid.Name = "outNumberGrid";
            this.outNumberGrid.ReadOnly = true;
            this.outNumberGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.outNumberGrid.Size = new System.Drawing.Size(768, 504);
            this.outNumberGrid.TabIndex = 0;
            // 
            // btnDeleteOutNumber
            // 
            this.btnDeleteOutNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteOutNumber.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteOutNumber.Name = "btnDeleteOutNumber";
            this.btnDeleteOutNumber.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOutNumber.TabIndex = 3;
            this.btnDeleteOutNumber.Text = "Удалить";
            this.btnDeleteOutNumber.UseVisualStyleBackColor = true;
            this.btnDeleteOutNumber.Click += new System.EventHandler(this.btnDeleteOutNumber_Click);
            // 
            // btnEditOutNumber
            // 
            this.btnEditOutNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditOutNumber.Location = new System.Drawing.Point(620, 516);
            this.btnEditOutNumber.Name = "btnEditOutNumber";
            this.btnEditOutNumber.Size = new System.Drawing.Size(75, 23);
            this.btnEditOutNumber.TabIndex = 2;
            this.btnEditOutNumber.Text = "Изменить";
            this.btnEditOutNumber.UseVisualStyleBackColor = true;
            this.btnEditOutNumber.Click += new System.EventHandler(this.btnEditOutNumber_Click);
            // 
            // btnAddOutNumber
            // 
            this.btnAddOutNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOutNumber.Location = new System.Drawing.Point(539, 516);
            this.btnAddOutNumber.Name = "btnAddOutNumber";
            this.btnAddOutNumber.Size = new System.Drawing.Size(75, 23);
            this.btnAddOutNumber.TabIndex = 1;
            this.btnAddOutNumber.Text = "Добавить";
            this.btnAddOutNumber.UseVisualStyleBackColor = true;
            this.btnAddOutNumber.Click += new System.EventHandler(this.btnAddOutNumber_Click);
            // 
            // workerTab
            // 
            this.workerTab.Controls.Add(this.workerGrid);
            this.workerTab.Controls.Add(this.btnDeleteWorker);
            this.workerTab.Controls.Add(this.btnEditWorker);
            this.workerTab.Controls.Add(this.btnAddWorker);
            this.workerTab.Location = new System.Drawing.Point(4, 22);
            this.workerTab.Name = "workerTab";
            this.workerTab.Padding = new System.Windows.Forms.Padding(3);
            this.workerTab.Size = new System.Drawing.Size(783, 547);
            this.workerTab.TabIndex = 0;
            this.workerTab.Text = "Сотрудники";
            this.workerTab.UseVisualStyleBackColor = true;
            // 
            // workerGrid
            // 
            this.workerGrid.AllowUserToAddRows = false;
            this.workerGrid.AllowUserToDeleteRows = false;
            this.workerGrid.AllowUserToOrderColumns = true;
            this.workerGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.workerGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.workerGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.workerGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.workerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workerGrid.Location = new System.Drawing.Point(8, 6);
            this.workerGrid.Name = "workerGrid";
            this.workerGrid.ReadOnly = true;
            this.workerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.workerGrid.Size = new System.Drawing.Size(768, 504);
            this.workerGrid.TabIndex = 0;
            // 
            // btnDeleteWorker
            // 
            this.btnDeleteWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteWorker.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteWorker.Name = "btnDeleteWorker";
            this.btnDeleteWorker.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteWorker.TabIndex = 3;
            this.btnDeleteWorker.Text = "Удалить";
            this.btnDeleteWorker.UseVisualStyleBackColor = true;
            this.btnDeleteWorker.Click += new System.EventHandler(this.btnDeleteWorker_Click);
            // 
            // btnEditWorker
            // 
            this.btnEditWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditWorker.Location = new System.Drawing.Point(620, 516);
            this.btnEditWorker.Name = "btnEditWorker";
            this.btnEditWorker.Size = new System.Drawing.Size(75, 23);
            this.btnEditWorker.TabIndex = 2;
            this.btnEditWorker.Text = "Изменить";
            this.btnEditWorker.UseVisualStyleBackColor = true;
            this.btnEditWorker.Click += new System.EventHandler(this.btnEditWorker_Click);
            // 
            // btnAddWorker
            // 
            this.btnAddWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddWorker.Location = new System.Drawing.Point(539, 516);
            this.btnAddWorker.Name = "btnAddWorker";
            this.btnAddWorker.Size = new System.Drawing.Size(75, 23);
            this.btnAddWorker.TabIndex = 1;
            this.btnAddWorker.Text = "Добавить";
            this.btnAddWorker.UseVisualStyleBackColor = true;
            this.btnAddWorker.Click += new System.EventHandler(this.btnAddWorker_Click);
            // 
            // callTab
            // 
            this.callTab.Controls.Add(this.callGrid);
            this.callTab.Controls.Add(this.btnDeleteCall);
            this.callTab.Controls.Add(this.btnEditCall);
            this.callTab.Controls.Add(this.btnAddCall);
            this.callTab.Location = new System.Drawing.Point(4, 22);
            this.callTab.Name = "callTab";
            this.callTab.Padding = new System.Windows.Forms.Padding(3);
            this.callTab.Size = new System.Drawing.Size(783, 547);
            this.callTab.TabIndex = 0;
            this.callTab.Text = "Звонки";
            this.callTab.UseVisualStyleBackColor = true;
            // 
            // callGrid
            // 
            this.callGrid.AllowUserToAddRows = false;
            this.callGrid.AllowUserToDeleteRows = false;
            this.callGrid.AllowUserToOrderColumns = true;
            this.callGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.callGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.callGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.callGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.callGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.callGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.callGrid.Location = new System.Drawing.Point(8, 6);
            this.callGrid.Name = "callGrid";
            this.callGrid.ReadOnly = true;
            this.callGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.callGrid.Size = new System.Drawing.Size(768, 504);
            this.callGrid.TabIndex = 0;
            // 
            // btnDeleteCall
            // 
            this.btnDeleteCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCall.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteCall.Name = "btnDeleteCall";
            this.btnDeleteCall.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCall.TabIndex = 3;
            this.btnDeleteCall.Text = "Удалить";
            this.btnDeleteCall.UseVisualStyleBackColor = true;
            this.btnDeleteCall.Click += new System.EventHandler(this.btnDeleteCall_Click);
            // 
            // btnEditCall
            // 
            this.btnEditCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCall.Location = new System.Drawing.Point(620, 516);
            this.btnEditCall.Name = "btnEditCall";
            this.btnEditCall.Size = new System.Drawing.Size(75, 23);
            this.btnEditCall.TabIndex = 2;
            this.btnEditCall.Text = "Изменить";
            this.btnEditCall.UseVisualStyleBackColor = true;
            this.btnEditCall.Click += new System.EventHandler(this.btnEditCall_Click);
            // 
            // btnAddCall
            // 
            this.btnAddCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCall.Location = new System.Drawing.Point(539, 516);
            this.btnAddCall.Name = "btnAddCall";
            this.btnAddCall.Size = new System.Drawing.Size(75, 23);
            this.btnAddCall.TabIndex = 1;
            this.btnAddCall.Text = "Добавить";
            this.btnAddCall.UseVisualStyleBackColor = true;
            this.btnAddCall.Click += new System.EventHandler(this.btnAddCall_Click);
            // 
            // atcCallTab
            // 
            this.atcCallTab.Controls.Add(this.atcCallGrid);
            this.atcCallTab.Controls.Add(this.btnDeleteAtcCall);
            this.atcCallTab.Controls.Add(this.btnEditAtcCall);
            this.atcCallTab.Controls.Add(this.btnAddAtcCall);
            this.atcCallTab.Location = new System.Drawing.Point(4, 22);
            this.atcCallTab.Name = "atcCallTab";
            this.atcCallTab.Padding = new System.Windows.Forms.Padding(3);
            this.atcCallTab.Size = new System.Drawing.Size(783, 547);
            this.atcCallTab.TabIndex = 0;
            this.atcCallTab.Text = "Атс Звонки";
            this.atcCallTab.UseVisualStyleBackColor = true;
            // 
            // atcCallGrid
            // 
            this.atcCallGrid.AllowUserToAddRows = false;
            this.atcCallGrid.AllowUserToDeleteRows = false;
            this.atcCallGrid.AllowUserToOrderColumns = true;
            this.atcCallGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.atcCallGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.atcCallGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.atcCallGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.atcCallGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.atcCallGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.atcCallGrid.Location = new System.Drawing.Point(8, 6);
            this.atcCallGrid.Name = "atcCallGrid";
            this.atcCallGrid.ReadOnly = true;
            this.atcCallGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.atcCallGrid.Size = new System.Drawing.Size(768, 504);
            this.atcCallGrid.TabIndex = 0;
            // 
            // btnDeleteAtcCall
            // 
            this.btnDeleteAtcCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAtcCall.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteAtcCall.Name = "btnDeleteAtcCall";
            this.btnDeleteAtcCall.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAtcCall.TabIndex = 3;
            this.btnDeleteAtcCall.Text = "Удалить";
            this.btnDeleteAtcCall.UseVisualStyleBackColor = true;
            this.btnDeleteAtcCall.Click += new System.EventHandler(this.btnDeleteAtcCall_Click);
            // 
            // btnEditAtcCall
            // 
            this.btnEditAtcCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAtcCall.Location = new System.Drawing.Point(620, 516);
            this.btnEditAtcCall.Name = "btnEditAtcCall";
            this.btnEditAtcCall.Size = new System.Drawing.Size(75, 23);
            this.btnEditAtcCall.TabIndex = 2;
            this.btnEditAtcCall.Text = "Изменить";
            this.btnEditAtcCall.UseVisualStyleBackColor = true;
            this.btnEditAtcCall.Click += new System.EventHandler(this.btnEditAtcCall_Click);
            // 
            // btnAddAtcCall
            // 
            this.btnAddAtcCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAtcCall.Location = new System.Drawing.Point(539, 516);
            this.btnAddAtcCall.Name = "btnAddAtcCall";
            this.btnAddAtcCall.Size = new System.Drawing.Size(75, 23);
            this.btnAddAtcCall.TabIndex = 1;
            this.btnAddAtcCall.Text = "Добавить";
            this.btnAddAtcCall.UseVisualStyleBackColor = true;
            this.btnAddAtcCall.Click += new System.EventHandler(this.btnAddAtcCall_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(783, 547);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Настройки";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFinEmail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSaveSettings);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtLogin);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 180);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки почты";
            // 
            // txtFinEmail
            // 
            this.txtFinEmail.Location = new System.Drawing.Point(135, 120);
            this.txtFinEmail.Name = "txtFinEmail";
            this.txtFinEmail.Size = new System.Drawing.Size(207, 20);
            this.txtFinEmail.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Email Фин. директора: ";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(205, 146);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(137, 23);
            this.btnSaveSettings.TabIndex = 9;
            this.btnSaveSettings.Text = "Сохранить настройки";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(135, 94);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(207, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(135, 68);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(207, 20);
            this.txtLogin.TabIndex = 7;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(135, 42);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(207, 20);
            this.txtPort.TabIndex = 6;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(135, 16);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(207, 20);
            this.txtHost.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Пароль: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Логин: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Порт: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Smtp сервер: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 573);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Система учёта клиентов";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl.ResumeLayout(false);
            this.subdivisionTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.subdivisionGrid)).EndInit();
            this.numberTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outNumberGrid)).EndInit();
            this.workerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workerGrid)).EndInit();
            this.callTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.callGrid)).EndInit();
            this.atcCallTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.atcCallGrid)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage atcCallTab;
        private System.Windows.Forms.DataGridView atcCallGrid;
        private System.Windows.Forms.Button btnDeleteAtcCall;
        private System.Windows.Forms.Button btnEditAtcCall;
        private System.Windows.Forms.Button btnAddAtcCall;
        
        private System.Windows.Forms.TabPage numberTab;
        private System.Windows.Forms.DataGridView outNumberGrid;
        private System.Windows.Forms.Button btnDeleteOutNumber;
        private System.Windows.Forms.Button btnEditOutNumber;
        private System.Windows.Forms.Button btnAddOutNumber;
        
        private System.Windows.Forms.TabPage subdivisionTab;
        private System.Windows.Forms.DataGridView subdivisionGrid;
        private System.Windows.Forms.Button btnDeleteSubdivision;
        private System.Windows.Forms.Button btnEditSubdivision;
        private System.Windows.Forms.Button btnAddSubdivision;
        
        private System.Windows.Forms.TabPage workerTab;
        private System.Windows.Forms.DataGridView workerGrid;
        private System.Windows.Forms.Button btnDeleteWorker;
        private System.Windows.Forms.Button btnEditWorker;
        private System.Windows.Forms.Button btnAddWorker;
        
        private System.Windows.Forms.TabPage callTab;
        private System.Windows.Forms.DataGridView callGrid;
        private System.Windows.Forms.Button btnDeleteCall;
        private System.Windows.Forms.Button btnEditCall;
        private System.Windows.Forms.Button btnAddCall;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFinEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        

    }
}

