using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Models
{
    public class Repository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.db");
        public static string TaskDbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "User.db");

        public static List<Test> getTests()
        {
            using (var db = new LiteDatabase(DbPath))
            {
                return db.GetCollection<Test>("tests").FindAll().ToList<Test>();
            }
        }

        public static Test getTestById(int ID)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                return db.GetCollection<Test>("tests").FindOne(x => x.ID == ID);
            }
        }

        public static List<Test> getTestsBy(string officeApp, string officeVersion)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                return db.GetCollection<Test>("tests").Find(x => (x.OfficeApp == officeApp && x.OfficeVersion == officeVersion)).ToList<Test>();
            }
        }

        public static List<Task> getTasks()
        {
            using (var db = new LiteDatabase(TaskDbPath))
            {
                return db.GetCollection<Task>("tasks").FindAll().ToList<Task>();
            }
        }

        public static bool createTask(Task task)
        {
            try
            {
                using (var db = new LiteDatabase(TaskDbPath))
                {
                    db.GetCollection<Task>("tasks").Insert(task);
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error("Create Task - " + task.ToString());
                return false;
            }
        }

        public static bool updateTask(Task task)
        {
            try
            {
                using (var db = new LiteDatabase(TaskDbPath))
                {
                    db.GetCollection<Task>("tasks").Update(task);
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error("Update Task - " + task.ToString());
                return false;
            }
        }

        public static bool createTest(Test test)
        {
            try
            {
                using (var db = new LiteDatabase(DbPath))
                {
                    db.GetCollection<Test>("tests").Insert(test);
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error("Create Test - " + test.ToString());
                return false;
            }
        }

        public static bool updateTest(Test test)
        {
            try
            {
                using (var db = new LiteDatabase(DbPath))
                {
                    db.GetCollection<Test>("tests").Update(test);
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error("Create Test - " + test.ToString());
                return false;
            }
        }

        public static bool removeTest(int id)
        {
            try
            {
                using (var db = new LiteDatabase(DbPath))
                {
                    return db.GetCollection<Test>("tests").Delete(id);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error("Remove Test - TestID: " + id.ToString());
                return false;
            }
        }
    }
}
