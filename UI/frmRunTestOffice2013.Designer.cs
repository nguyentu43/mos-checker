
namespace GUI
{
    partial class frmRunTestOffice2013
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGrade = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnResetProject = new System.Windows.Forms.Button();
            this.btnResize = new System.Windows.Forms.Button();
            this.labelTestName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInstructions = new System.Windows.Forms.TabPage();
            this.tablePanelInstructions = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageRefImages = new System.Windows.Forms.TabPage();
            this.panelRefImages = new System.Windows.Forms.FlowLayoutPanel();
            this.ucTimer = new GUI.ucTimer();
            this.tablePanelQuestionTitle = new System.Windows.Forms.TableLayoutPanel();
            this.labelHelpInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageInstructions.SuspendLayout();
            this.tabPageRefImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.77778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelTestName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ucTimer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tablePanelQuestionTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelHelpInfo, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(686, 390);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnGrade);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnResetProject);
            this.flowLayoutPanel1.Controls.Add(this.btnResize);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(223, 354);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(460, 33);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnGrade
            // 
            this.btnGrade.AutoSize = true;
            this.btnGrade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGrade.Location = new System.Drawing.Point(372, 3);
            this.btnGrade.Name = "btnGrade";
            this.btnGrade.Size = new System.Drawing.Size(85, 31);
            this.btnGrade.TabIndex = 0;
            this.btnGrade.Text = "Finish";
            this.btnGrade.UseVisualStyleBackColor = true;
            this.btnGrade.Click += new System.EventHandler(this.btnGrade_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(281, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 31);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnResetProject
            // 
            this.btnResetProject.AutoSize = true;
            this.btnResetProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnResetProject.Location = new System.Drawing.Point(156, 3);
            this.btnResetProject.Name = "btnResetProject";
            this.btnResetProject.Size = new System.Drawing.Size(119, 31);
            this.btnResetProject.TabIndex = 2;
            this.btnResetProject.Text = "Reset Project";
            this.btnResetProject.UseVisualStyleBackColor = true;
            this.btnResetProject.Click += new System.EventHandler(this.btnResetProject_Click);
            // 
            // btnResize
            // 
            this.btnResize.AutoSize = true;
            this.btnResize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResize.Location = new System.Drawing.Point(16, 3);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(134, 31);
            this.btnResize.TabIndex = 3;
            this.btnResize.Text = "Reset Window";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // labelTestName
            // 
            this.labelTestName.AutoSize = true;
            this.labelTestName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTestName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTestName.Location = new System.Drawing.Point(3, 351);
            this.labelTestName.Name = "labelTestName";
            this.labelTestName.Size = new System.Drawing.Size(146, 39);
            this.labelTestName.TabIndex = 2;
            this.labelTestName.Text = "Test 1 - Testing Mode";
            this.labelTestName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInstructions);
            this.tabControl1.Controls.Add(this.tabPageRefImages);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(155, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 310);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageInstructions
            // 
            this.tabPageInstructions.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageInstructions.Controls.Add(this.tablePanelInstructions);
            this.tabPageInstructions.Location = new System.Drawing.Point(4, 27);
            this.tabPageInstructions.Name = "tabPageInstructions";
            this.tabPageInstructions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstructions.Size = new System.Drawing.Size(520, 279);
            this.tabPageInstructions.TabIndex = 0;
            this.tabPageInstructions.Text = "Instructions";
            // 
            // tablePanelInstructions
            // 
            this.tablePanelInstructions.AutoScroll = true;
            this.tablePanelInstructions.AutoSize = true;
            this.tablePanelInstructions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablePanelInstructions.ColumnCount = 2;
            this.tablePanelInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelInstructions.Location = new System.Drawing.Point(3, 3);
            this.tablePanelInstructions.Name = "tablePanelInstructions";
            this.tablePanelInstructions.RowCount = 2;
            this.tablePanelInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelInstructions.Size = new System.Drawing.Size(514, 273);
            this.tablePanelInstructions.TabIndex = 0;
            // 
            // tabPageRefImages
            // 
            this.tabPageRefImages.Controls.Add(this.panelRefImages);
            this.tabPageRefImages.Location = new System.Drawing.Point(4, 27);
            this.tabPageRefImages.Name = "tabPageRefImages";
            this.tabPageRefImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRefImages.Size = new System.Drawing.Size(520, 279);
            this.tabPageRefImages.TabIndex = 1;
            this.tabPageRefImages.Text = "Resources";
            this.tabPageRefImages.UseVisualStyleBackColor = true;
            // 
            // panelRefImages
            // 
            this.panelRefImages.AutoScroll = true;
            this.panelRefImages.BackColor = System.Drawing.SystemColors.Control;
            this.panelRefImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRefImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRefImages.Location = new System.Drawing.Point(3, 3);
            this.panelRefImages.Name = "panelRefImages";
            this.panelRefImages.Size = new System.Drawing.Size(514, 273);
            this.panelRefImages.TabIndex = 0;
            // 
            // ucTimer
            // 
            this.ucTimer.Current = 13;
            this.ucTimer.Location = new System.Drawing.Point(3, 3);
            this.ucTimer.Max = -1;
            this.ucTimer.Name = "ucTimer";
            this.ucTimer.Size = new System.Drawing.Size(109, 27);
            this.ucTimer.TabIndex = 7;
            // 
            // tablePanelQuestionTitle
            // 
            this.tablePanelQuestionTitle.AutoScroll = true;
            this.tablePanelQuestionTitle.ColumnCount = 1;
            this.tablePanelQuestionTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelQuestionTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanelQuestionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelQuestionTitle.Location = new System.Drawing.Point(3, 38);
            this.tablePanelQuestionTitle.Name = "tablePanelQuestionTitle";
            this.tablePanelQuestionTitle.RowCount = 2;
            this.tablePanelQuestionTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelQuestionTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelQuestionTitle.Size = new System.Drawing.Size(146, 310);
            this.tablePanelQuestionTitle.TabIndex = 8;
            // 
            // labelHelpInfo
            // 
            this.labelHelpInfo.AutoSize = true;
            this.labelHelpInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelHelpInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelpInfo.Location = new System.Drawing.Point(364, 0);
            this.labelHelpInfo.Name = "labelHelpInfo";
            this.labelHelpInfo.Size = new System.Drawing.Size(319, 35);
            this.labelHelpInfo.TabIndex = 9;
            this.labelHelpInfo.Text = "(?) Double click the task to get some help information";
            // 
            // frmRunTestOffice2013
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmRunTestOffice2013";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Run Test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRunTestOffice2013_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageInstructions.ResumeLayout(false);
            this.tabPageInstructions.PerformLayout();
            this.tabPageRefImages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnGrade;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnResetProject;
        private System.Windows.Forms.Label labelTestName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInstructions;
        private System.Windows.Forms.TabPage tabPageRefImages;
        private System.Windows.Forms.FlowLayoutPanel panelRefImages;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.TableLayoutPanel tablePanelInstructions;
        private ucTimer ucTimer;
        private System.Windows.Forms.TableLayoutPanel tablePanelQuestionTitle;
        private System.Windows.Forms.Label labelHelpInfo;
    }
}