using Checker.Base;
using NExcel = NetOffice.ExcelApi;
using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Checker.Excel
{
    public class Test_4_2013 : BaseExcelTest
    {
        public override int QuestionCount => 31;

        private NExcel.Worksheet sheets(int index)
        {
            try
            {
                if (index == 1) return Workbook.Sheets["Gold Medalist"] as NExcel.Worksheet;
                if (index == 2) return Workbook.Sheets["Gold Top"] as NExcel.Worksheet;
                return Workbook.Sheets["Top 25"] as NExcel.Worksheet;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Q1()
        {
            return Workbook.Worksheets.Count == 3 && sheets(3) != null;
        }

        public bool Q2()
        {
            string cmp = "WE EXTEND NEW YEAR GREETINGS ,,,,,,RED CLOVER Per Cwt.,,,,,,Country Code,Name,#Gold,,,,,,,USA,United States, US,,GBR,Great Britain, GB,,JAM,Jamaica, JAM,,URS,Soviet Union, SU,,CAN,Canada, CA,,VIE,Viet Nam, VN,,THAI,Thailands, THAI,,BZL,Brazil, BR,,LAO,Laos, LAO,,CHI,China, CH,,TRI,Trinidad, TRI,,UEA,Germany, GER,,";
            NExcel.Worksheet worksheet = sheets(3);
            return Utils.Excel.RangeToString(worksheet?.Range("A1", "C19")) == cmp;
        }

        public bool Q3()
        {
            Regex regex = new Regex("<a:theme.*name=\"Office Theme\"><a:themeElements><a:clrScheme name=\"Green Yellow\">");
            return regex.IsMatch(ThemeXmlContent);
        }

        public bool Q4()
        {
            var properties = Workbook.BuiltinDocumentProperties as NetOffice.OfficeApi.DocumentProperties;
            if (properties == null) return false;
            foreach (var property in properties)
            {
                if(property.Name == "Subject")
                {
                    return property.Value?.ToString() == "Olympic";
                }
            }
            return false;
        }

        public bool Q5()
        {
            return sheets(1)?.Range("C2").Value.ToString() == "Host";
        }

        public bool Q6()
        {
            if (sheets(1)?.Range("B2").Value.ToString() != "Date") return false;

            for(int i = 1; i<=30; ++i)
            {
                if(sheets(1)?.Range("B" + (2 + i)).Value.ToString() != (1896 + 4 * (i - 1)).ToString())
                {
                    return false;
                }
            }
            return true;
        }

        public bool Q7()
        {
            return sheets(1)?.Range("C1").Value?.ToString() == "100 Metres Olympic Gold Medals";
        }

        public bool Q8()
        {
            return (sheets(1)?.Range("B2:F2").Style as NExcel.Style)?.NameLocal == "Accent3";
        }

        public bool Q9()
        {
            try
            {
                var name = sheets(1)?.Range("E3:E32").Name;
                return (name as NExcel.Name)?.NameLocal == "Code";
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Q10()
        {
            var format = sheets(1)?.Range("B2:F2").DisplayFormat;
            return format?.IndentLevel.ToString() == "1" && Convert.ToInt32(format?.HorizontalAlignment.ToString()) == (int) NExcel.Enums.XlHAlign.xlHAlignRight;
        }

        public bool Q11()
        {
            return sheets(1)?.Range("F3:F32").NumberFormatLocal.ToString() == "0.00";
        }

        public bool Q12()
        {
            return (bool)sheets(1)?.Rows[8].Hidden == (bool)sheets(1).Rows[14].Hidden
                == (bool)sheets(1)?.Rows[15].Hidden == (bool)sheets(1).Rows[33].Hidden
                == (bool)sheets(1)?.Rows[34].Hidden == true;
        }

        public bool Q13()
        {
            var range = sheets(1)?.Range("F3:F32");
            if (range?.FormatConditions?.Count < 1) return false;
            try
            {
                foreach (NExcel.IconSetCondition format in range.FormatConditions)
                {
                    foreach(var criterion in format.IconCriteria)
                    {
                        switch ((NExcel.Enums.XlIcon)Convert.ToInt32(criterion.Icon))
                        {
                            case NExcel.Enums.XlIcon.xlIconGreenFlag: continue;
                            case NExcel.Enums.XlIcon.xlIconRedFlag:
                                if(!(Convert.ToInt32(criterion.Value.ToString()) == 11
                            && Convert.ToInt32(criterion.Operator.ToString()) == (int)NExcel.Enums.XlFormatConditionOperator.xlGreaterEqual
                            && criterion.Type == NExcel.Enums.XlConditionValueTypes.xlConditionValueNumber))
                                {
                                    return false;
                                }
                                break;
                            case NExcel.Enums.XlIcon.xlIconYellowFlag:
                                if (!(Convert.ToInt32(criterion.Value.ToString()) == 10
                            && Convert.ToInt32(criterion.Operator.ToString()) == (int)NExcel.Enums.XlFormatConditionOperator.xlGreaterEqual
                            && criterion.Type == NExcel.Enums.XlConditionValueTypes.xlConditionValueNumber))
                                {
                                    return false;
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Q14()
        {
            return sheets(1)?.PageSetup.PrintArea == "$B$1:$F$32" && sheets(1)?.PageSetup.PrintGridlines == true;
        }

        public bool Q15()
        {
            int i = 0;
            foreach(var row in sheets(2).Range("C3:C14"))
            {
                if (row.Columns[1].Formula.ToString() != "=COUNTIF(Code, A" + (i + 3) + ")")
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        public bool Q16()
        {
            var tableStyle = sheets(2)?.Range("A2:C14").ListObject?.TableStyle as NExcel.TableStyle;
            return tableStyle?.NameLocal == "Table Style Medium 4";
        }

        public bool Q17()
        {
            var table = sheets(2)?.Range("A2:C14").ListObject;
            return table?.Name == "Countrycode";
        }

        public bool Q18()
        {
            var table = sheets(2)?.Range("A2:C14").ListObject;
            return table?.ShowTableStyleFirstColumn == true;
        }

        public bool Q19()
        {
            return sheets(2)?.Range("G2").Formula.ToString() == "=AVERAGE('Gold Medalist'!$F$3:$F$32)";
        }

        public bool Q20()
        {
            return sheets(2)?.Range("G3").Formula.ToString() == "=MAX('Gold Medalist'!F3:F32)";
        }

        public bool Q21()
        {
            return sheets(2)?.Range("G4").Formula.ToString() == "=MIN('Gold Medalist'!F3:F32)";
        }

        public bool Q22()
        {
            return sheets(2)?.Range("G5").Formula.ToString() == "=AVERAGEIF(Code, \"USA\", 'Gold Medalist'!F3:F32)";
        }

        public bool Q23()
        {
            return sheets(2)?.Range("F6").Formula.ToString() == "=CONCATENATE($H$1,\" - \",\"JAM\")";
        }

        public bool Q24()
        {
            return sheets(2)?.Range("G6").Formula.ToString() == "=RIGHT('Gold Medalist'!D32, 5)";
        }

        public bool Q25()
        {
            var autoFilter = sheets(2).AutoFilter;
            var filter = autoFilter?.Filters[3];
            var sort = autoFilter?.Sort;
            var b = checkFilter(filter);
            return checkFilter(filter) && checkSort(sort);
        }

        private static bool checkSort(NExcel.Sort sort)
        {
            if (sort?.SortFields.Count != 2) return false;
            if (!(sort?.SortFields[1].SortOn == NExcel.Enums.XlSortOn.xlSortOnValues && sort?.SortFields[1].Order == NExcel.Enums.XlSortOrder.xlDescending && sort?.SortFields[1].Key.AddressLocal == "$C$3:$C$14")) return false;
            if (!(sort?.SortFields[2].SortOn == NExcel.Enums.XlSortOn.xlSortOnValues && sort?.SortFields[2].Order == NExcel.Enums.XlSortOrder.xlAscending && sort?.SortFields[2].Key.AddressLocal == "$B$3:$B$14")) return false;
            return true;
        }

        private static bool checkFilter(NExcel.Filter filter)
        {
            if (filter?.On == true)
            {
                if (filter?.Operator == 0)
                {
                    return filter.Criteria1.ToString() == ">0" || filter.Criteria1.ToString() == "<>0";
                }
                else if (filter?.Operator == NExcel.Enums.XlAutoFilterOperator.xlFilterValues)
                {
                    List<string> list1 = new List<string> { "=1", "=16", "=2", "=3" };
                    ArrayList array = new ArrayList(filter.Criteria1 as ICollection);
                    return list1.SequenceEqual(array.Cast<string>().ToList());
                }
            }
            return false;
        }

        public bool Q26()
        {
            var chart = (Utils.Excel.GetChart(sheets(2), 1))?.Chart;
            try
            {
                var series = chart?.SeriesCollection(1) as NExcel.Series;
                return series?.ChartType == NExcel.Enums.XlChartType.xl3DPie 
                    && series?.FormulaLocal == "=SERIES('Gold Top'!$C$2,'Gold Top'!$A$3:$A$8,'Gold Top'!$C$3:$C$8,1)";
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Q27()
        {
            var chart = (Utils.Excel.GetChart(sheets(2), 1))?.Chart;
            return Convert.ToInt32(chart?.ChartStyle.ToString()) == 268;
        }

        public bool Q28()
        {
            var chart = (Utils.Excel.GetChart(sheets(2), 1))?.Chart;
            return chart?.ChartTitle.Text == "Gold Medals";
        }

        public bool Q29()
        {
            try
            {
                var hyperlinks = sheets(2).Range("H1").Hyperlinks;
                return hyperlinks[1]?.SubAddress == "'Gold Medalist'!B2";
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Q30()
        {
            foreach(var shape in sheets(2).Shapes)
            {
                if(shape.Type == NetOffice.OfficeApi.Enums.MsoShapeType.msoPicture)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Q31()
        {
            foreach (var shape in sheets(2).Shapes)
            {
                if (shape.Type == NetOffice.OfficeApi.Enums.MsoShapeType.msoPicture)
                {
                    return shape.AutoShapeType == NetOffice.OfficeApi.Enums.MsoAutoShapeType.msoShapeSnip2DiagRectangle;
                }
            }
            return false;
        }
    }
}
