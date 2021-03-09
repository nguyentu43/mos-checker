using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GUI.Models;
using GUI.Enums;
using System.Linq;
using TheArtOfDev.HtmlRenderer.WinForms;
using Word = NetOffice.WordApi;
using NetOffice.OfficeApi.Enums;
using System.IO;
using Checker.Base;

namespace GUI
{
    public partial class frmRunTestOffice2013 : BaseRunTestForm
    {
        public frmRunTestOffice2013(Form parent, Test test, TestMode mode, Task resumeTask = null):base(parent, test, mode)
        {
            InitializeComponent();

            this.labelHelpInfo.Visible = mode == TestMode.Practice;
            this.loadQuestions();

            if (resumeTask != null)
            {
                this.Task = resumeTask;
                this.loadTask();
            }
            else
            {
                this.createTask();
            }

            this.loadApp();
            this.resizeForm();
            this.createDirTemp();

            this.labelTestName.Text = this.Test.Name + " - " + this.Mode.ToString() + " Mode";

            if (mode == TestMode.Testing)
            {
                this.ucTimer.Max = 50 * 60;
                this.ucTimer.EndEvent += this.TimerEnd;
            }
            this.ucTimer.Start();
        }

        private void TimerEnd(object sender, EventArgs e)
        {
            this.btnGrade_Click(null, null);
        }

        private void loadTask()
        {
            this.ucTimer.Current = this.Task.UsedTime;
            for(int i = 1; i<=this.Task.MarkCompletedQuestions.Count; ++i)
            {
                (this.tablePanelInstructions.Controls["cboxQuestion" + i.ToString()] as CheckBox).Checked = this.Task.MarkCompletedQuestions[0][i - 1];
            }
        }

        protected override void createTask(List<List<bool>> dict = null)
        {
            base.createTask();
            this.ucTimer.Current = 0;
        }

