using Checker.Base;
using OWord = NetOffice.WordApi;

namespace Checker.Word
{
    public class Project_7_Test_1_2016 : BaseWordTest
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
            return this.Document.WordOpenXML.Contains("<cp:contentStatus>Draft</cp:contentStatus>");
        }

        public bool Q2()
        {
            if (this.Document.Endnotes.Count == 0) return false;
            var endnote = this.Document.Endnotes[1];
            return endnote.Range.Text.Contains("§") && !endnote.Range.Text.Contains("Section");
        }

        public bool Q3()
        {
            var range = this.Document.Content;
            return range.Font.Size == 14f;
        }

        public bool Q4()
        {
            if (this.Document.Endnotes.Count == 0) return false;
            var endnote = this.Document.Endnotes[1];
            return endnote.Range.Font.Bold == 0 &&
                   endnote.Range.Font.AllCaps == 0 &&
                   endnote.Range.Font.ColorIndex == OWord.Enums.WdColorIndex.wdAuto;
        }

        public bool Q5()
        {
            foreach (var shape in this.Document.Shapes)
            {
                if (shape.Type == NetOffice.OfficeApi.Enums.MsoShapeType.msoTextBox && shape.TextFrame.TextRange.Text == "Discover Scuba\r")
                {
                    var font = shape.TextFrame.TextRange.Font;
                    return font.ColorIndex == OWord.Enums.WdColorIndex.wdTurquoise &&
                           font.Size == 36f &&
                           font.Fill.Type == NetOffice.OfficeApi.Enums.MsoFillType.msoFillSolid &&
                           font.TextShadow.Blur == 3f &&
                           font.TextShadow.Size == 1f &&
                           font.TextShadow.Transparency == 0.57f &&
                           font.TextShadow.Style == NetOffice.OfficeApi.Enums.MsoShadowStyle.msoShadowStyleOuterShadow;
                }
            }
            return false;
        }
    }
}
