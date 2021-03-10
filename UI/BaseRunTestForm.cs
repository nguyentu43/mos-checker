using Checker.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Word = NetOffice.WordApi;

namespace GUI
{
    public abstract class BaseRunTestForm : Form
    {
        protected const string dirTemp = "GMetrixTemplates";
        public Test Test { get; }
        public Models.Enums.TestMode Mode { get; }
        public new Form ParentForm { get; }
        public object Application { get; set; }
        public Models.Task Task { get; set; }
        public string UserName { get; set; }
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

        public BaseRunTestForm(Form parent, string userName, Test test, Models.Enums.TestMode mode, Models.Task resumeTask = null)
        {
            this.Test = test;
            this.Mode = mode;
            this.ParentForm = parent;
            this.UserName = userName;
        }

        protected virtual void resizeForm()
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            this.Left = 0;
            this.Top = Convert.ToInt32(workingArea.Height * 0.66);
            this.Height = Convert.ToInt32(workingArea.Height * 0.35);
            this.Width = workingArea.Width;
        }

        protected virtual void resizeOfficeWindow()
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            switch (this.Test.OfficeApp)
            {
                case "Word":
                    Word.Application application = this.Application as Word.Application;
                    application.WindowState = Word.Enums.WdWindowState.wdWindowStateNormal;
                    application.Top = 0;
                    application.Left = 0;
                    application.Height = Convert.ToInt32(workingArea.Height * 0.49f);
                    application.Width = Convert.ToInt32(workingArea.Width * 0.75f);

                    break;
                case "Excel":
                    break;
                case "PowerPoint":
                    break;
            }

        }

        protected virtual void createTask(List<List<bool>> dict = null)
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
                MarkCompletedQuestions = dict ?? new List<List<bool>>(),
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

        protected virtual BaseTest createTestChecker(string className)
        {
            List<BaseTest> list = new List<BaseTest>();
            Checker.Base.BaseTest testChecker = null;
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = asm.GetType(className);
                if (type != null)
                    testChecker = Activator.CreateInstance(type) as Checker.Base.BaseTest;
            }
            return testChecker;
        }
        protected virtual void createDirTemp()
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

        protected void loadApp()
        {
            switch (this.Test.OfficeApp)
            {
                case "Word":
                    Word.Application application = new Word.Application();
                    application.Visible = true;
                    this.Application = application;
                    break;
                case "Excel":
                    break;
                case "PowerPoint":
                    break;
            }

            resizeOfficeWindow();
        }

        protected void resetProject(int indexProject)
        {
            File.Copy(Path.Combine(this.AppResourcesPath, this.Test.Resources[indexProject]), this.WorkingFilePaths(indexProject), true);

            try
            {
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application application = this.Application as Word.Application;
                        if (application.Documents.Count > 0)
                        {
                            application.ActiveDocument.Close(Word.Enums.WdSaveOptions.wdDoNotSaveChanges);
                        }
                        application.Documents.Open(this.WorkingFilePaths(indexProject));

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

        protected void formClosed()
        {
            this.ParentForm.Show();
            (this.ParentForm as frmChooseTest).LoadTasks();
            try
            {
                switch (this.Test.OfficeApp)
                {
                    case "Word":
                        Word.Application application = this.Application as Word.Application;

                        if (application != null)
                        {
                            application.Quit(Word.Enums.WdSaveOptions.wdDoNotSaveChanges);
                            application.Dispose();
                        }
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
    }
}
