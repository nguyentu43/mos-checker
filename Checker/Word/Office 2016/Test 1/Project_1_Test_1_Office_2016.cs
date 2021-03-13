using Checker.Base;
using System.Linq;
using OWord = NetOffice.WordApi;

namespace Checker.Word
{
    public class Project_1_Test_1_Office_2016 : BaseWordTest
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
            if (range.Find.Execute("Affordable Pricing*Contact Us", null, null, true))
            {
                OWord.InlineShapes inlineShapes = range.InlineShapes;
                if (inlineShapes.Count == 0) return false;
                OWord.InlineShape inlineShape = inlineShapes[1];
                return inlineShape.Type == OWord.Enums.WdInlineShapeType.wdInlineShapeEmbeddedOLEObject;
            }
            return false;
        }

        public bool Q2()
        {
            OWord.Range range = this.Document.Content;
            if (range.Find.Execute("Bicycle Advantages"))
            {
                foreach (OWord.Hyperlink hyperlink in range.Hyperlinks)
                {
                    return hyperlink.Address == "http://wikipedia.org/wiki/Bicycle" &&
                        hyperlink.Type == NetOffice.OfficeApi.Enums.MsoHyperlinkType.msoHyperlinkRange;
                }
            }
            return false;
        }

        public bool Q3()
        {
            OWord.Range range = this.Document.Content;
            if (range.Find.Execute("^mAffordable Pricing", null, null, true))
            {
                return true;
            }
            return false;
        }

        public bool Q4()
        {
            OWord.Range range = this.Document.Content;
            if (range.Find.Execute("Low maintenance*Lightweight and easy to store", null, null, true))
            {
                return range.ListFormat.ListType == OWord.Enums.WdListType.wdListPictureBullet;
            }
            return false;
        }

        public bool Q5()
        {
            OWord.Shape shape = this.Document.Content.ShapeRange.Last<OWord.Shape>();
            return shape.SoftEdge.Type == NetOffice.OfficeApi.Enums.MsoSoftEdgeType.msoSoftEdgeTypeNone &&
                shape.SoftEdge.Radius == 8.858268f;

        }
    }
}
