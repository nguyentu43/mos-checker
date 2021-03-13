using System.Collections.Generic;

namespace Models
{
    public class Test
    {
        public int ID { get; set; }
        public string OfficeVersion { get; set; }
        public string OfficeApp { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public string Description { get; set; }
        public List<string> Resources { get; set; }
        public int LimitTime { get; set; }

        public Test()
        {
            LimitTime = 50;   
        }

        public string ResourcesPath
        {
            get
            {
                return System.IO.Path.Combine("Resources", this.OfficeVersion, this.OfficeApp, this.Name);
            }
        }
    }
}
