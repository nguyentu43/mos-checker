using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using GUI.Models;
using System.Linq;
using System.IO;

namespace GUI
{
    public class Repository
    {
        public static string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.db");
        public static List<Test> getTests()
        {
            using(var db = new LiteDatabase(Repository.DbPath))
            {
                return db.GetCollection<Test>("tests").FindAll().ToList<Test>();
            }
        }

        public static Test getTestById(int ID)
        {
            using (var db = new LiteDatabase(Repository.DbPath))
            {
                return db.GetCollection<Test>("tests").FindOne(x => x.ID == ID);
            }
        }

        public static List<Test> getTestsBy(string officeApp, string officeVersion)
        {
            using (var db = new LiteDatabase(Repository.DbPath))
            {
                return db.GetCollection<Test>("tests").Find(x => (x.OfficeApp == officeApp && x.OfficeVersion == officeVersion)).ToList<Test>();
            }
        }

        public static List<Task> getTasks()
        {
            using (var db = new LiteDatabase(Repository.DbPath))
            {
                return db.GetCollection<Task>("tasks").FindAll().ToList<Task>();
            }
        }

        public static bool createTask(Task task)
        {
            try
            {
                using (var db = new LiteDatabase(Repository.DbPath))
                {
                    db.GetCollection<Task>("tasks").Insert(task);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool updateTask(Task task)
        {
            try
            {
                using (var db = new LiteDatabase(Repository.DbPath))
                {
                    db.GetCollection<Task>("tasks").Update(task);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
