using Checker.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OWord = NetOffice.WordApi;

namespace Checker.Word
{
    public class Project_4_Test_1_Office_2016 : BaseTest
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
            OWord.Range range = this.Document.Content;
            range.Find.Format = true;
            range.Find.Style = OWord.Enums.WdBuiltinStyle.wdStyleHeading2;
            if(range.Find.Execute("Moab, Utah") && range.Bookmarks.Count > 0)
            {
                var bookmark = range.Bookmarks[1];
                return bookmark.Name == "Moab";
            }
            return false;
        }

        public bool Q2()
        {
            OWord.Range range = this.Document.Content;
            return !range.Find.Execute("climbing");
        }

        public bool Q3()
        {
            if (this.Document.Tables.Count == 0) return false;
            OWord.Table table = this.Document.Tables[1];
            if(table.Rows.Count == 4 && table.Columns.Count == 2)
            {
                List<string> list = new List<string>()
                {
                    "Mountain Locations\r\aPrice\r\a\r\a",
                    "AreaBFE, Moab, UT\r\aFree\r\a\r\a",
                    "Battle Rock Off Road Park, Cortez CO\r\aUnkown\r\a\r\a",
                    "Ram Off Road Park, Colorado Springs, CO\r\aStarting at $10 (Depending on equipment)\r\a\r\a"
                };
                foreach(var row in table.Rows)
                {
                    if (row.Range.Text != list[row.Index - 1])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool Q4()
        {
            OWord.Range range = this.Document.Content;
            if(range.Find.Execute("Jeep and varients*Mercedes Unimog", null, null, true))
            {
                var listFormat = range.ListFormat;
                return listFormat.ListType == OWord.Enums.WdListType.wdListBullet &&
                       listFormat.ListString == "";
            }
            return false;
        }

        public bool Q5()
        {
            foreach(var paragraph in this.Document.Paragraphs)
            {
                return (bool) paragraph.Range.Information(OWord.Enums.WdInformation.wdInCoverPage);
            }
            return false;
        }
    }
}
