using Checker.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OWord = NetOffice.WordApi;

namespace Checker.Word
{
    public class Project_5_Test_1_Office_2016 : BaseTest
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
            range.Find.MatchWildcards = true;
            if(range.Find.Execute("Fishing Derby a Success*local fish enhancement"))
            {
                var section = range.Sections.First;
                var cols = section.PageSetup.TextColumns;
                return cols[1].Width == 205.2f && cols[2].Width == 205.2f && cols.Spacing == 21.6f;
            }
            return false;
        }

        public bool Q2()
        {
            if (this.Document.Tables.Count == 0) return false;
            OWord.Table table = this.Document.Tables[1];
            return (table.Style as OWord.Style).NameLocal == "Grid Table 5 Dark - Accent 5";
        }

        public bool Q3()
        {
            var range = this.Document.Content;
            range.Find.MatchWildcards = true;
            if(range.Find.Execute("fabulous all year??") && range.Endnotes.Count > 0)
            {
                var endnote = range.Endnotes[1];
                return endnote.Range.Text == "Oregon fishing license required" &&
                       endnote.Range.EndnoteOptions.StartingNumber == 1 &&
                       endnote.Range.EndnoteOptions.NumberStyle == OWord.Enums.WdNoteNumberStyle.wdNoteNumberStyleArabic;
            }
            return false;
        }

        public bool Q4()
        {
            foreach(var shape in this.Document.Shapes)
            {
                if(shape.Type == NetOffice.OfficeApi.Enums.MsoShapeType.msoSmartArt)
                {
                    return shape.SmartArt.Color.Description == "Colorful Range - Accent Colors 5 to 6";
                }
            }
            return false;
        }

        public bool Q5()
        {
            foreach (var shape in this.Document.Shapes)
            {
                if (shape.Type == NetOffice.OfficeApi.Enums.MsoShapeType.msoSmartArt)
                {
                    return shape.SmartArt.Nodes.Count == 3 && shape.SmartArt.Nodes[3].TextFrame2.TextRange.Text == "Catch a Fish!";
                }
            }
            return false;
        }
    }
}
