using Checker.Base;
using System;
using System.Collections;
using System.Linq;
using NExcel = NetOffice.ExcelApi;

namespace Checker.Excel
{
    public class Mini_Test_1_2013 : BaseExcelTest
    {
        public override int QuestionCount => 8;

        private NExcel.Worksheet getSheet()
        {
            try
            {
                return Workbook.Sheets[1] as NExcel.Worksheet;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Q1()
        {
            var tab = getSheet().Tab;
            return getSheet().Name == "BẢNG CHIẾT TÍNH GIÁ THÀNH"
                && tab.ThemeColor == NExcel.Enums.XlThemeColor.xlThemeColorAccent2
                && Convert.ToDouble(tab.TintAndShade) == -0.249977111117893;
        }

        public bool Q2()
        {
            var rangeToString = Utils.Excel.RangeToString(getSheet().Range("A3:A9"));
            return rangeToString == "1,2,3,4,5,6,7,";
        }

        public bool Q3()
        {
            var a1 = getSheet().Range("A1");
            var a2_h2 = getSheet().Range("A2:H2");
            return (a1.Style as NExcel.Style).NameLocal == "Title"
                && (a2_h2.Style as NExcel.Style).NameLocal == "Heading 3";
        }

        public bool Q4()
        {
            var f3_f9 = getSheet().Range("F3:F9");
            var g3_g9 = getSheet().Range("G3:G9");
            return Utils.Excel.RangeToString(f3_f9) == "56250,112500,236000,167700,18375,159000,59125,"
                && Convert.ToBoolean(f3_f9.HasFormula) == true
                && Utils.Excel.RangeToString(g3_g9) == "1181250,2362500,4956000,3521700,385875,3339000,1241625,"
                && Convert.ToBoolean(g3_g9.HasFormula) == true;
        }

        public bool Q5()
        {
            var h3_h9 = getSheet().Range("H3:H9");
            return Utils.Excel.RangeToString(h3_h9) == "7912.5,10500,42000,8190,3692.5,6300,4536.5,"
                && Convert.ToBoolean(h3_h9.HasFormula) == true;
        }

        public bool Q6()
        {
            var d3_d9 = getSheet().Range("D3:D9");
            var f3_h9 = getSheet().Range("F3:H9");
            return d3_d9.NumberFormatLocal.ToString() == "$#,##0.00"
                && f3_h9.NumberFormatLocal.ToString() == "$#,##0.00";
        }

        public bool Q7()
        {
            var chart = Utils.Excel.GetChart(getSheet(), 1)?.Chart;
            try
            {
                var series = chart?.SeriesCollection(1) as NExcel.Series;
                return series?.ChartType == NExcel.Enums.XlChartType.xlLine
                    && series?.FormulaLocal == "=SERIES('BẢNG CHIẾT TÍNH GIÁ THÀNH'!$D$2,'BẢNG CHIẾT TÍNH GIÁ THÀNH'!$B$3:$B$9,'BẢNG CHIẾT TÍNH GIÁ THÀNH'!$D$3:$D$9,1)";
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Q8()
        {
            var chart = Utils.Excel.GetChart(getSheet(), 1)?.Chart;
            return chart?.ChartTitle.Text == "Biểu đồ đường đơn giá";
        }
    }
}
