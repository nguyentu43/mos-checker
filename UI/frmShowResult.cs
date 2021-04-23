using Models;
using Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmShowResult : Form
    {
        public class RowResult
        {
            public string Title { get; set; }
            public string IsCorrected { get; set; }
        }
        public frmShowResult(Models.Task task, Test test)
        {
            InitializeComponent();

            lblScore.Text = task.Score.ToString();
            lblName.Text += task.UserName;
            lblCreatedAt.Text += task.CreatedAt.ToString();
            lblTest.Text += string.Format("{0}-{1} {2}", test.OfficeApp, test.Name, task.Mode == (int)TestMode.Practice ? "Practice" : "Testing");
            lblTime.Text += task.UsedTime.ToString();

            List<RowResult> list = new List<RowResult>();

            int indexQuestion = 1;
            switch (test.OfficeVersion)
            {
                case "2013":

                    foreach (var group in test.Questions.OrderBy(x => x.Key))
                    {
                        foreach (var question in group.Value)
                        {
                            list.Add(new RowResult { Title = indexQuestion.ToString() + ". " + question.Title, IsCorrected = task.Points[0][indexQuestion - 1] ? "true" : "false" });
                            indexQuestion++;
                        }
                    }
                    break;
                case "2016":
                    int indexGroup = 0;
                    foreach (var group in test.Questions.OrderBy(x => x.Key))
                    {
                        indexQuestion = 0;
                        foreach (var question in group.Value)
                        {
                            if (indexQuestion == 0)
                            {
                                list.Add(new RowResult
                                {
                                    Title = "PROJECT " + group.Key,
                                    IsCorrected = "---"
                                });
                            }
                            else
                            {
                                list.Add(new RowResult
                                {
                                    Title = question.Title,
                                    IsCorrected = task.Points[indexGroup][indexQuestion - 1] ? "true" : "false"
                                });
                            }
                            indexQuestion++;
                        }
                        indexGroup++;
                    }
                    break;
            }

            dataGridView.DataSource = list;
        }
    }
}
