using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTestSummary : Form
    {
        public new frmRunTestOffice2016 ParentForm { get; set; }
        public frmTestSummary()
        {
            InitializeComponent();
        }



        private void btnProject_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as Control).Name.Replace("btnProject", ""));
            this.ParentForm.SelectedProject = index;
            (this.ParentForm as frmRunTestOffice2016).loadProject();
            this.Close();
        }

        private void frmTestSummary_Load(object sender, EventArgs e)
        {
            List<string> resources = this.ParentForm.Test.Resources;

            this.tableLayoutPanel1.RowStyles.Clear();

            for (int row = 0; row < resources.Count; ++row)
            {
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                Label label = new Label()
                {
                    Text = $"{row + 1}. {resources[row]}",
                    Font = new System.Drawing.Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point),
                    Dock = DockStyle.Fill
                };
                Button button = new Button()
                {
                    Name = "btnProject" + row.ToString(),
                    Text = "Move",
                    Dock = DockStyle.Fill,
                    Font = new System.Drawing.Font("Segoe UI", 11f, FontStyle.Bold, GraphicsUnit.Point),
                };
                button.Click += this.btnProject_Click;

                this.tableLayoutPanel1.Controls.Add(label, 0, row);
                this.tableLayoutPanel1.Controls.Add(button, 1, row);
            }
        }
    }
}
