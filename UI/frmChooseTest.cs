using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace GUI
{
    public partial class frmChooseTest : Form
    {
        protected Form frmLoading = new frmLoading();
        public frmChooseTest()
        {
            InitializeComponent();
            string updaterUrl = System.Configuration.ConfigurationManager.AppSettings["updater-url"];
            AutoUpdater.Start(updaterUrl);

            string ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVer.Text = string.Format("Version: {0}", ver);
        }

        private void RunTest(
            Test test,
            Models.Enums.TestMode testMode = Models.Enums.TestMode.Practice, Models.Task resumeTask = null)
        {

            Dictionary<string, string> appProcesses = new Dictionary<string, string>();
            appProcesses.Add("Word", "winword");
            appProcesses.Add("PowerPoint", "powerpnt");
            appProcesses.Add("Excel", "excel");

            Process[] ps = Process.GetProcessesByName(appProcesses[test.OfficeApp]);
            if (ps.Length > 0)
            {
                DialogResult result = MessageBox.Show(ps.Length.ToString() + " " + test.OfficeApp + " process(es) should be end. Do you want to end all processes?", "End Process", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    foreach (var p in ps)
                    {
                        p.Kill();
                    }
                }
                else
                {
                    return;
                }
            }

            frmLoading.Show();

            switch (test.OfficeVersion)
            {
                case "2013":
                    (new frmRunTestOffice2013(this, this.txtUserName.Text, test, testMode, resumeTask)).Show();
                    break;
                case "2016":
                    (new frmRunTestOffice2016(this, this.txtUserName.Text, test, testMode, resumeTask)).Show();
                    break;
                default:
                    throw new Exception("Error");
            }

            this.Hide();
        }
        private void LoadTestsIntoCmb()
        {
            if (this.cmbOfficeVersion.SelectedIndex >= 0 && this.cmbOfficeApp.SelectedIndex >= 0)
            {
                this.cmbTestName.Text = "";
                this.lblLimitTime.Text = "N/a";
                string officeVersion = this.cmbOfficeVersion.SelectedItem.ToString();
                string officeApp = this.cmbOfficeApp.SelectedItem.ToString();
                this.cmbTestName.DataSource = Repository.getTestsBy(officeApp, officeVersion);
            }
        }

        private void cmbOfficeVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadTestsIntoCmb();
        }

        private void cmbOfficeApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadTestsIntoCmb();
        }

        private void btnPracticeMode_Click(object sender, EventArgs e)
        {
            Test test = this.cmbTestName.SelectedItem as Test;
            if (test != null)
            {
                this.RunTest(test, Models.Enums.TestMode.Practice);
            }
            else
            {
                MessageBox.Show("Please choose a test");
            }
        }

        private void frmChooseTest_Load(object sender, EventArgs e)
        {
            this.cmbTestName.DisplayMember = "Name";
            this.cmbTestName.ValueMember = "ID";
            this.cmbOfficeVersion.SelectedIndex = 0;
            this.cmbOfficeApp.SelectedIndex = 0;
            this.LoadTasks();
        }
        public void LoadTasks()
        {
            var tasks = Repository.getTasks();
            this.dataGridTasks.DataSource = tasks;
            this.dataGridTasks.Columns.Remove("TestID");
            this.dataGridTasks.Columns.Remove("Mode");
            this.dataGridTasks.Columns["UsedTime"].HeaderText = "Duration (s)";
            this.dataGridTasks.AutoResizeColumns();
        }

        private void dataGridTasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Models.Task task = this.dataGridTasks.Rows[e.RowIndex].DataBoundItem as Models.Task;
            Test test = Repository.getTestById(task.TestID);
            if (task.IsCompleted)
            {
                (new frmShowResult(task, test)).ShowDialog();
                return;
            }

            if (test == null)
            {
                MessageBox.Show("Test not found");
                return;
            }
            this.RunTest(test, (Models.Enums.TestMode)task.Mode, task);
        }

        private void btnTestingMode_Click(object sender, EventArgs e)
        {
            Test test = this.cmbTestName.SelectedItem as Test;
            if (test != null)
            {
                this.RunTest(test, Models.Enums.TestMode.Testing);
            }
            else
            {
                MessageBox.Show("Please choose a test");
            }
        }

        private void frmChooseTest_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                frmLoading.Close();
            }
        }

        private void cmbTestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTestName.SelectedItem == null)
            {
                this.lblLimitTime.Text = "N/a";
            }
            else
            {
                Test test = this.cmbTestName.SelectedItem as Test;
                this.lblLimitTime.Text = test.LimitTime.ToString() + " mins";
            }
        }
    }
}
