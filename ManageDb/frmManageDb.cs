using Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ManageDb
{
    public partial class frmManageDb : Form
    {
        public frmManageDb()
        {
            InitializeComponent();
            string baseStyleSheet = ".title{padding: 5px;background-color:#96cbc7}.position{padding: 5px 5px 5px 30px; background-color: gray}.list{padding: 5px 5px 5px 50px; background-color: white}";
            htmlPanel.BaseStylesheet = baseStyleSheet;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Db.initDb();
            loadData();
            MessageBox.Show("OK");
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            List<Test> tests = Repository.getTests();
            testBindingSource.DataSource = tests;
            dataGridTests.DataSource = testBindingSource;
            dataGridTests.Columns["ResourcesPath"].Visible = false;
            dataGridTests.Refresh();
        }

        private Test getCurrentTest()
        {
            if (testBindingSource.Current != null)
            {
                return testBindingSource.Current as Test;
            }
            return null;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            List<Test> tests = testBindingSource.DataSource as List<Test>;
            foreach (Test test in tests)
            {
                Repository.updateTest(test);
            }
            MessageBox.Show("Data has updated");
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            Repository.createTest(new Test() { Name = "New Test", OfficeApp = "Word", OfficeVersion = "Office 2013", Questions = new List<Question>(), Resources = new List<string>() });
            loadData();
            dataGridTests.FirstDisplayedScrollingRowIndex = dataGridTests.RowCount - 1;
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            if (iDTextBox.Text == "") return;
            if (MessageBox.Show("Bạn có muốn xóa?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Repository.removeTest(Convert.ToInt32(iDTextBox.Text));
            loadData();
        }

        private void btnQAdd_Click(object sender, EventArgs e)
        {
            Test currentTest = getCurrentTest();
            if (currentTest != null)
            {
                string content = "";
                if (currentTest.OfficeVersion == "Office 2013")
                {
                    content = @"<div class='title'>Title</div>
<div class='position'>Position</div>
<div class='list'>* List: 1</div>";
                }
                if (currentTest.Questions.Count > 0)
                {

                    Question lastQuestion = currentTest.Questions[currentTest.Questions.Count - 1];
                    currentTest.Questions.Add(new Question
                    {
                        Index = lastQuestion.Index + 1,
                        Group = lastQuestion.Group,
                        Content = content
                    });
                }
                else
                {
                    currentTest.Questions.Add(new Question
                    {
                        Index = 1,
                        Group = "New Group",
                        Content = content
                    });
                }

                Repository.updateTest(currentTest);
                loadData();
                dataGridQues.FirstDisplayedScrollingRowIndex = dataGridQues.RowCount - 1;
            }
        }

        private void btnQSave_Click(object sender, EventArgs e)
        {
            Test currentTest = getCurrentTest();
            if (currentTest != null)
            {
                if (dataGridQues.CurrentRow != null)
                {
                    int index = dataGridQues.CurrentRow.Index;
                    Repository.updateTest(currentTest);
                    loadData();
                    dataGridQues.FirstDisplayedScrollingRowIndex = index;
                    MessageBox.Show("Data has updated");
                }
            }
        }

        private void btnQDel_Click(object sender, EventArgs e)
        {
            Test currentTest = getCurrentTest();
            if (currentTest != null)
            {
                if (dataGridQues.CurrentRow != null)
                {
                    int index = dataGridQues.CurrentRow.Index;
                    Question question = currentTest.Questions[index];
                    if (MessageBox.Show("Bạn có muốn xóa?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    currentTest.Questions.Remove(question);
                    Repository.updateTest(currentTest);
                    loadData();
                    dataGridQues.FirstDisplayedScrollingRowIndex = index - 1;
                }
            }
        }

        private void testBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Test test = getCurrentTest();
            if (test == null || test.Resources == null) return;
            txtResources.Text = string.Join(",", test.Resources);
        }

        private void txtResources_Leave(object sender, EventArgs e)
        {
            Test test = getCurrentTest();
            if (test == null) return;
            test.Resources = new List<string>(txtResources.Text.Split(','));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadData();
        }

        private void contentTextBox_Leave(object sender, EventArgs e)
        {
            htmlPanel.Text = contentTextBox.Text;
        }

        private void questionsBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            Question question = questionsBindingSource.Current as Question;
            htmlPanel.Text = question.Content;
        }
    }
}
