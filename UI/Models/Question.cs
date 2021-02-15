using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Models
{
    public class Question
    {
        public int ID { get; set; }
        public int Index { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Help { get; set; }
        public string Group { get; set; }
    }
}
