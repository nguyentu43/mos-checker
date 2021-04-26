using System.Collections.Generic;

namespace Models
{
    public class Test
    {
        public int ID { get; set; }
        public string OfficeVersion { get; set; }
        public string OfficeApp { get; set; }
        public string Name { get; set; }
        public Dictionary<string, List<Question>> Questions { get; set; }
        public string Description { get; set; }
        public List<string> Resources { get; set; }
        public int LimitTime { get; set; }

        public override string ToString()
        {
            return string.Format("Test ID: {0} - Name: {1} - Ver: {2} - App: {3}", ID, Name, OfficeVersion, OfficeApp);
        }

        public Test()
        {
            LimitTime = 50;
        }

        public string ResourcesPath
        {
            get
            {
                return System.IO.Path.Combine("Resources", this.OfficeApp, this.Name.Replace(' ', '_') + "_" + this.OfficeVersion);
            }
        }
    }
}
