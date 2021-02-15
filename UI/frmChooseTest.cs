using GUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;
using GUI;
using GUI.Enums;
using System.Diagnostics;

namespace GUI
{
    public partial class frmChooseTest : Form
    {
        public frmChooseTest()
        {
            InitializeComponent();
        }

        private void RunTest(
            Test test,
            TestMode testMode = TestMode.Practice, Models.Task resumeTask = null)
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

            switch (test.OfficeVersion)
            {
                case "Office 2013":
                    (new frmRunTestOffice2013(this, test, testMode, resumeTask)).Show();
                    this.Hide();
                    break;
                case "Office 2016":
                    (new frmRunTestOffice2016(this, test, testMode, resumeTask)).Show();
                    this.Hide();
                    break;
                default:
                    throw new Exception("Error");
            }
        }
        private void LoadTestsIntoCmb()
        {
            if(this.cmbOfficeVersion.SelectedIndex >= 0 && this.cmbOfficeApp.SelectedIndex >= 0)
            {
                this.cmbTestName.Text = "";
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
            if(test != null)
            {
                this.RunTest(test, TestMode.Practice);
            }
            else
            {
                MessageBox.Show("Please choose a test");
            }
        }

        private void frmChooseTest_Load(object sender, EventArgs e)
        {
            //Db.initDb();
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
            this.dataGridTasks.Columns["TimerCurrent"].HeaderText = "Duration";
            this.dataGridTasks.AutoResizeColumns();
        }

        private void dataGridTasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Models.Task task = this.dataGridTasks.Rows[e.RowIndex].DataBoundItem as Models.Task;
            if (task.IsCompleted)
            {
                MessageBox.Show("This task had completed");
                return;
            }
            Test test = Repository.getTestById(task.TestID);
            if(test == null)
            {
                MessageBox.Show("Test not found");
                return;
            }
            this.RunTest(test, (TestMode)task.Mode, task);
        }

        private void btnTestingMode_Click(object sender, EventArgs e)
        {
            Test test = this.cmbTestName.SelectedItem as Test;
            if (test != null)
            {
                this.RunTest(test, TestMode.Testing);
            }
            else
            {
                MessageBox.Show("Please choose a test");
            }
        }
    }
}
