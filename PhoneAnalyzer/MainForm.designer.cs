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
            this.providerTab = new System.Windows.Forms.TabPage();
            this.providerGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteProvider = new System.Windows.Forms.Button();
            this.btnEditProvider = new System.Windows.Forms.Button();
            this.btnAddProvider = new System.Windows.Forms.Button();
            this.outNumberTab = new System.Windows.Forms.TabPage();
            this.outNumberGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteOutNumber = new System.Windows.Forms.Button();
            this.btnEditOutNumber = new System.Windows.Forms.Button();
            this.btnAddOutNumber = new System.Windows.Forms.Button();
            this.inNumberTab = new System.Windows.Forms.TabPage();
            this.inNumberGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteInNumber = new System.Windows.Forms.Button();
            this.btnEditInNumber = new System.Windows.Forms.Button();
            this.btnAddInNumber = new System.Windows.Forms.Button();
            this.subdivisionTab = new System.Windows.Forms.TabPage();
            this.subdivisionGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteSubdivision = new System.Windows.Forms.Button();
            this.btnEditSubdivision = new System.Windows.Forms.Button();
            this.btnAddSubdivision = new System.Windows.Forms.Button();
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
            this.tabControl.SuspendLayout();
            this.providerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.providerGrid)).BeginInit();
            this.outNumberTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outNumberGrid)).BeginInit();
            this.inNumberTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inNumberGrid)).BeginInit();
            this.subdivisionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subdivisionGrid)).BeginInit();
            this.workerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workerGrid)).BeginInit();
            this.callTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.providerTab);
            this.tabControl.Controls.Add(this.subdivisionTab);
            this.tabControl.Controls.Add(this.outNumberTab);
            this.tabControl.Controls.Add(this.inNumberTab);
            this.tabControl.Controls.Add(this.workerTab);
            this.tabControl.Controls.Add(this.callTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(791, 573);
            this.tabControl.TabIndex = 0;
            // 
            // providerTab
            // 
            this.providerTab.Controls.Add(this.providerGrid);
            this.providerTab.Controls.Add(this.btnDeleteProvider);
            this.providerTab.Controls.Add(this.btnEditProvider);
            this.providerTab.Controls.Add(this.btnAddProvider);
            this.providerTab.Location = new System.Drawing.Point(4, 22);
            this.providerTab.Name = "providerTab";
            this.providerTab.Padding = new System.Windows.Forms.Padding(3);
            this.providerTab.Size = new System.Drawing.Size(783, 547);
            this.providerTab.TabIndex = 0;
            this.providerTab.Text = "Провайдеры";
            this.providerTab.UseVisualStyleBackColor = true;
            // 
            // providerGrid
            // 
            this.providerGrid.AllowUserToAddRows = false;
            this.providerGrid.AllowUserToDeleteRows = false;
            this.providerGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.providerGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.providerGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.providerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.providerGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.providerGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.providerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.providerGrid.Location = new System.Drawing.Point(8, 6);
            this.providerGrid.Name = "providerGrid";
            this.providerGrid.ReadOnly = true;
            this.providerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.providerGrid.Size = new System.Drawing.Size(768, 504);
            this.providerGrid.TabIndex = 0;
            // 
            // btnDeleteProvider
            // 
            this.btnDeleteProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteProvider.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteProvider.Name = "btnDeleteProvider";
            this.btnDeleteProvider.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteProvider.TabIndex = 3;
            this.btnDeleteProvider.Text = "Удалить";
            this.btnDeleteProvider.UseVisualStyleBackColor = true;
            this.btnDeleteProvider.Click += new System.EventHandler(this.btnDeleteProvider_Click);
            // 
            // btnEditProvider
            // 
            this.btnEditProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditProvider.Location = new System.Drawing.Point(620, 516);
            this.btnEditProvider.Name = "btnEditProvider";
            this.btnEditProvider.Size = new System.Drawing.Size(75, 23);
            this.btnEditProvider.TabIndex = 2;
            this.btnEditProvider.Text = "Изменить";
            this.btnEditProvider.UseVisualStyleBackColor = true;
            this.btnEditProvider.Click += new System.EventHandler(this.btnEditProvider_Click);
            // 
            // btnAddProvider
            // 
            this.btnAddProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProvider.Location = new System.Drawing.Point(539, 516);
            this.btnAddProvider.Name = "btnAddProvider";
            this.btnAddProvider.Size = new System.Drawing.Size(75, 23);
            this.btnAddProvider.TabIndex = 1;
            this.btnAddProvider.Text = "Добавить";
            this.btnAddProvider.UseVisualStyleBackColor = true;
            this.btnAddProvider.Click += new System.EventHandler(this.btnAddProvider_Click);
            // 
            // outNumberTab
            // 
            this.outNumberTab.Controls.Add(this.outNumberGrid);
            this.outNumberTab.Controls.Add(this.btnDeleteOutNumber);
            this.outNumberTab.Controls.Add(this.btnEditOutNumber);
            this.outNumberTab.Controls.Add(this.btnAddOutNumber);
            this.outNumberTab.Location = new System.Drawing.Point(4, 22);
            this.outNumberTab.Name = "outNumberTab";
            this.outNumberTab.Padding = new System.Windows.Forms.Padding(3);
            this.outNumberTab.Size = new System.Drawing.Size(783, 547);
            this.outNumberTab.TabIndex = 0;
            this.outNumberTab.Text = "Внешние номера";
            this.outNumberTab.UseVisualStyleBackColor = true;
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
            // inNumberTab
            // 
            this.inNumberTab.Controls.Add(this.inNumberGrid);
            this.inNumberTab.Controls.Add(this.btnDeleteInNumber);
            this.inNumberTab.Controls.Add(this.btnEditInNumber);
            this.inNumberTab.Controls.Add(this.btnAddInNumber);
            this.inNumberTab.Location = new System.Drawing.Point(4, 22);
            this.inNumberTab.Name = "inNumberTab";
            this.inNumberTab.Padding = new System.Windows.Forms.Padding(3);
            this.inNumberTab.Size = new System.Drawing.Size(783, 547);
            this.inNumberTab.TabIndex = 0;
            this.inNumberTab.Text = "Внутренние номера";
            this.inNumberTab.UseVisualStyleBackColor = true;
            // 
            // inNumberGrid
            // 
            this.inNumberGrid.AllowUserToAddRows = false;
            this.inNumberGrid.AllowUserToDeleteRows = false;
            this.inNumberGrid.AllowUserToOrderColumns = true;
            this.inNumberGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.inNumberGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inNumberGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.inNumberGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.inNumberGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.inNumberGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inNumberGrid.Location = new System.Drawing.Point(8, 6);
            this.inNumberGrid.Name = "inNumberGrid";
            this.inNumberGrid.ReadOnly = true;
            this.inNumberGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inNumberGrid.Size = new System.Drawing.Size(768, 504);
            this.inNumberGrid.TabIndex = 0;
            // 
            // btnDeleteInNumber
            // 
            this.btnDeleteInNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteInNumber.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteInNumber.Name = "btnDeleteInNumber";
            this.btnDeleteInNumber.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteInNumber.TabIndex = 3;
            this.btnDeleteInNumber.Text = "Удалить";
            this.btnDeleteInNumber.UseVisualStyleBackColor = true;
            this.btnDeleteInNumber.Click += new System.EventHandler(this.btnDeleteInNumber_Click);
            // 
            // btnEditInNumber
            // 
            this.btnEditInNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditInNumber.Location = new System.Drawing.Point(620, 516);
            this.btnEditInNumber.Name = "btnEditInNumber";
            this.btnEditInNumber.Size = new System.Drawing.Size(75, 23);
            this.btnEditInNumber.TabIndex = 2;
            this.btnEditInNumber.Text = "Изменить";
            this.btnEditInNumber.UseVisualStyleBackColor = true;
            this.btnEditInNumber.Click += new System.EventHandler(this.btnEditInNumber_Click);
            // 
            // btnAddInNumber
            // 
            this.btnAddInNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddInNumber.Location = new System.Drawing.Point(539, 516);
            this.btnAddInNumber.Name = "btnAddInNumber";
            this.btnAddInNumber.Size = new System.Drawing.Size(75, 23);
            this.btnAddInNumber.TabIndex = 1;
            this.btnAddInNumber.Text = "Добавить";
            this.btnAddInNumber.UseVisualStyleBackColor = true;
            this.btnAddInNumber.Click += new System.EventHandler(this.btnAddInNumber_Click);
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
            this.providerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.providerGrid)).EndInit();
            this.outNumberTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outNumberGrid)).EndInit();
            this.inNumberTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inNumberGrid)).EndInit();
            this.subdivisionTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.subdivisionGrid)).EndInit();
            this.workerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workerGrid)).EndInit();
            this.callTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.callGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage providerTab;
        private System.Windows.Forms.DataGridView providerGrid;
        private System.Windows.Forms.Button btnDeleteProvider;
        private System.Windows.Forms.Button btnEditProvider;
        private System.Windows.Forms.Button btnAddProvider;
        
        private System.Windows.Forms.TabPage outNumberTab;
        private System.Windows.Forms.DataGridView outNumberGrid;
        private System.Windows.Forms.Button btnDeleteOutNumber;
        private System.Windows.Forms.Button btnEditOutNumber;
        private System.Windows.Forms.Button btnAddOutNumber;
        
        private System.Windows.Forms.TabPage inNumberTab;
        private System.Windows.Forms.DataGridView inNumberGrid;
        private System.Windows.Forms.Button btnDeleteInNumber;
        private System.Windows.Forms.Button btnEditInNumber;
        private System.Windows.Forms.Button btnAddInNumber;
        
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
        

    }
}