        private void frmRunTestOffice2013_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ucTimer.Current = 0;
            this.ucTimer.Stop();
            this.ParentForm.Show();
            (this.ParentForm as frmChooseTest).LoadTasks();
            try
            {
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application application = this.Application as Word.Application;
                    
                            if(application != null)
                            {
                                application.Quit(Word.Enums.WdSaveOptions.wdDoNotSaveChanges);
                                application.Dispose();
                            }
                        break;
                    case "Excel":
                        break;
                    case "PowerPoint":
                        break;
                }
            }
            catch(Exception)
            { }
        }

        private void loadApp()
        {
            switch (this.Test.OfficeApp)
            {
                case "Word":
                    Word.Application application = new Word.Application();
                    application.Documents.Open(this.WorkingFilePaths());
                    application.Visible = true;
                    this.Application = application;
                    resizeOfficeWindow();

                    break;
                case "Excel":
                    break;
                case "PowerPoint":
                    break;
            }
        }

        private void loadQuestions()
        {
            string refImagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.Test.ResourcesPath, "RefImages");
            foreach(string path in Directory.GetFiles(refImagesPath, "*.png"))
            {
                Image image = Image.FromFile(path);
                this.panelRefImages.Controls.Add(new PictureBox()
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.AutoSize
                }) ;
            }

            this.tablePanelInstructions.ColumnStyles.Clear();
            this.tablePanelInstructions.RowStyles.Clear();
            this.tablePanelInstructions.ColumnCount = 2;
            this.tablePanelInstructions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            this.tablePanelInstructions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75));

            this.tablePanelQuestionTitle.RowStyles.Clear();

            string baseStyleSheet = ".titleRow{padding: 5px;background-color:#96cbc7}.posRow{padding: 5px 5px 5px 30px; background-color: gray}.listRow{padding: 5px 5px 5px 50px; background-color: white}";

            int row = 0;
            foreach(IGrouping<string, Question> group in this.Test.Questions.GroupBy(x => x.Group).OrderBy(x => x.Key))
            {
                this.tablePanelQuestionTitle.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                this.tablePanelQuestionTitle.Controls.Add(new Label()
                {
                    Text = group.Key,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
                }, 0, row) ;

                this.tablePanelInstructions.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                Label groupLabel = new Label()
                {
                    Text = group.Key,
                    Dock = DockStyle.Fill,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
                };
                this.tablePanelInstructions.Controls.Add(groupLabel, 0, row);
                this.tablePanelInstructions.SetColumnSpan(groupLabel, 2);
                row++;

                foreach (Question question in group.ToList<Question>().OrderBy(x => x.Index))
                {
                    this.tablePanelQuestionTitle.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    Label label = new Label()
                    {
                        Text = question.Index.ToString() + ". " + question.Title,
                        BorderStyle = BorderStyle.FixedSingle,
                        Dock = DockStyle.Fill,
                        Name = "labelQuestion" + question.Index,
                        Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.GraphicsUnit.Point)
                    };
                    
                    label.Click += new System.EventHandler(this.labelQuestion_Click);
                    this.tablePanelQuestionTitle.Controls.Add(label, 0, row);

                    this.tablePanelInstructions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    CheckBox cbox = new CheckBox()
                    {
                        Text = question.Index.ToString() + ". " + question.Title,
                        Name = "cboxQuestion" + question.Index,
                        Dock = DockStyle.Top,
                        AutoSize = false,
                        Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
                    };
                    cbox.CheckedChanged += new System.EventHandler(this.cboxQuestion_CheckedChanged);

                    HtmlLabel htmlLabel = new HtmlLabel()
                    {
                        Dock = DockStyle.Fill,
                        Text = question.Content,
                        BackColor = Color.Transparent,
                        BaseStylesheet = baseStyleSheet
                    };
                    htmlLabel.DoubleClick += delegate
                    {
                        if (this.Mode == TestMode.Testing) return;
                        MessageBox.Show(question.Help, "Help: Task " + question.Index.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };

                    this.tablePanelInstructions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    this.tablePanelInstructions.Controls.Add(cbox, 0, row);
                    this.tablePanelInstructions.Controls.Add(htmlLabel, 1, row);
                    this.tablePanelInstructions.RowStyles[row] = new RowStyle(SizeType.Absolute, htmlLabel.Height + 20);
                    htmlLabel.AutoSize = false;

                    row++;
                }
            }

            tablePanelInstructions.RowCount = row;
        }
        private void cboxQuestion_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbox = sender as CheckBox;
            this.tablePanelQuestionTitle.Controls[cbox.Name.Replace("cbox", "label")].ForeColor = cbox.Checked ? Color.Blue : Color.Black;
        }

        private void labelQuestion_Click(object sender, EventArgs e)
        {
            this.tablePanelInstructions.AutoScrollPosition = new Point(0, 0);
            Label label = sender as Label;
            int offsetY = this.tablePanelInstructions.Controls[label.Name.Replace("label", "cbox")].Location.Y;
            this.tablePanelInstructions.VerticalScroll.Value = offsetY;
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to exit and submit this test?", "Submit Test", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application application = this.Application as Word.Application;
                        Word.Document document = application.ActiveDocument;
                        document.Save();

                        string className = ("Checker." + this.Test.OfficeApp + "." +    this.Test.Name + "_" + this.Test.OfficeVersion).Replace(" ", "_");
                        BaseTest testChecker = this.createTestChecker(className);

                        testChecker.Document = document;
                        List<bool> points = testChecker.Points;
                        int correctedQuestions = points.FindAll(x => x == true).Count;

                        this.Task.IsCompleted = true;
                        this.Task.UsedTime = this.ucTimer.Current;
                        this.Task.Points.Add(points);
                        double score = Math.Ceiling((double)(correctedQuestions * (1000 / this.Test.Questions.Count)));
                        this.Task.Score = Convert.ToInt32(score);
                        Repository.updateTask(this.Task);

                        application.Quit(Word.Enums.WdSaveOptions.wdDoNotSaveChanges);
                        application.Dispose();

                        MessageBox.Show($"Your Score: {this.Task.Score}\nCorrected Tasks: {correctedQuestions}/{points.Count}", "Your Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();

                        break;
                    case "Excel":
                        break;
                    case "PowerPoint":
                        break;
                }
            }
            catch(Exception)
            { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit and save this test?", "Save Test", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            this.ucTimer.Stop();
            try
            {
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application application = this.Application as Word.Application;
                        application.Quit(Word.Enums.WdSaveOptions.wdSaveChanges);
                        application.Dispose();

                        this.Task.IsCompleted = false;
                        this.Task.UsedTime = this.ucTimer.Current;
                        List<bool> markQuestions = new List<bool>();

                        for (int i = 1; i <= this.Test.Questions.Count; ++i)
                        {
                            if (((this.tablePanelQuestionTitle.Controls["labelQuestion" + i.ToString()]) as Label).ForeColor == Color.Blue)
                            {
                                markQuestions.Add(true);
                            }
                            else
                            {
                                markQuestions.Add(false);
                            }
                        }

                        this.Task.MarkCompletedQuestions.Add(markQuestions);
                        Repository.updateTask(this.Task);
                        this.Close();

                        break;
                    case "Excel":
                        break;
                    case "PowerPoint":
                        break;
                }
            }
            catch(Exception)
            { }
        }

        private void btnResetProject_Click(object sender, EventArgs e)
        {
            switch (this.Test.OfficeApp)
            {
                case "Word":
                    Word.Application application = this.Application as Word.Application;
                    if (application.Documents.Count > 0)
                    {
                        application.ActiveDocument.Close(Word.Enums.WdSaveOptions.wdDoNotSaveChanges);
                    }
                    File.Copy(Path.Combine(this.AppResourcesPath, this.Test.Resources[0]), this.WorkingFilePaths(), true);
                    application.Documents.Open(this.WorkingFilePaths());
                    break;
                case "Excel":
                    break;
                case "PowerPoint":
                    break;
            }
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            this.resizeForm();
            this.resizeOfficeWindow();
        }
    }
}
