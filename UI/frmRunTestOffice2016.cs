using Checker.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Word = NetOffice.WordApi;

namespace GUI
{
    public partial class frmRunTestOffice2016 : frmBaseRunTest
    {
        public int SelectedProject { get; set; }
        public List<List<Question>> Projects { get; set; }
        public frmRunTestOffice2016(Form parent, string userName, Test test, Models.Enums.TestMode mode, Models.Task resumeTask = null) : base(parent, userName, test, mode)
        {
            InitializeComponent();

            this.groupQuestions();
            this.LoadApp();

            if (resumeTask != null)
            {
                this.Task = resumeTask;
                this.loadTask();
            }
            else
            {
                List<List<bool>> dict = new List<List<bool>>();
                foreach (var p in this.Projects)
                {
                    List<bool> l = new List<bool>();
                    for (int j = 0; j < p.Count - 1; ++j)
                    {
                        l.Add(false);
                    }
                    dict.Add(l);
                }
                this.CreateTask(dict);
            }

            this.SelectedProject = 0;
            this.loadProject();
            this.CreateDirTemp();
            this.ResizeForm();

            if (mode == Models.Enums.TestMode.Testing)
            {
                this.ucTimer.Max = this.Test.LimitTime * 60;
                this.ucTimer.EndEvent += this.TimerEnd;
            }
            this.ucTimer.Start();
            this.labelTestName.Text = this.Test.Name + " - " + this.Mode.ToString() + " Mode";
        }

        private void TimerEnd(object sender, EventArgs e)
        {
            this.btnGrade_Click(null, null);
        }

        private void groupQuestions()
        {
            List<List<Question>> projects = new List<List<Question>>();
            foreach (var group in this.Test.Questions.OrderBy(x => x.Key))
            {
                projects.Add(group.Value);
            }
            this.Projects = projects;
        }

        private void loadTask()
        {
            this.ucTimer.Current = this.Task.UsedTime;
        }

        protected override void CreateTask(List<List<bool>> dict = null)
        {
            base.CreateTask(dict);
            this.ucTimer.Current = 0;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            this.ResizeForm();
            if ((this.Application as NetOffice.COMObject).UnderlyingTypeName == "")
            {
                LoadApp();
                LoadFileOffice(this.SelectedProject);
            }
            else
            {
                this.ResizeOfficeWindow();
            }
        }

        private void frmRunTestOffice2016_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ucTimer.Current = 0;
            this.ucTimer.Stop();
            base.FrmClosed();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            (new frmTestSummary()
            {
                ParentForm = this
            }).ShowDialog(this);
        }

        public void loadProject()
        {
            int index = this.SelectedProject;
            this.lblSelectedProject.Text = $"Project {index + 1} of {this.Projects.Count}";
            this.LoadFileOffice(this.SelectedProject);
            this.buildControlQuestions();
            this.btnQuestion_Click(this.panelQuestionTitle.Controls["btnQuestion0"], null);
            this.loadMarkQuestionFromSave();
        }

        private void loadMarkQuestionFromSave()
        {
            List<bool> markQuestions = this.Task.MarkCompletedQuestions[this.SelectedProject];

            foreach (Control control in this.panelQuestionTitle.Controls)
            {
                int index = Convert.ToInt32(control.Name.Replace("btnQuestion", ""));
                if (index > 0 && markQuestions[index - 1])
                {
                    control.BackColor = Color.Orange;
                }
            }
        }

