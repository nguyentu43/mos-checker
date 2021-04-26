using Checker.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Word = NetOffice.WordApi;
using Excel = NetOffice.ExcelApi;

namespace GUI
{
    public abstract class frmBaseRunTest: Form
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected const string dirTemp = "MyTemplates";
        public Test Test { get; }
        public Models.Enums.TestMode Mode { get; }
        public new Form ParentForm { get; }
        public object Application { get; set; }
        public Models.Task Task { get; set; }
        public string UserName { get; set; }

        private Form frmLoading = new frmLoading();
        public string CurrentDirPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }
        public string AppResourcesPath
        {
            get
            {
                return Path.Combine(this.CurrentDirPath, this.Test.ResourcesPath);
            }
        }
        public string WorkingDirPath
        {
            get
            {
                return Path.Combine(this.CurrentDirPath, "Tasks", this.Task.ID.ToString());
            }
        }
        public virtual string WorkingFilePaths(int index = 0)
        {
            return Path.Combine(this.WorkingDirPath, this.Test.Resources[index]);
        }

        public frmBaseRunTest(Form parent, string userName, Test test, Models.Enums.TestMode mode, Models.Task resumeTask = null)
        {
            this.Test = test;
            this.Mode = mode;
            this.ParentForm = parent;
            this.UserName = userName;
        }

        protected virtual void ResizeForm()
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            this.WindowState = FormWindowState.Normal;
            this.Left = 0;
            this.Top = Convert.ToInt32(workingArea.Height * 0.66);
            this.Height = Convert.ToInt32(workingArea.Height * 0.35);
            this.Width = workingArea.Width;
        }

        protected virtual void ResizeOfficeWindow()
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            int height = Convert.ToInt32(workingArea.Height * 0.49f);
            int width = Convert.ToInt32(workingArea.Width * 0.75f);
            switch (this.Test.OfficeApp)
            {
                case "Word":
                    Word.Application wordApp = this.Application as Word.Application;
                    wordApp.WindowState = Word.Enums.WdWindowState.wdWindowStateNormal;
                    wordApp.Top = 0;
                    wordApp.Left = 0;
                    wordApp.Height = height;
                    wordApp.Width = width;
                    break;
                case "Excel":
                    Excel.Application excelApp = this.Application as Excel.Application;
                    excelApp.WindowState = Excel.Enums.XlWindowState.xlNormal;
                    excelApp.Top = 0;
                    excelApp.Left = 0;
                    excelApp.Height = height;
                    excelApp.Width = width;
                    break;
                case "PowerPoint":
                    break;
            }

        }

        protected virtual void CreateTask(List<List<bool>> dict = null)
        {
            string mode = (this.Mode == Models.Enums.TestMode.Practice ? "Practice" : "Testing") + " Mode";
            this.Task = new Models.Task()
            {
                CreatedAt = DateTime.Now,
                UsedTime = 0,
                TestID = this.Test.ID,
                TestName = $"{this.Test.Name} - {mode} ({this.Test.OfficeApp} - {this.Test.OfficeVersion})",
                IsCompleted = false,
                Mode = (int)this.Mode,
                Points = new List<List<bool>>(),
                MarkCompletedQuestions = dict ?? new List<List<bool>> { new List<bool>() },
                UserName = this.UserName
            };

            if (!Repository.createTask(this.Task))
            {
                MessageBox.Show("Error");
                return;
            }

            Directory.CreateDirectory(this.WorkingDirPath);
            for (int i = 0; i < this.Test.Resources.Count; ++i)
            {
                File.Copy(Path.Combine(this.AppResourcesPath, this.Test.Resources[i]), this.WorkingFilePaths(i), true);
            }

        }

        protected void ShowLoading()
        {
            frmLoading.Show();
        }
        protected void CloseLoading()
        {
            frmLoading.Hide();
        }
        protected virtual BaseTest CreateTestChecker(string className)
        {
            BaseTest testChecker = null;
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = asm.GetType(className);
                if (type != null)
                    testChecker = Activator.CreateInstance(type) as BaseTest;
            }
            return testChecker;
        }
        protected virtual void CreateDirTemp()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string resourceDocumentsPath = Path.Combine(documentsPath, dirTemp);

            if (Directory.Exists(resourceDocumentsPath))
            {
                Directory.Delete(resourceDocumentsPath, true);
            }
            Directory.CreateDirectory(Path.Combine(documentsPath, dirTemp));
            foreach (string path in Directory.GetFiles(Path.Combine(this.AppResourcesPath, dirTemp), "*.*"))
            {
                File.Copy(path, path.Replace(Path.Combine(this.AppResourcesPath, dirTemp), resourceDocumentsPath), true);
            }
        }

        protected void LoadApp()
        {
            switch (this.Test.OfficeApp)
            {
                case "Word":
                    Word.Application wordApp = new Word.Application
                    {
                        Visible = true
                    };
                    this.Application = wordApp;
                    break;
                case "Excel":
                    Excel.Application excelApp = new Excel.Application
                    {
                        Visible = true
                    };
                    this.Application = excelApp;
                    break;
                case "PowerPoint":
                    break;
            }

            ResizeOfficeWindow();
        }

        protected void LoadFileOffice(int indexProject = 0)
        {
            try
            {
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application wordApp = this.Application as Word.Application;
                        if (wordApp.Documents.Count > 0)
                        {
                            wordApp.ActiveDocument.Close(Word.Enums.WdSaveOptions.wdSaveChanges);
                        }
                        wordApp.Documents.Open(this.WorkingFilePaths(indexProject));
                        break;
                    case "Excel":
                        Excel.Application excelApp = this.Application as Excel.Application;
                        if(excelApp.Workbooks.Count > 0)
                        {
                            excelApp.ActiveWorkbook.Close(true);
                        }
                        excelApp.Workbooks.Open(this.WorkingFilePaths(indexProject));
                        break;
                    case "PowerPoint":
                        break;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error("Loading Project - " + Test.ToString());
            }
        }

        protected void ResetProject(int indexProject)
        {
            File.Copy(Path.Combine(this.AppResourcesPath, this.Test.Resources[indexProject]), this.WorkingFilePaths(indexProject), true);

            try
            {
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application wordApp = this.Application as Word.Application;
                        if (wordApp.Documents.Count > 0)
                        {
                            wordApp.ActiveDocument.Close(Word.Enums.WdSaveOptions.wdDoNotSaveChanges);
                        }
                        wordApp.Documents.Open(this.WorkingFilePaths(indexProject));
                        break;
                    case "Excel":
                        Excel.Application excelApp = this.Application as Excel.Application;
                        if (excelApp.Workbooks.Count > 0)
                        {
                            excelApp.ActiveWorkbook.Close(false);
                        }
                        excelApp.Workbooks.Open(this.WorkingFilePaths(indexProject));
                        break;
                    case "PowerPoint":
                        break;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error("Reset Project - " + Test.ToString());
            }
        }

        protected void FrmClosed()
        {
            this.ParentForm.Show();
            (this.ParentForm as frmChooseTest).LoadTasks();
            try
            {
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application wordApp = this.Application as Word.Application;
                        wordApp?.Quit(Word.Enums.WdSaveOptions.wdDoNotSaveChanges);
                        wordApp?.Dispose();
                        break;
                    case "Excel":
                        Excel.Application excelApp = this.Application as Excel.Application;
                        excelApp?.Quit();
                        excelApp?.Dispose();
                        break;
                    case "PowerPoint":
                        break;
                }
            }
            catch (Exception)
            { }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmBaseRunTest
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmBaseRunTest";
            this.ResumeLayout(false);

        }
    }
}
