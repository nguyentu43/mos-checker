using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ManageDb
{
    public partial class frmManageDb : Form
    {
        public Test CurrentTest
        {
            get
            {
                return testBindingSource.Current as Test;
            }
        }
        public frmManageDb()
        {
            InitializeComponent();
            string baseStyleSheet = ".title{padding: 5px;background-color:#96cbc7}.position{padding: 5px 5px 5px 30px; background-color: #dadada}.list{padding: 5px 5px 5px 50px; background-color: white}.sublist{padding-left: 30px}";
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

            string prev = groupQuestionComboBox.Text;
            List<Test> tests = Repository.getTests();
            testBindingSource.DataSource = tests;
            dataGridTests.DataSource = testBindingSource;
            dataGridTests.Columns["ResourcesPath"].Visible = false;
            dataGridTests.Columns["Questions"].Visible = false;
            dataGridTests.Refresh();
            groupQuestionComboBox.Text = prev;
        }

        private void updateTest(object sender, System.EventArgs e)
        {
            if (CurrentTest != null)
            {
                CurrentTest.Resources = new List<string>(txtResources.Text.Split(','));
                Repository.updateTest(CurrentTest);
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            Repository.createTest(new Test() { Name = "New Test", OfficeApp = "Word", OfficeVersion = "2013", Questions = new Dictionary<string, List<Question>>(), Resources = new List<string>() });
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
            if (CurrentTest != null)
            {
                string content = "";
                if (CurrentTest.OfficeVersion == "2013")
                {
                    content = @"<div class='title'>
Title
</div>
<div class='position'>
Position
</div>
<div class='list'>
* List: 1
</div>";
                }
                if (CurrentTest.Questions.Count > 0 && groupQuestionComboBox.Text != "")
                {
                    if (!CurrentTest.Questions.ContainsKey(groupQuestionComboBox.Text))
                    {
                        CurrentTest.Questions.Add(groupQuestionComboBox.Text, new List<Question>());
                    }

                    CurrentTest.Questions[groupQuestionComboBox.Text].Add(new Question
                    {
                        Content = content
                    });
                }
                else
                {
                    CurrentTest.Questions.Add("1", new List<Question> {
                        new Question
                        {
                            Content = content,
                        }
                    });
                }

                Repository.updateTest(CurrentTest);
                loadData();
                if (dataGridQuestions.RowCount > 0)
                {
                    dataGridQuestions.FirstDisplayedScrollingRowIndex = dataGridQuestions.RowCount - 1;
                }
            }
        }

        private void btnQSave_Click(object sender, EventArgs e)
        {
            if (CurrentTest != null)
            {
                if (dataGridQuestions.CurrentRow != null)
                {
                    int index = dataGridQuestions.CurrentRow.Index;
                    Repository.updateTest(CurrentTest);
                    loadData();
                    dataGridQuestions.FirstDisplayedScrollingRowIndex = index;
                    MessageBox.Show("Data has updated");
                }
            }
        }

        private void btnQDel_Click(object sender, EventArgs e)
        {
            if (CurrentTest != null)
            {
                if (dataGridQuestions.CurrentRow.DataBoundItem is Question question)
                {
                    string key = groupQuestionComboBox.Text.ToString();
                    if (MessageBox.Show("Bạn có muốn xóa?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    CurrentTest.Questions[key]?.Remove(question);
                    Repository.updateTest(CurrentTest);
                    loadData();
                }
            }
        }

        private void testBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CurrentTest != null)
            {
                if (CurrentTest.Resources == null) return;
                txtResources.Text = string.Join(",", CurrentTest.Resources);
                groupQuestionComboBox.SelectedItem = null;
                titleTextBox.Text = "";
                helpTextBox.Text = "";
                contentTextBox.Text = "";
                groupQuestionComboBox.DataSource = CurrentTest.Questions.Keys.ToList<string>();
                
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
                Repository.updateTest(CurrentTest);
                dataGridQuestions.Refresh();
            }
        }

        private void keyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentTest != null)
            {
                dataGridQuestions.DataSource = null;
                if (groupQuestionComboBox.SelectedItem is string key)
                {
                    dataGridQuestions.DataSource = CurrentTest.Questions[key];
                }
            }
        }

        private void btnGAdd_Click(object sender, EventArgs e)
        {
            if(groupQuestionComboBox.Text.Trim() == "")
            {
                MessageBox.Show("Group Name not empty!");
                return;
            }    
            if (CurrentTest != null)
            {
                if (CurrentTest.Questions.ContainsKey(groupQuestionComboBox.Text))
                {
                    MessageBox.Show("Key Duplicated");
                    return;
                }
                CurrentTest.Questions.Add(groupQuestionComboBox.Text, new List<Question>());
                Repository.updateTest(CurrentTest);
                loadData();
            }
        }

        private void btnGDel_Click(object sender, EventArgs e)
        {
            if (CurrentTest != null && groupQuestionComboBox.Text != "")
            {
                CurrentTest.Questions.Remove(groupQuestionComboBox.Text);
                Repository.updateTest(CurrentTest);
                loadData();
            }
        }

        private void dataGridQuestions_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridQuestions.CurrentRow?.Index + 1 > (dataGridQuestions.DataSource as List<Question>).Count) return;
            if (dataGridQuestions.CurrentRow?.DataBoundItem is Question question)
            {
                contentTextBox.Text = question.Content;
                titleTextBox.Text = question.Title;
                helpTextBox.Text = question.Help;
                htmlPanel.Text = question.Content;
            }
        }

        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if(dataGridQuestions.CurrentRow != null)
            {
                List<Question> list = dataGridQuestions.DataSource as List<Question>;
                int index = dataGridQuestions.CurrentRow.Index;
                if(index > 0)
                {
                    Swap(list, index, index - 1);
                }
                CurrentTest.Questions[groupQuestionComboBox.Text] = list;
                Repository.updateTest(CurrentTest);
                loadData();
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (dataGridQuestions.CurrentRow != null)
            {
                List<Question> list = dataGridQuestions.DataSource as List<Question>;
                int index = dataGridQuestions.CurrentRow.Index;
                if (index >= 0 && index < dataGridQuestions.Rows.Count)
                {
                    Swap(list, index , index + 1);
                }
                CurrentTest.Questions[groupQuestionComboBox.Text] = list;
                Repository.updateTest(CurrentTest);
                loadData();
            }
        }
    }
}
