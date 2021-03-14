using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private void btnInitDb_Click(object sender, System.EventArgs e)
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
            dataGridTests.Columns["Questions"].Visible = false;
            dataGridTests.Refresh();
        }

        private void updateTest(object sender, System.EventArgs e)
        {
            if (testBindingSource.Current is Test test)
            {
                Repository.updateTest(test);
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            Repository.createTest(new Test() { Name = "New Test", OfficeApp = "Word", OfficeVersion = "Office 2013", Questions = new Dictionary<string, List<Question>>(), Resources = new List<string>() });
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
            if (testBindingSource.Current is Test currentTest)
            {
                string content = "";
                if (currentTest.OfficeVersion == "Office 2013")
                {
                    content = @"<div class='title'>Title</div>
<div class='position'>Position</div>
<div class='list'>* List: 1</div>";
                }
                if (currentTest.Questions.Count > 0 && keyComboBox.Text != "")
                {
                    if (!currentTest.Questions.ContainsKey(keyComboBox.Text))
                    {
                        currentTest.Questions.Add(keyComboBox.Text, new List<Question>());
                    }

                    currentTest.Questions[keyComboBox.Text].Add(new Question
                    {
                        Content = content
                    });
                }
                else
                {
                    currentTest.Questions.Add("1", new List<Question> {
                        new Question
                        {
                            Content = content,
                        }
                    });
                }

                Repository.updateTest(currentTest);
                loadData();
                dataGridQuestions.FirstDisplayedScrollingRowIndex = dataGridQuestions.RowCount - 1;
            }
        }

        private void btnQSave_Click(object sender, EventArgs e)
        {
            if (testBindingSource.Current is Test currentTest)
            {
                if (dataGridQuestions.CurrentRow != null)
                {
                    int index = dataGridQuestions.CurrentRow.Index;
                    Repository.updateTest(currentTest);
                    loadData();
                    dataGridQuestions.FirstDisplayedScrollingRowIndex = index;
                    MessageBox.Show("Data has updated");
                }
            }
        }

        private void btnQDel_Click(object sender, EventArgs e)
        {
            if (testBindingSource.Current is Test currentTest)
            {
                if (dataGridQuestions.CurrentRow.DataBoundItem is Question question)
                {
                    string key = keyComboBox.Text.ToString();
                    if (MessageBox.Show("Bạn có muốn xóa?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    currentTest.Questions[key]?.Remove(question);
                    Repository.updateTest(currentTest);
                    loadData();
                }
            }
        }

        private void testBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (testBindingSource.Current is Test test)
            {
                if (test?.Resources == null) return;
                txtResources.Text = string.Join(",", test.Resources);
                keyComboBox.DataSource = test.Questions.Keys.ToList<string>();
            }
        }

        private void txtResources_Leave(object sender, EventArgs e)
        {
            if (testBindingSource.Current is Test test)
            {
                test.Resources = new List<string>(txtResources.Text.Split(','));
            }
        }

        private void btnRefreshDb_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void contentTextBox_Leave(object sender, EventArgs e)
        {
            updateQuestion(null, null);
            htmlPanel.Text = contentTextBox.Text;
        }

        private void updateQuestion(object sender, EventArgs e)
        {
            if (dataGridQuestions.CurrentRow?.DataBoundItem is Question question)
            {
                question.Title = titleTextBox.Text;
                question.Content = contentTextBox.Text;
                question.Help = helpTextBox.Text;
                dataGridQuestions.Refresh();
            }
        }

        private void keyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testBindingSource.Current is Test test)
            {
                if (keyComboBox.SelectedItem is string key)
                {
                    dataGridQuestions.DataSource = test.Questions[key];
                }
            }
        }

        private void btnGAdd_Click(object sender, EventArgs e)
        {
            if (testBindingSource.Current is Test test && keyComboBox.Text != null)
            {
                if (test.Questions.ContainsKey(keyComboBox.Text))
                {
                    MessageBox.Show("Key Duplicated");
                    return;
                }
                test.Questions.Add(keyComboBox.Text, new List<Question>());
                Repository.updateTest(test);
                loadData();
            }
        }

        private void btnGDel_Click(object sender, EventArgs e)
        {
            if (testBindingSource.Current is Test test && keyComboBox.Text != "")
            {
                test.Questions.Remove(keyComboBox.Text);
                Repository.updateTest(test);
                loadData();
            }
        }

        private void dataGridQuestions_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridQuestions.CurrentRow.Index + 1 > (dataGridQuestions.DataSource as List<Question>).Count) return;
            if (dataGridQuestions.CurrentRow?.DataBoundItem is Question question)
            {
                contentTextBox.Text = question.Content;
                titleTextBox.Text = question.Title;
                helpTextBox.Text = question.Help;
                htmlPanel.Text = question.Content;
            }
        }
    }
}
