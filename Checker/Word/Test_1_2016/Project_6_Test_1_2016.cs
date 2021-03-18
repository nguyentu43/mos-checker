using Checker.Base;
using System.Collections.Generic;
using OWord = NetOffice.WordApi;

namespace Checker.Word
{
    public class Project_6_Test_1_2016 : BaseWordTest
    {
        public override int QuestionCount
        {
            get
            {
                return 5;
            }
        }

        public bool Q1()
        {
            return this.Document.ActiveWindow.View.ShowAll;
        }

        public bool Q2()
        {
            return this.Document.RemovePersonalInformation;
        }

        public bool Q3()
        {
            foreach (var shape in this.Document.Shapes)
            {
                if ((int)shape.Anchor.Information(OWord.Enums.WdInformation.wdActiveEndPageNumber) == 3)
                {
                    return shape.TextFrame.TextRange.Text == "“Business is the driving force of this world, and only by embracing it can we become a truly unified planet.”\r-Craig Stronin, FusionTomo CEO\r\r";
                }
            }
            return false;
        }

        public bool Q4()
        {
            List<string> list = new List<string>()
            {
                "Vision", "Reliability", "Adaptability",
                "Family"
            };

            foreach (var item in list)
            {
                var find = this.Document.Content.Find;
                find.Style = OWord.Enums.WdBuiltinStyle.wdStyleStrong;
                find.Format = true;
                var result = find.Execute(item);
                if (!result) return false;
            }
            return true;
        }

        public bool Q5()
        {
            if (this.Document.Tables.Count == 0) return false;
            var cols = this.Document.Tables[1].Columns;
            return cols[3].Width == 129.6f;
        }
    }
}
