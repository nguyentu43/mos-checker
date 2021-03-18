using Checker.Base;
using NetOffice.OfficeApi;
using NetOffice.OfficeApi.Enums;
using NetOffice.WordApi;
using NetOffice.WordApi.Enums;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Checker.Word
{
    public class Test_1_2013 : BaseWordTest
    {
        public override int QuestionCount { get { return 29; } }

        public bool Q1()
        {
            Regex regex = new Regex("a:theme.*name=\"Ion\"");
            return regex.IsMatch(this.Document.WordOpenXML);
        }

        public bool Q2()
        {
            NetOffice.WordApi.ColorFormat foreColor = this.Document.Background.Fill.ForeColor;
            return foreColor.TintAndShade == 0.6f &&
                foreColor.ObjectThemeColor == WdThemeColorIndex.wdThemeColorAccent5 &&
                foreColor.SchemeColor == 1304 && foreColor.RGB == 14208696;
        }

        public bool Q3()
        {
            bool borderCheck = false;
            foreach (Section section in this.Document.Sections)
            {
                Borders borders = section.Borders;
                borderCheck = borders.DistanceFromTop == 24 &&
                    borders.DistanceFromBottom == 24 &&
                    borders.DistanceFromLeft == 24 &&
                    borders.DistanceFromRight == 24 &&
                    borders.OutsideLineStyle == WdLineStyle.wdLineStyleSingle &&
                    borders.OutsideLineWidth == WdLineWidth.wdLineWidth050pt &&
                    borders.OutsideColorIndex == WdColorIndex.wdAuto;
                if (!borderCheck) return false;
            }
            return borderCheck;
        }

        public bool Q4()
        {
            List<string> findStrList = new List<string>()
            {
                "Addictive personality*^m*For each toxin stored in the body, there is a counter-toxin provided by herbal leaves and roots",
                "Question & Answer with Dr. Nelson*^m*Question: I have a serious pain in my shoulder after swimming across the Atlantic",
                "Pet health is as important as ours. I hope these household remedies will reduce your veterinarian bill and increase the lifespan of our furry friends*^m*Question & Answer with Dr. Nelson"
            };

            foreach (string str in findStrList)
            {
                Range range = this.Document.Content;
                Find find = range.Find;
                if (!range.Find.Execute(str, null, null, true)) return false;
            }
            return true;
        }

        public bool Q5()
        {
            bool orientCheck = false;
            bool pageOneCheck = false;
            foreach (Section section in this.Document.Sections)
            {
                if (Convert.ToInt32(section.Range.Information(WdInformation.wdActiveEndPageNumber)) == 1)
                {
                    orientCheck = section.PageSetup.Orientation == WdOrientation.wdOrientLandscape;
                    pageOneCheck = orientCheck;
                }
                else
                {
                    orientCheck = section.PageSetup.Orientation == WdOrientation.wdOrientPortrait;
                }
                if (!pageOneCheck) return false;
                if (!orientCheck) return false;
            }
            return orientCheck;
        }

        public bool Q6()
        {
            Range range = this.Document.Content;
            if (range.Find.Execute("Dry mouth*Addictive personality", null, null, true))
            {
                return range.ListFormat.ListLevelNumber == 1 &&
                       range.ListFormat.ListString != "" &&
                       Convert.ToInt32(range.ListFormat.ListString[0]) == 61692 &&
                       range.Sections.PageSetup.TextColumns.Count == 3;

            }
            return false;
        }

        public bool Q7()
        {
            foreach (NetOffice.WordApi.Shape shape in this.Document.Shapes)
            {
                if (shape.Type == MsoShapeType.msoPicture &&
                    Convert.ToInt32(shape.Anchor.Information(WdInformation.wdActiveEndPageNumber)) == 1)
                {
                    return shape.WrapFormat.Type == WdWrapType.wdWrapSquare &&
                        shape.Left == (float)WdShapePosition.wdShapeRight &&
                        shape.Top == (float)WdShapePosition.wdShapeTop &&
                        shape.Line.Weight == 35 && shape.Line.ForeColor.RGB == 0;
                }
            }
            return false;
        }

        public bool Q8()
        {
            foreach (NetOffice.WordApi.Shape shape in this.Document.Shapes)
            {
                if (shape.Type == MsoShapeType.msoAutoShape &&
                    Convert.ToInt32(shape.Anchor.Information(WdInformation.wdActiveEndPageNumber)) == 1 &&
                    shape.AutoShapeType == MsoAutoShapeType.msoShapeSmileyFace)
                {
                    return shape.ShapeStyle == MsoShapeStyleIndex.msoShapeStylePreset1;
                }
            }
            return false;
        }

        public bool Q9()
        {
            foreach (NetOffice.WordApi.Shape shape in this.Document.Shapes)
            {
                if (shape.Type == MsoShapeType.msoAutoShape &&
                    Convert.ToInt32(shape.Anchor.Information(WdInformation.wdActiveEndPageNumber)) == 1 &&
                    shape.AutoShapeType == MsoAutoShapeType.msoShapeSmileyFace)
                {
                    Range nextLine = shape.Anchor.Next();
                    return nextLine.ShapeRange[1].TextFrame.TextRange.Text
                        == "1When you aren't toxic, you are happy!\r";
                }
            }
            return false;
        }

        public bool Q10()
        {
            if (this.Document.Tables.Count == 0) return false;
            Table table = this.Document.Tables[1];
            return table.Columns.Count == 4 && table.Rows.Count == 11;
        }

        public bool Q11()
        {
            if (this.Document.Tables.Count == 0) return false;
            Table table = this.Document.Tables[1];
            return table.Columns[4].Cells[6].Range.Text == "Constipation\r\a";
        }

        public bool Q12()
        {
            if (this.Document.Tables.Count == 0) return false;
            Table table = this.Document.Tables[1];
            Style style = table.Style as Style;
            return style.NameLocal == "Grid Table 4 - Accent 4";
        }

        public bool Q13()
        {
            if (this.Document.Tables.Count == 0) return false;
            Table table = this.Document.Tables[1];
            Row row = table.Rows[1];
            bool alignCheck = false;

            foreach (Cell cell in row.Cells)
            {
                alignCheck = cell.Range.Paragraphs.Alignment == WdParagraphAlignment.wdAlignParagraphCenter;
                if (!alignCheck) return false;
            }

            return alignCheck;
        }

        public bool Q14()
        {
            foreach (Style style in this.Document.Styles)
            {
                if (style.NameLocal == "Intense Emphasis")
                {
                    return style.Font.Size == 12 && (int)style.Font.Color == -587137063;
                }
            }
            return false;
        }

        public bool Q15()
        {
            bool styleCheck = true;
            (string, string)[] findStrList = new (string, string)[]
            {
                ("re you okay, Sparky?", "Title"),
                ("What about our pets?", "Intense Emphasis")
            };

            foreach ((string content, string style) in findStrList)
            {
                Range range = this.Document.Content;
                if (range.Find.Execute(content))
                {
                    styleCheck = (range.Style as Style).NameLocal == style;
                }
                else
                {
                    styleCheck = false;
                }

                if (!styleCheck) break;
            }

            return styleCheck;

        }

        public bool Q16()
        {
            foreach (NetOffice.WordApi.Shape shape in this.Document.Shapes)
            {
                if (shape.Type == MsoShapeType.msoPicture &&
                    Convert.ToInt32(shape.Anchor.Information(WdInformation.wdActiveEndPageNumber)) == 3)
                {
                    return shape.Height == 187.2f &&
                        shape.Width == 154.8f &&
                        shape.WrapFormat.Type == WdWrapType.wdWrapTight &&
                        shape.ThreeD.BevelTopDepth == 11f &&
                        shape.ThreeD.BevelTopInset == 11f &&
                        shape.ThreeD.BevelTopType == MsoBevelType.msoBevelDivot;
                }
            }

            return false;
        }

        public bool Q17()
        {
            Range range = this.Document.Content;
            if (range.Find.Execute("how would we survive?*re you okay", null, null, true))
            {
                NetOffice.WordApi.ShapeRange wordArt = range.ShapeRange;
                if (wordArt.Count == 0) return false;
                NetOffice.WordApi.TextFrame textFrame = wordArt.TextFrame;
                Font font = textFrame.TextRange.Font;
                return textFrame.TextRange.Text == "A\r" &&
                    wordArt.AutoShapeType == MsoAutoShapeType.msoShapeRectangle &&
                    font.ColorIndex == WdColorIndex.wdBlack &&
                    font.TextShadow.Style == MsoShadowStyle.msoShadowStyleOuterShadow &&
                    font.TextShadow.Type == MsoShadowType.msoShadow21 &&
                    font.TextShadow.ForeColor.RGB == 8421504 &&
                    font.TextShadow.Blur == 1 &&
                    font.TextShadow.Size == 1 &&
                    font.TextShadow.OffsetX == 2.12132025f &&
                    font.TextShadow.OffsetY == 2.12132025f &&
                    font.Line.ForeColor.RGB == 16777215 &&
                    font.Line.Weight == 0.75f &&
                    font.Line.DashStyle == MsoLineDashStyle.msoLineSolid &&
                    font.Line.Style == MsoLineStyle.msoLineSingle
                    ;
            }
            return false;
        }

        public bool Q18()
        {
            Range range = this.Document.Content;
            if (range.Find.Execute("lukewarm water"))
            {
                return range.Font.Underline == WdUnderline.wdUnderlineDouble;
            }
            return false;
        }

        public bool Q19()
        {
            Range range = this.Document.Content;
            if (range.Find.Execute("Question & Answer with Dr. Nelson"))
            {
                return (range.Style as Style).NameLocal == "Heading 1";
            }
            return false;
        }

        public bool Q20()
        {
            Section last = this.Document.Sections.Last;
            return last.PageSetup.BottomMargin == 72f && last.PageSetup.TopMargin == 72f &&
                last.PageSetup.LeftMargin == 144f && last.PageSetup.RightMargin == 144f;
        }

        public bool Q21()
        {
            Range range = this.Document.Content;
            if (range.Find.Execute("Question & Answer with Dr. Nelson*Question: I have a serious pain in my shoulder", null, null, true))
            {
                Footnotes footnotes = range.Footnotes;
                return footnotes.Count > 0 && footnotes[1].Range.Text == "Dr. William Nelson is nutritional education specialist from Hypothetical University. He also runs a private clinic and health care salon in the back of a recreational vehicle.";
            }
            return false;
        }

        public bool Q22()
        {
            Range range = this.Document.Content;
            if (range.Find.Execute("email all of your questions"))
            {
                return range.Hyperlinks.Count > 0 &&
                    range.Hyperlinks[1].Address == "mailto:williamnelson@hypotheticaluniversity.com";
            }
            return false;
        }

        public bool Q23()
        {
            if (this.Document.HasVBProject)
            {
                try
                {
                    this.Document.Application.Run("Emphasis");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public bool Q24()
        {
            Range range = this.Document.Content;
            List<string> t = new List<string>();
            int matchCount = 0;
            for (int i = 0; i < 5; i++)
            {
                if (range.Find.Execute("toxins"))
                {
                    if (range.Font.Bold != 0 && range.Font.Underline == WdUnderline.wdUnderlineSingle)
                    {
                        matchCount++;
                    }
                }
            }

            return matchCount == 5;
        }

        public bool Q25()
        {
            return this.Document.WordOpenXML.Contains("<w:t>[Publish Date]</w:t>");
        }

        public bool Q26()
        {
            bool footerCheck = false;
            foreach (Section section in this.Document.Sections)
            {
                HeadersFooters headersFooters = section.Footers;
                HeaderFooter headerFooter = headersFooters[WdHeaderFooterIndex.wdHeaderFooterPrimary];
                footerCheck = (headerFooter.IsHeader == false &&
                    headerFooter.Shapes.Count > 0 &&
                    headerFooter.Shapes[1].AutoShapeType == MsoAutoShapeType.msoShapeCurvedDownRibbon);
                if (!footerCheck) return false;
            }
            return footerCheck;
        }

        public bool Q27()
        {
            foreach (DocumentProperty property in this.Document.BuiltInDocumentProperties as DocumentProperties)
            {
                if (property.Name == "Title")
                {
                    return property.Value.ToString() == "Health Newsletter";
                }
            }
            return false;
        }

        public bool Q28()
        {
            if (this.Document.ProtectionType == WdProtectionType.wdAllowOnlyRevisions && this.Document.TrackMoves == true)
            {
                this.Document.Unprotect("GMetrix");
                return this.Document.ProtectionType == WdProtectionType.wdNoProtection;
            }
            return false;
        }

        public bool Q29()
        {
            Options options = this.Document.Application.Options;
            return options.AllowOpenInDraftView &&
                  options.PrintProperties &&
                  !options.CheckSpellingAsYouType;
        }
    }
}
