using Checker.Base;
using System;
using System.Collections.Generic;
using OWord = NetOffice.WordApi;

namespace Checker.Word
{
    public class Project_3_Test_1_Office_2016 : BaseWordTest
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
            bool check = false;
            OWord.Range range = this.Document.Content;
            if (range.Find.Execute("Our Most Popular Flavors*Contact Us", null, null, true))
            {
                OWord.Table table = range.TopLevelTables[1];
                List<string> list = new List<string>()
                {
                    "Chocolate Heaven Splurge\r\a\r\a",
                    "Fruit Heaven Splurge\r\a\r\a",
                    "Jawbreaker Mint\r\a\r\a",
                    "Pecan and Peanut Truffle\r\a\r\a",
                    "Whole Vanilla Bean Chunk\r\a\r\a"
                };

                for (int i = 1; i <= list.Count; ++i)
                {
                    check = table.Rows[i].Range.Text == list[i - 1];
                    if (!check)
                    {
                        return false;
                    }
                }
            }
            return check;
        }

        public bool Q2()
        {
            OWord.Range range = this.Document.Content;
            if (range.Find.Execute("The Party People*I Scream, U Scream", null, null, true))
            {
                return range.ListFormat.ListType == OWord.Enums.WdListType.wdListBullet;
            }
            return false;
        }

        public bool Q3()
        {
            foreach (OWord.Shape shape in this.Document.Shapes)
            {
                if (shape.Type == NetOffice.OfficeApi.Enums.MsoShapeType.msoTextBox)
                {
                    try
                    {
                        var prevRow = shape.Anchor.Previous(OWord.Enums.WdUnits.wdRow);
                        return shape.TextFrame.TextRange.Text == "We specialize in custom flavors!\r" &&
                               prevRow.Text == "Ice Cream Shop\r\a\r\a";
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool Q4()
        {
            foreach (OWord.InlineShape shape in this.Document.InlineShapes)
            {
                OWord.ShadowFormat shadow = shape.Shadow;
                return shadow.Blur == 5 &&
                       shadow.Transparency == 0.5f &&
                       shadow.OffsetX == -2.828427f &&
                       shadow.OffsetY == -2.828427f &&
                       shadow.Style == NetOffice.OfficeApi.Enums.MsoShadowStyle.msoShadowStyleInnerShadow &&
                       shadow.RotateWithShape == NetOffice.OfficeApi.Enums.MsoTriState.msoTriStateMixed;
            }
            return false;
        }

        public bool Q5()
        {
            foreach (OWord.Shape shape in this.Document.Shapes)
            {
                if (shape.Type == NetOffice.OfficeApi.Enums.MsoShapeType.msoPicture)
                {
                    OWord.ThreeDFormat threeDFormat = shape.ThreeD;
                    return threeDFormat.PresetCamera == NetOffice.OfficeApi.Enums.MsoPresetCamera.msoCameraIsometricOffAxis1Right &&
                           threeDFormat.RotationX == 26.0000324f &&
                           threeDFormat.RotationY == 18f;
                }
            }
            return false;
        }
    }
}
