
namespace GUI
{
    partial class frmRunTestOffice2016
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRunTestOffice2016));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSelectedProject = new System.Windows.Forms.Label();
            this.ucTimer = new GUI.ucTimer();
            this.labelTestName = new System.Windows.Forms.Label();
            this.btnResize = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGrade = new System.Windows.Forms.Button();
            this.tablePanelQuestions = new System.Windows.Forms.TableLayoutPanel();
            this.htmlPanelQuestionContent = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnMarkCompleted = new System.Windows.Forms.Button();
            this.panelQuestionTitle = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tablePanelQuestions.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tablePanelQuestions, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(991, 305);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSelectedProject);
            this.panel1.Controls.Add(this.ucTimer);
            this.panel1.Controls.Add(this.labelTestName);
            this.panel1.Controls.Add(this.btnResize);
            this.panel1.Controls.Add(this.btnSummary);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnGrade);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 34);
            this.panel1.TabIndex = 2;
            // 
            // lblSelectedProject
            // 
            this.lblSelectedProject.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSelectedProject.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedProject.Location = new System.Drawing.Point(309, 0);
            this.lblSelectedProject.Name = "lblSelectedProject";
            this.lblSelectedProject.Size = new System.Drawing.Size(186, 34);
            this.lblSelectedProject.TabIndex = 2;
            this.lblSelectedProject.Text = "Project 1 of 7";
            // 
            // ucTimer
            // 
            this.ucTimer.Current = 0;
            this.ucTimer.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucTimer.Location = new System.Drawing.Point(200, 0);
            this.ucTimer.Max = -1;
            this.ucTimer.Name = "ucTimer";
            this.ucTimer.Size = new System.Drawing.Size(109, 34);
            this.ucTimer.TabIndex = 8;
            // 
            // labelTestName
            // 
            this.labelTestName.AutoSize = true;
            this.labelTestName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTestName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestName.Location = new System.Drawing.Point(0, 0);
            this.labelTestName.Name = "labelTestName";
            this.labelTestName.Size = new System.Drawing.Size(200, 25);
            this.labelTestName.TabIndex = 3;
            this.labelTestName.Text = "Test 1 - Testing Mode";
            // 
            // btnResize
            // 
            this.btnResize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnResize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResize.Location = new System.Drawing.Point(477, 0);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(111, 34);
            this.btnResize.TabIndex = 7;
            this.btnResize.Text = "Resize Window";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSummary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummary.Location = new System.Drawing.Point(588, 0);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(90, 34);
            this.btnSummary.TabIndex = 5;
            this.btnSummary.Text = "Summary";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(678, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 34);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset Project";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(786, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 34);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Project";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGrade
            // 
            this.btnGrade.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGrade.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrade.Location = new System.Drawing.Point(882, 0);
            this.btnGrade.Name = "btnGrade";
            this.btnGrade.Size = new System.Drawing.Size(103, 34);
            this.btnGrade.TabIndex = 1;
            this.btnGrade.Text = "Grade Project";
            this.btnGrade.UseVisualStyleBackColor = true;
            this.btnGrade.Click += new System.EventHandler(this.btnGrade_Click);
            // 
            // tablePanelQuestions
            // 
            this.tablePanelQuestions.ColumnCount = 1;
            this.tablePanelQuestions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanelQuestions.Controls.Add(this.htmlPanelQuestionContent, 0, 1);
            this.tablePanelQuestions.Controls.Add(this.panel2, 0, 2);
            this.tablePanelQuestions.Controls.Add(this.panelQuestionTitle, 0, 0);
            this.tablePanelQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelQuestions.Location = new System.Drawing.Point(3, 43);
            this.tablePanelQuestions.Name = "tablePanelQuestions";
            this.tablePanelQuestions.RowCount = 3;
            this.tablePanelQuestions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tablePanelQuestions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelQuestions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tablePanelQuestions.Size = new System.Drawing.Size(985, 259);
            this.tablePanelQuestions.TabIndex = 4;
            // 
            // htmlPanelQuestionContent
            // 
            this.htmlPanelQuestionContent.AutoScroll = true;
            this.htmlPanelQuestionContent.AutoScrollMinSize = new System.Drawing.Size(979, 20);
            this.htmlPanelQuestionContent.BackColor = System.Drawing.SystemColors.Window;
            this.htmlPanelQuestionContent.BaseStylesheet = "";
            this.htmlPanelQuestionContent.Cursor = System.Windows.Forms.Cursors.Default;
            this.htmlPanelQuestionContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlPanelQuestionContent.IsSelectionEnabled = false;
            this.htmlPanelQuestionContent.Location = new System.Drawing.Point(3, 33);
            this.htmlPanelQuestionContent.Name = "htmlPanelQuestionContent";
            this.htmlPanelQuestionContent.Size = new System.Drawing.Size(979, 193);
            this.htmlPanelQuestionContent.TabIndex = 0;
            this.htmlPanelQuestionContent.Text = "htmlPanel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnHelp);
            this.panel2.Controls.Add(this.btnMarkCompleted);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 232);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 24);
            this.panel2.TabIndex = 1;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.Control;
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHelp.Location = new System.Drawing.Point(124, 0);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 24);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnMarkCompleted
            // 
            this.btnMarkCompleted.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMarkCompleted.Location = new System.Drawing.Point(0, 0);
            this.btnMarkCompleted.Name = "btnMarkCompleted";
            this.btnMarkCompleted.Size = new System.Drawing.Size(124, 24);
            this.btnMarkCompleted.TabIndex = 0;
            this.btnMarkCompleted.Text = "Mark Completed";
            this.btnMarkCompleted.UseVisualStyleBackColor = true;
            this.btnMarkCompleted.Click += new System.EventHandler(this.btnMarkCompleted_Click);
            // 
            // panelQuestionTitle
            // 
            this.panelQuestionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuestionTitle.Location = new System.Drawing.Point(3, 3);
            this.panelQuestionTitle.Name = "panelQuestionTitle";
            this.panelQuestionTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelQuestionTitle.Size = new System.Drawing.Size(979, 24);
            this.panelQuestionTitle.TabIndex = 2;
            // 
            // frmRunTestOffice2016
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 305);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRunTestOffice2016";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Run Test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRunTestOffice2016_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tablePanelQuestions.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSelectedProject;
        private System.Windows.Forms.Button btnGrade;
        private System.Windows.Forms.Label labelTestName;
        private ucTimer ucTimer;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.TableLayoutPanel tablePanelQuestions;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlPanelQuestionContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMarkCompleted;
        private System.Windows.Forms.Panel panelQuestionTitle;
        private System.Windows.Forms.Button btnHelp;
    }
}