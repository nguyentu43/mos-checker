using Checker.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Word = NetOffice.WordApi;

namespace GUI
{
    public partial class frmRunTestOffice2016 : fromBaseRunTest
    {
        public int SelectedProject { get; set; }
        public List<List<Question>> Projects { get; set; }
        public frmRunTestOffice2016(Form parent, string userName, Test test, Models.Enums.TestMode mode, Models.Task resumeTask = null) : base(parent, userName, test, mode)
        {
            InitializeComponent();

            this.groupQuestions();
            this.loadApp();

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
                this.createTask(dict);
            }

            this.SelectedProject = 0;
            this.loadProject();
            this.createDirTemp();
            this.resizeForm();

            if (mode == Models.Enums.TestMode.Testing)
            {
                this.ucTimer.Max = 50 * 60;
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
            foreach (IGrouping<string, Question> group in this.Test.Questions.GroupBy(x => x.Group).OrderBy(x => x.Key))
            {
                List<Question> questions = group.ToList<Question>().OrderBy(x => x.Index).ToList<Question>();
                projects.Add(questions);
            }
            this.Projects = projects;
        }

        private void loadTask()
        {
            this.ucTimer.Current = this.Task.UsedTime;
        }

        protected override void createTask(List<List<bool>> dict = null)
        {
            base.createTask(dict);
            this.ucTimer.Current = 0;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            this.resizeForm();
            this.resizeOfficeWindow();
        }

        private void frmRunTestOffice2016_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ucTimer.Current = 0;
            this.ucTimer.Stop();
            base.formClosed();
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
            this.loadFileOffice();
            this.loadProjectQuestions();
            this.btnQuestion_Click(this.panelQuestionTitle.Controls["btnQuestion0"], null);
            this.loadMarkQuestions();
        }

        private void loadMarkQuestions()
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

        private void loadProjectQuestions()
        {
            this.panelQuestionTitle.Controls.Clear();
            List<Question> questions = this.Projects[this.SelectedProject].Reverse<Question>().ToList<Question>();
            foreach (Question question in questions)
            {
                Button button = new Button()
                {
                    Text = question.Title,
                    Dock = DockStyle.Left,
                    AutoSize = true,
                    Name = "btnQuestion" + question.Index
                };
                button.Click += this.btnQuestion_Click;
                this.panelQuestionTitle.Controls.Add(button);
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

        private void loadFileOffice()
        {
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
                        application.Documents.Open(this.WorkingFilePaths(this.SelectedProject));
                        break;
                    case "Excel":
                        break;
                    case "PowerPoint":
                        break;
                }
            }
            catch (Exception)
            { }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            base.resetProject(this.SelectedProject);
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
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            try
            {
                this.ucTimer.Stop();

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
                this.Close();
            }
            catch (Exception)
            { }
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

            string correctedTasksPerProject = "";

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

                        float scorePerProject = 1000f / this.Projects.Count;
                        float score = 0;

                        for (int i = 1; i <= this.Projects.Count; ++i)
                        {
                            float scorePerTask = scorePerProject / (this.Projects[i - 1].Count - 1);

                            string className = ("Checker." + this.Test.OfficeApp + "." + "Project_" + i.ToString() + "_" + this.Test.Name + "_" + this.Test.OfficeVersion).Replace(" ", "_");
                            BaseTest testChecker = this.createTestChecker(className);

                            Word.Document document = application.Documents.Open(this.WorkingFilePaths(i - 1));
                            testChecker.Document = document;

                            var points = testChecker.Points;
                            this.Task.Points.Add(points);
                            document.Close(Word.Enums.WdSaveOptions.wdDoNotSaveChanges);
                            score += scorePerTask * points.FindAll(x => x == true).Count;
                            correctedTasksPerProject += "\nProject " + i.ToString() + ": " + points.FindAll(x => x == true).Count.ToString() + "/" + points.Count.ToString();
                        }

                        this.Task.Score = Convert.ToInt32(Math.Min(Math.Ceiling(score), 1000f));

                        application.Quit(Word.Enums.WdSaveOptions.wdDoNotSaveChanges);
                        application.Dispose();

                        break;
                    case "Excel":
                        break;
                    case "PowerPoint":
                        break;
                }

                this.Task.IsCompleted = true;
                this.Task.UsedTime = this.ucTimer.Current;

                Repository.updateTask(this.Task);

                MessageBox.Show($"Your Score: {this.Task.Score}\n" + correctedTasksPerProject, "Your Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            { }
        }
    }
}
