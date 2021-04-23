using Checker.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;
using Word = NetOffice.WordApi;
using Excel = NetOffice.ExcelApi;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class frmRunTestOffice2013 : frmBaseRunTest
    {
        private string baseStyleSheet = ".title{padding: 5px;background-color:#96cbc7}.position{padding: 5px 5px 5px 30px; background-color: #dadada}.list{padding: 5px 5px 5px 50px; background-color: white}.sublist{padding-left: 30px}";
        public frmRunTestOffice2013(Form parent, string userName, Test test, Models.Enums.TestMode mode, Task resumeTask = null) : base(parent, userName, test, mode)
        {
            InitializeComponent();

            this.labelHelpInfo.Visible = mode == Models.Enums.TestMode.Practice;
            this.loadQuestions();

            if (resumeTask != null)
            {
                this.Task = resumeTask;
                this.loadTask();
            }
            else
            {
                this.CreateTask();
            }

            this.LoadApp();
            this.LoadFileOffice();
            this.ResizeForm();
            this.CreateDirTemp();

            this.labelTestName.Text = this.Test.Name + " - " + this.Mode.ToString() + " Mode";

            if (mode == Models.Enums.TestMode.Testing)
            {
                this.ucTimer.Max = this.Test.LimitTime * 60;
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
            for (int i = 1; i <= this.Task.MarkCompletedQuestions[0].Count; ++i)
            {
                (this.tablePanelInstructions.Controls["cboxQuestion" + i.ToString()] as CheckBox).Checked = this.Task.MarkCompletedQuestions[0][i - 1];
            }
        }

        protected override void CreateTask(List<List<bool>> dict = null)
        {
            base.CreateTask();
            this.ucTimer.Current = 0;
        }

        private void frmRunTestOffice2013_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ucTimer.Current = 0;
            this.ucTimer.Stop();
            base.FrmClosed();
        }

        private void loadQuestions()
        {
            loadRefImages();

            this.tablePanelInstructions.ColumnStyles.Clear();
            this.tablePanelInstructions.RowStyles.Clear();
            this.tablePanelInstructions.ColumnCount = 2;
            this.tablePanelInstructions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            this.tablePanelInstructions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75));

            this.tablePanelQuestionTitle.RowStyles.Clear();

            int row = 1;
            int indexQuestion = 1;
            foreach (KeyValuePair<string, List<Question>> group in this.Test.Questions.OrderBy(x => x.Key))
            {
                this.tablePanelQuestionTitle.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                this.tablePanelQuestionTitle.Controls.Add(new Label()
                {
                    Text = group.Key,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
                }, 0, row);

                this.tablePanelInstructions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
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

                foreach (Question question in group.Value)
                {
                    this.tablePanelQuestionTitle.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    Label label = new Label()
                    {
                        Text = indexQuestion.ToString() + ". " + question.Title,
                        BorderStyle = BorderStyle.FixedSingle,
                        Dock = DockStyle.Fill,
                        Name = "labelQuestion" + indexQuestion.ToString(),
                        Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.GraphicsUnit.Point)
                    };

                    label.Click += new System.EventHandler(this.labelQuestion_Click);
                    this.tablePanelQuestionTitle.Controls.Add(label, 0, row);

                    this.tablePanelInstructions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    CheckBox cbox = new CheckBox()
                    {
                        Text = indexQuestion.ToString() + ". " + question.Title,
                        Name = "cboxQuestion" + indexQuestion.ToString(),
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
                        BaseStylesheet = this.baseStyleSheet
                    };
                    htmlLabel.DoubleClick += delegate
                    {
                        if (this.Mode == Models.Enums.TestMode.Testing) return;
                        MessageBox.Show(question.Help, "Help: Task " + indexQuestion.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };

                    this.tablePanelInstructions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    this.tablePanelInstructions.Controls.Add(cbox, 0, row);
                    this.tablePanelInstructions.Controls.Add(htmlLabel, 1, row);
                    this.tablePanelInstructions.RowStyles[row] = new RowStyle(SizeType.Absolute, htmlLabel.Height + 20);
                    htmlLabel.AutoSize = false;

                    row++;
                    indexQuestion++;
                }
            }

            tablePanelInstructions.RowCount = row - 1;
        }

        private void loadRefImages()
        {
            string refImagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.Test.ResourcesPath, "RefImages");
            Regex regex = new Regex(".*.[png|jpg]");
            foreach (string path in Directory.GetFiles(refImagesPath, "*.*").Where(file => regex.IsMatch(file)))
            {
                Image image = Image.FromFile(path);
                this.panelRefImages.Controls.Add(new PictureBox()
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.AutoSize
                });
            }
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
            ShowLoading();
            try
            {
                List<bool> points = null;
                string className = ("Checker." + this.Test.OfficeApp + "." + this.Test.Name + "_" + this.Test.OfficeVersion).Replace(" ", "_");
                
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        BaseWordTest wordTestChecker = this.CreateTestChecker(className) as BaseWordTest;
                        Word.Application wordApp = this.Application as Word.Application;
                        Word.Document document = wordApp.ActiveDocument;
                        document.Save();

                        wordTestChecker.Document = document;
                        points = wordTestChecker.Points;

                        break;
                    case "Excel":
                        Excel.Application excelApp = this.Application as Excel.Application;
                        Excel.Workbook workBook = excelApp.ActiveWorkbook;
                        workBook.Close(true);

                        string themeXmlContent = Checker.Utils.Excel.GetThemeXmlContent(WorkingFilePaths());
                        BaseExcelTest excelTestChecker = this.CreateTestChecker(className) as BaseExcelTest;
                        excelTestChecker.ThemeXmlContent = themeXmlContent;

                        LoadFileOffice();
                        excelTestChecker.Workbook = (Application as Excel.Application).ActiveWorkbook;
                        points = excelTestChecker.Points;

                        break;
                    case "PowerPoint":
                        break;
                }

                int correctedQuestions = points.FindAll(x => x == true).Count;
                this.Task.IsCompleted = true;
                this.Task.UsedTime = this.ucTimer.Current;
                this.Task.Points.Add(points);
                double score = Math.Min(Math.Ceiling((double)(correctedQuestions * (1000f / points.Count))), 1000f);
                this.Task.Score = Convert.ToInt32(score);
                Repository.updateTask(this.Task);
                CloseLoading();
                MessageBox.Show($"Your Score: {this.Task.Score}\nCorrected Tasks: {correctedQuestions}/{points.Count}", "Your Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
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
            ShowLoading();
            try
            {
                List<bool> markQuestions = new List<bool>();

                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application wordApp = this.Application as Word.Application;
                        wordApp.Quit(Word.Enums.WdSaveOptions.wdSaveChanges);
                        wordApp.Dispose();

                        break;
                    case "Excel":
                        Excel.Application excelApp = this.Application as Excel.Application;
                        excelApp.ActiveWorkbook.Close(true);
                        excelApp.Quit();
                        excelApp.Dispose();
                        break;
                    case "PowerPoint":
                        break;
                }

                int indexQuestion = 1;
                foreach (var group in this.Test.Questions)
                {
                    foreach (var question in group.Value)
                    {
                        if (((this.tablePanelQuestionTitle.Controls["labelQuestion" + indexQuestion.ToString()]) as Label).ForeColor == Color.Blue)
                        {
                            markQuestions.Add(true);
                        }
                        else
                        {
                            markQuestions.Add(false);
                        }

                        indexQuestion++;
                    }
                }

                this.Task.IsCompleted = false;
                this.Task.UsedTime = this.ucTimer.Current;
                this.Task.MarkCompletedQuestions.Clear();
                this.Task.MarkCompletedQuestions.Add(markQuestions);
                Repository.updateTask(this.Task);
                CloseLoading();
                this.Close();
            }
            catch (Exception)
            { }
        }

        private void btnResetProject_Click(object sender, EventArgs e)
        {
            base.ResetProject(0);
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            this.ResizeForm();
            if ((this.Application as NetOffice.COMObject).UnderlyingTypeName == "")
            {
                LoadApp();
                LoadFileOffice();
            }
            else
            {
                this.ResizeOfficeWindow();
            }
        }
    }
}
