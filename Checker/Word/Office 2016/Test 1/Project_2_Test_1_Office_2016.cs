using Checker.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OWord = NetOffice.WordApi;

namespace Checker.Word
{
    public class Project_2_Test_1_Office_2016 : BaseTest
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
            string findStr = "other more general communications protocols.^pSome Wireless network^pCommunications satellites";
            if (range.Find.Execute(findStr))
            {
                return true;
            }
            return false;
        }

        public bool Q2()
        {
            OWord.Section section = this.Document.Sections.First;
            return section.PageSetup.BottomMargin == 72f &&
                section.PageSetup.TopMargin == 72f &&
                section.PageSetup.LeftMargin == 86.4f &&
                section.PageSetup.RightMargin == 86.4f;
        }

        public bool Q3()
        {
            var style = this.Document.Styles[OWord.Enums.WdBuiltinStyle.wdStyleTitle];
            return style.Description == "Font: (Default) +Headings (Gill Sans MT), 36 pt, Font color: Text 2, All caps, Condensed by  0.75 pt\r    Line spacing:  Multiple 0.85 li, Space\r    After:  0 pt, Don't add space between paragraphs of the same style, Style: Linked, Show in the Styles gallery, Priority: 11\r    Based on: Normal\r    Following style: Normal";
        }

        public bool Q4()
        {
            OWord.Borders borders = this.Document.Sections.First.Borders;
            return borders.OutsideColorIndex == OWord.Enums.WdColorIndex.wdAuto &&
                borders.OutsideLineStyle == OWord.Enums.WdLineStyle.wdLineStyleSingle &&
                borders.OutsideLineWidth == OWord.Enums.WdLineWidth.wdLineWidth150pt;
        }

        public bool Q5()
        {
            if (this.Document.Content.ShapeRange.Count == 0) return false;
            float maxTop = 25f;
            OWord.Shape shape = this.Document.Content.ShapeRange.First<OWord.Shape>();
            return shape.WrapFormat.Type == OWord.Enums.WdWrapType.wdWrapTight &&
                shape.Type == NetOffice.OfficeApi.Enums.MsoShapeType.msoPicture &&
                shape.Top <= maxTop && shape.Left <= 0;
                ;

        }
    }
}
