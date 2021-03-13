
namespace ManageDb
{
    partial class frmManageDb
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label officeAppLabel;
            System.Windows.Forms.Label officeVersionLabel;
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label groupLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label contentLabel;
            System.Windows.Forms.Label helpLabel;
            System.Windows.Forms.Label limitTimeLabel;
            System.Windows.Forms.Label indexLabel;
            this.btnInitDb = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridTests = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResources = new System.Windows.Forms.TextBox();
            this.officeVersionComboBox = new System.Windows.Forms.ComboBox();
            this.officeAppComboBox = new System.Windows.Forms.ComboBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.iDTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridQues = new System.Windows.Forms.DataGridView();
            this.questionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.htmlPanel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.btnQDel = new System.Windows.Forms.Button();
            this.btnQSave = new System.Windows.Forms.Button();
            this.btnQAdd = new System.Windows.Forms.Button();
            this.helpTextBox = new System.Windows.Forms.TextBox();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.limitTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.indexNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.testBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.indexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.helpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            iDLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            officeAppLabel = new System.Windows.Forms.Label();
            officeVersionLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            groupLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            contentLabel = new System.Windows.Forms.Label();
            helpLabel = new System.Windows.Forms.Label();
            limitTimeLabel = new System.Windows.Forms.Label();
            indexLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTests)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridQues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limitTimeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indexNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(18, 15);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(21, 13);
            iDLabel.TabIndex = 0;
            iDLabel.Text = "ID:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(18, 40);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Name:";
            // 
            // officeAppLabel
            // 
            officeAppLabel.AutoSize = true;
            officeAppLabel.Location = new System.Drawing.Point(18, 65);
            officeAppLabel.Name = "officeAppLabel";
            officeAppLabel.Size = new System.Drawing.Size(60, 13);
            officeAppLabel.TabIndex = 4;
            officeAppLabel.Text = "Office App:";
            // 
            // officeVersionLabel
            // 
            officeVersionLabel.AutoSize = true;
            officeVersionLabel.Location = new System.Drawing.Point(18, 91);
            officeVersionLabel.Name = "officeVersionLabel";
            officeVersionLabel.Size = new System.Drawing.Size(76, 13);
            officeVersionLabel.TabIndex = 6;
            officeVersionLabel.Text = "Office Version:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(18, 40);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(30, 13);
            titleLabel.TabIndex = 4;
            titleLabel.Text = "Title:";
            // 
            // groupLabel
            // 
            groupLabel.AutoSize = true;
            groupLabel.Location = new System.Drawing.Point(18, 66);
            groupLabel.Name = "groupLabel";
            groupLabel.Size = new System.Drawing.Size(39, 13);
            groupLabel.TabIndex = 6;
            groupLabel.Text = "Group:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(262, 86);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 13;
            descriptionLabel.Text = "Description:";
            // 
            // contentLabel
            // 
            contentLabel.AutoSize = true;
            contentLabel.Location = new System.Drawing.Point(347, 6);
            contentLabel.Name = "contentLabel";
            contentLabel.Size = new System.Drawing.Size(47, 13);
            contentLabel.TabIndex = 8;
            contentLabel.Text = "Content:";
            // 
            // helpLabel
            // 
            helpLabel.AutoSize = true;
            helpLabel.Location = new System.Drawing.Point(18, 92);
            helpLabel.Name = "helpLabel";
            helpLabel.Size = new System.Drawing.Size(32, 13);
            helpLabel.TabIndex = 10;
            helpLabel.Text = "Help:";
            // 
            // btnInitDb
            // 
            this.btnInitDb.Location = new System.Drawing.Point(12, 12);
            this.btnInitDb.Name = "btnInitDb";
            this.btnInitDb.Size = new System.Drawing.Size(143, 23);
            this.btnInitDb.TabIndex = 0;
            this.btnInitDb.Text = "Khôi phục gốc Db";
            this.btnInitDb.UseVisualStyleBackColor = true;
            this.btnInitDb.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 90);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(818, 488);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(810, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tests";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridTests, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.9418F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.0582F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 456);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridTests
            // 
            this.dataGridTests.AllowUserToAddRows = false;
            this.dataGridTests.AllowUserToDeleteRows = false;
            this.dataGridTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridTests.Location = new System.Drawing.Point(3, 226);
            this.dataGridTests.MultiSelect = false;
            this.dataGridTests.Name = "dataGridTests";
            this.dataGridTests.ReadOnly = true;
            this.dataGridTests.Size = new System.Drawing.Size(798, 227);
            this.dataGridTests.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(limitTimeLabel);
            this.panel1.Controls.Add(this.limitTimeNumericUpDown);
            this.panel1.Controls.Add(descriptionLabel);
            this.panel1.Controls.Add(this.descriptionTextBox);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtResources);
            this.panel1.Controls.Add(officeVersionLabel);
            this.panel1.Controls.Add(this.officeVersionComboBox);
            this.panel1.Controls.Add(officeAppLabel);
            this.panel1.Controls.Add(this.officeAppComboBox);
            this.panel1.Controls.Add(nameLabel);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(iDLabel);
            this.panel1.Controls.Add(this.iDTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 217);
            this.panel1.TabIndex = 1;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.testBindingSource, "Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(331, 83);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.descriptionTextBox.Size = new System.Drawing.Size(249, 65);
            this.descriptionTextBox.TabIndex = 14;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 153);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(179, 153);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 11;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(98, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Resources:";
            // 
            // txtResources
            // 
            this.txtResources.Location = new System.Drawing.Point(331, 12);
            this.txtResources.Multiline = true;
            this.txtResources.Name = "txtResources";
            this.txtResources.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResources.Size = new System.Drawing.Size(249, 65);
            this.txtResources.TabIndex = 8;
            this.txtResources.Leave += new System.EventHandler(this.txtResources_Leave);
            // 
            // officeVersionComboBox
            // 
            this.officeVersionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.testBindingSource, "OfficeVersion", true));
            this.officeVersionComboBox.FormattingEnabled = true;
            this.officeVersionComboBox.Items.AddRange(new object[] {
            "Office 2013",
            "Office 2016"});
            this.officeVersionComboBox.Location = new System.Drawing.Point(100, 88);
            this.officeVersionComboBox.Name = "officeVersionComboBox";
            this.officeVersionComboBox.Size = new System.Drawing.Size(128, 21);
            this.officeVersionComboBox.TabIndex = 7;
            // 
            // officeAppComboBox
            // 
            this.officeAppComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.testBindingSource, "OfficeApp", true));
            this.officeAppComboBox.FormattingEnabled = true;
            this.officeAppComboBox.Items.AddRange(new object[] {
            "Word",
            "Excel",
            "PowerPoint"});
            this.officeAppComboBox.Location = new System.Drawing.Point(84, 62);
            this.officeAppComboBox.Name = "officeAppComboBox";
            this.officeAppComboBox.Size = new System.Drawing.Size(144, 21);
            this.officeAppComboBox.TabIndex = 5;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.testBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(62, 37);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(166, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // iDTextBox
            // 
            this.iDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.testBindingSource, "ID", true));
            this.iDTextBox.Location = new System.Drawing.Point(45, 12);
            this.iDTextBox.Name = "iDTextBox";
            this.iDTextBox.ReadOnly = true;
            this.iDTextBox.Size = new System.Drawing.Size(183, 20);
            this.iDTextBox.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(810, 462);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Questions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridQues, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 325F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(804, 456);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridQues
            // 
            this.dataGridQues.AllowUserToAddRows = false;
            this.dataGridQues.AllowUserToDeleteRows = false;
            this.dataGridQues.AutoGenerateColumns = false;
            this.dataGridQues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridQues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indexDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.contentDataGridViewTextBoxColumn,
            this.helpDataGridViewTextBoxColumn,
            this.groupDataGridViewTextBoxColumn});
            this.dataGridQues.DataSource = this.questionsBindingSource;
            this.dataGridQues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridQues.Location = new System.Drawing.Point(3, 328);
            this.dataGridQues.MultiSelect = false;
            this.dataGridQues.Name = "dataGridQues";
            this.dataGridQues.ReadOnly = true;
            this.dataGridQues.Size = new System.Drawing.Size(798, 125);
            this.dataGridQues.TabIndex = 0;
            // 
            // questionsBindingSource
            // 
            this.questionsBindingSource.DataMember = "Questions";
            this.questionsBindingSource.DataSource = this.testBindingSource;
            this.questionsBindingSource.CurrentItemChanged += new System.EventHandler(this.questionsBindingSource_CurrentItemChanged);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(indexLabel);
            this.panel2.Controls.Add(this.indexNumericUpDown);
            this.panel2.Controls.Add(this.contentTextBox);
            this.panel2.Controls.Add(this.htmlPanel);
            this.panel2.Controls.Add(this.btnQDel);
            this.panel2.Controls.Add(this.btnQSave);
            this.panel2.Controls.Add(this.btnQAdd);
            this.panel2.Controls.Add(helpLabel);
            this.panel2.Controls.Add(this.helpTextBox);
            this.panel2.Controls.Add(contentLabel);
            this.panel2.Controls.Add(groupLabel);
            this.panel2.Controls.Add(this.groupTextBox);
            this.panel2.Controls.Add(titleLabel);
            this.panel2.Controls.Add(this.titleTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 319);
            this.panel2.TabIndex = 1;
            // 
            // contentTextBox
            // 
            this.contentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.questionsBindingSource, "Content", true));
            this.contentTextBox.Location = new System.Drawing.Point(409, 6);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.contentTextBox.Size = new System.Drawing.Size(366, 116);
            this.contentTextBox.TabIndex = 9;
            this.contentTextBox.Leave += new System.EventHandler(this.contentTextBox_Leave);
            // 
            // htmlPanel
            // 
            this.htmlPanel.AutoScroll = true;
            this.htmlPanel.AutoScrollMinSize = new System.Drawing.Size(364, 20);
            this.htmlPanel.BackColor = System.Drawing.SystemColors.Window;
            this.htmlPanel.BaseStylesheet = null;
            this.htmlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.htmlPanel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.htmlPanel.Location = new System.Drawing.Point(409, 128);
            this.htmlPanel.Name = "htmlPanel";
            this.htmlPanel.Size = new System.Drawing.Size(366, 151);
            this.htmlPanel.TabIndex = 17;
            this.htmlPanel.Text = "Preview";
            // 
            // btnQDel
            // 
            this.btnQDel.Location = new System.Drawing.Point(183, 293);
            this.btnQDel.Name = "btnQDel";
            this.btnQDel.Size = new System.Drawing.Size(75, 23);
            this.btnQDel.TabIndex = 16;
            this.btnQDel.Text = "Xóa";
            this.btnQDel.UseVisualStyleBackColor = true;
            this.btnQDel.Click += new System.EventHandler(this.btnQDel_Click);
            // 
            // btnQSave
            // 
            this.btnQSave.Location = new System.Drawing.Point(102, 293);
            this.btnQSave.Name = "btnQSave";
            this.btnQSave.Size = new System.Drawing.Size(75, 23);
            this.btnQSave.TabIndex = 15;
            this.btnQSave.Text = "Lưu";
            this.btnQSave.UseVisualStyleBackColor = true;
            this.btnQSave.Click += new System.EventHandler(this.btnQSave_Click);
            // 
            // btnQAdd
            // 
            this.btnQAdd.Location = new System.Drawing.Point(21, 293);
            this.btnQAdd.Name = "btnQAdd";
            this.btnQAdd.Size = new System.Drawing.Size(75, 23);
            this.btnQAdd.TabIndex = 14;
            this.btnQAdd.Text = "Thêm";
            this.btnQAdd.UseVisualStyleBackColor = true;
            this.btnQAdd.Click += new System.EventHandler(this.btnQAdd_Click);
            // 
            // helpTextBox
            // 
            this.helpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.questionsBindingSource, "Help", true));
            this.helpTextBox.Location = new System.Drawing.Point(60, 89);
            this.helpTextBox.Multiline = true;
            this.helpTextBox.Name = "helpTextBox";
            this.helpTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.helpTextBox.Size = new System.Drawing.Size(255, 118);
            this.helpTextBox.TabIndex = 11;
            // 
            // groupTextBox
            // 
            this.groupTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.questionsBindingSource, "Group", true));
            this.groupTextBox.Location = new System.Drawing.Point(60, 63);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(174, 20);
            this.groupTextBox.TabIndex = 7;
            // 
            // titleTextBox
            // 
            this.titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.questionsBindingSource, "Title", true));
            this.titleTextBox.Location = new System.Drawing.Point(60, 37);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(174, 20);
            this.titleTextBox.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(824, 581);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnInitDb);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(818, 81);
            this.panel4.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Làm mới Db";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bấm Lưu để thay đổi thông tin";
            // 
            // limitTimeLabel
            // 
            limitTimeLabel.AutoSize = true;
            limitTimeLabel.Location = new System.Drawing.Point(18, 116);
            limitTimeLabel.Name = "limitTimeLabel";
            limitTimeLabel.Size = new System.Drawing.Size(87, 13);
            limitTimeLabel.TabIndex = 15;
            limitTimeLabel.Text = "Limit Time (mins):";
            // 
            // limitTimeNumericUpDown
            // 
            this.limitTimeNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.testBindingSource, "LimitTime", true));
            this.limitTimeNumericUpDown.Location = new System.Drawing.Point(111, 114);
            this.limitTimeNumericUpDown.Name = "limitTimeNumericUpDown";
            this.limitTimeNumericUpDown.Size = new System.Drawing.Size(117, 20);
            this.limitTimeNumericUpDown.TabIndex = 16;
            // 
            // indexLabel
            // 
            indexLabel.AutoSize = true;
            indexLabel.Location = new System.Drawing.Point(18, 11);
            indexLabel.Name = "indexLabel";
            indexLabel.Size = new System.Drawing.Size(36, 13);
            indexLabel.TabIndex = 17;
            indexLabel.Text = "Index:";
            // 
            // indexNumericUpDown
            // 
            this.indexNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.questionsBindingSource, "Index", true));
            this.indexNumericUpDown.Location = new System.Drawing.Point(60, 11);
            this.indexNumericUpDown.Name = "indexNumericUpDown";
            this.indexNumericUpDown.Size = new System.Drawing.Size(174, 20);
            this.indexNumericUpDown.TabIndex = 18;
            // 
            // testBindingSource
            // 
            this.testBindingSource.DataSource = typeof(Models.Test);
            this.testBindingSource.CurrentChanged += new System.EventHandler(this.testBindingSource_CurrentChanged);
            // 
            // indexDataGridViewTextBoxColumn
            // 
            this.indexDataGridViewTextBoxColumn.DataPropertyName = "Index";
            this.indexDataGridViewTextBoxColumn.HeaderText = "Index";
            this.indexDataGridViewTextBoxColumn.Name = "indexDataGridViewTextBoxColumn";
            this.indexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contentDataGridViewTextBoxColumn
            // 
            this.contentDataGridViewTextBoxColumn.DataPropertyName = "Content";
            this.contentDataGridViewTextBoxColumn.HeaderText = "Content";
            this.contentDataGridViewTextBoxColumn.Name = "contentDataGridViewTextBoxColumn";
            this.contentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // helpDataGridViewTextBoxColumn
            // 
            this.helpDataGridViewTextBoxColumn.DataPropertyName = "Help";
            this.helpDataGridViewTextBoxColumn.HeaderText = "Help";
            this.helpDataGridViewTextBoxColumn.Name = "helpDataGridViewTextBoxColumn";
            this.helpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "Group";
            this.groupDataGridViewTextBoxColumn.HeaderText = "Group";
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            this.groupDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmManageDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 581);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "frmManageDb";
            this.Text = "ManageDb";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTests)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridQues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limitTimeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indexNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitDb;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridTests;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource testBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox officeVersionComboBox;
        private System.Windows.Forms.ComboBox officeAppComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox iDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResources;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridQues;
        private System.Windows.Forms.BindingSource questionsBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn helpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox helpTextBox;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.Button btnQDel;
        private System.Windows.Forms.Button btnQSave;
        private System.Windows.Forms.Button btnQAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel4;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown limitTimeNumericUpDown;
        private System.Windows.Forms.NumericUpDown indexNumericUpDown;
    }
}