        private void buildControlQuestions()
        {
            this.panelQuestionTitle.Controls.Clear();
            List<Question> questions = this.Projects[this.SelectedProject].Reverse<Question>().ToList<Question>();
            int row = questions.Count - 1;
            foreach (Question question in questions)
            {
                Button button = new Button()
                {
                    Text = question.Title,
                    Dock = DockStyle.Left,
                    AutoSize = true,
                    Name = "btnQuestion" + row.ToString()
                };
                button.Click += this.btnQuestion_Click;
                this.panelQuestionTitle.Controls.Add(button);
                row--;
            }
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button;
            int index = Convert.ToInt32(selectedButton.Name.Replace("btnQuestion", ""));
            Question question = this.Projects[this.SelectedProject][index];
            this.htmlPanelQuestionContent.Text = question.Content;

            if (btnHelp.ForeColor == Color.Red)
            {
                this.htmlPanelQuestionContent.Text += "<h3>HELP</h3>" + question.Help?.Replace("\n", "<br>");
            }
            foreach (Control button in this.panelQuestionTitle.Controls)
            {
                button.ForeColor = Color.Black;
            }
            selectedButton.ForeColor = Color.Blue;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnResize_Click(null, null);
            base.ResetProject(this.SelectedProject);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (this.btnHelp.ForeColor == Color.Red)
            {
                this.btnHelp.ForeColor = Color.Black;
            }
            else
            {
                this.btnHelp.ForeColor = Color.Red;
            }

            btnQuestion_Click(this.getSelectedQuestionButton(), null);
        }

        private Control getSelectedQuestionButton()
        {
            foreach (Control button in this.panelQuestionTitle.Controls)
            {
                if (button.ForeColor == Color.Blue)
                {
                    return button;
                }
            }

            return this.panelQuestionTitle.Controls[0];
        }

        private void btnMarkCompleted_Click(object sender, EventArgs e)
        {
            Control button = this.getSelectedQuestionButton();
            int index = Convert.ToInt32(button.Name.Replace("btnQuestion", ""));
            if (index == 0) return;
            if (button.BackColor == Color.Orange)
            {
                button.BackColor = SystemColors.Control;
                this.Task.MarkCompletedQuestions[this.SelectedProject][index - 1] = false;
            }
            else
            {
                button.BackColor = Color.Orange;
                this.Task.MarkCompletedQuestions[this.SelectedProject][index - 1] = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Do you want to exit and save this test?", "Save Test", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            btnResize_Click(null, null);

            this.ucTimer.Stop();
            ShowLoading();
            try
            {
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application application = this.Application as Word.Application;
                        application.Quit(Word.Enums.WdSaveOptions.wdSaveChanges);
                        application.Dispose();
                        break;
                    case "Excel":
                        break;
                    case "PowerPoint":
                        break;
                }

                this.Task.IsCompleted = false;
                this.Task.UsedTime = this.ucTimer.Current;
                Repository.updateTask(this.Task);
                CloseLoading();
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error("Save - " + Test.ToString());
            }
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit and submit this test?", "Submit Test", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            btnResize_Click(null, null);

            ShowLoading();
            string correctedTasksPerProject = "";
            float scorePerProject = 1000f / this.Projects.Count;
            float score = 0;

            try
            {
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application application = this.Application as Word.Application;
                        if (application.Documents.Count > 0)
                        {
                            application.ActiveDocument.Close(Word.Enums.WdSaveOptions.wdSaveChanges);
                        }

                        for (int i = 1; i <= this.Projects.Count; ++i)
                        {
                            float scorePerTask = scorePerProject / (this.Projects[i - 1].Count - 1);

                            string className = ("Checker." + this.Test.OfficeApp + "." + "Project_" + i.ToString() + "_" + this.Test.Name + "_" + this.Test.OfficeVersion).Replace(" ", "_");
                            BaseWordTest testChecker = this.CreateTestChecker(className) as BaseWordTest;

                            Word.Document document = application.Documents.Open(this.WorkingFilePaths(i - 1));
                            testChecker.Document = document;

                            var points = testChecker.Points;
                            this.Task.Points.Add(points);

                            score += scorePerTask * points.FindAll(x => x == true).Count;
                            correctedTasksPerProject += "\nProject " + i.ToString() + ": " + points.FindAll(x => x == true).Count.ToString() + "/" + points.Count.ToString();
                        }
                        break;
                    case "Excel":
                        break;
                    case "PowerPoint":
                        break;
                }

                this.Task.Score = Convert.ToInt32(Math.Min(Math.Ceiling(score), 1000f));
                this.Task.IsCompleted = true;
                this.Task.UsedTime = this.ucTimer.Current;

                Repository.updateTask(this.Task);
                CloseLoading();

                MessageBox.Show($"Your Score: {this.Task.Score}\n" + correctedTasksPerProject, "Your Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error("Grade - " + Test.ToString());
            }
        }
    }
}
