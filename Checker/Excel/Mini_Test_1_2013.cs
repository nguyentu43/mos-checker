using Checker.Base;
using System;
using System.Collections;
using System.Linq;
using NExcel = NetOffice.ExcelApi;

namespace Checker.Excel
{
    public class Mini_Test_1_2013 : BaseExcelTest
    {
        public override int QuestionCount => 9;

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
            var range = getSheet().Range("B3:E9");
            var str = Utils.Excel.RangeToString(range);
            return str == "ĐƯỜNG ,KG,7500,150,TRỨNG ,CHỤC ,10000,225,TRỨNG CÚT,CHỤC ,8000,100,BƠ ,KG,40000,118,SỮA ,HỘP ,7800,430,MUỐI ,KG,3500,105,BỘT ,KG,4300,275,";
        }

        public bool Q3()
        {
            var rangeToString = Utils.Excel.RangeToString(getSheet().Range("A3:A9"));
            return rangeToString == "1,2,3,4,5,6,7,";
        }

        public bool Q4()
        {
            var a1 = getSheet().Range("A1");
            var a2_h2 = getSheet().Range("A2:H2");
            return (a1.Style as NExcel.Style).NameLocal == "Title"
                && (a2_h2.Style as NExcel.Style).NameLocal == "Heading 3";
        }

        public bool Q5()
        {
            var f3_f9 = getSheet().Range("F3:F9");
            var g3_g9 = getSheet().Range("G3:G9");
            return Utils.Excel.RangeToString(f3_f9) == "56250,112500,40000,236000,167700,18375,59125,"
                && Convert.ToBoolean(f3_f9.HasFormula) == true
                && Utils.Excel.RangeToString(g3_g9) == "1181250,2362500,840000,4956000,3521700,385875,1241625,"
                && Convert.ToBoolean(g3_g9.HasFormula) == true;
        }

        public bool Q6()
        {
            var h3_h9 = getSheet().Range("H3:H9");
            return Utils.Excel.RangeToString(h3_h9) == "7912.5,10500,8440,42000,8190,3692.5,4536.5,"
                && Convert.ToBoolean(h3_h9.HasFormula) == true;
        }

        public bool Q7()
        {
            var d3_d9 = getSheet().Range("D3:D9");
            var f3_h9 = getSheet().Range("F3:H9");
            return d3_d9.NumberFormatLocal.ToString() == "$#,##0.00"
                && f3_h9.NumberFormatLocal.ToString() == "$#,##0.00";
        }

        public bool Q8()
        {
            var chart = Utils.Excel.GetChart(getSheet(), 1)?.Chart;
            try
            {
                var series1 = chart?.SeriesCollection(1) as NExcel.Series;
                var series2 = chart?.SeriesCollection(2) as NExcel.Series;
                return series1?.ChartType == NExcel.Enums.XlChartType.xlLine
                    && (series1?.FormulaLocal == "=SERIES(,'BẢNG CHIẾT TÍNH GIÁ THÀNH'!$B$3:$B$9,'BẢNG CHIẾT TÍNH GIÁ THÀNH'!$D$3:$D$9,1)" || series1?.FormulaLocal == "=SERIES('BẢNG CHIẾT TÍNH GIÁ THÀNH'!$D$2,'BẢNG CHIẾT TÍNH GIÁ THÀNH'!$B$3:$B$9,'BẢNG CHIẾT TÍNH GIÁ THÀNH'!$D$3:$D$9,1)")
                    && series2?.ChartType == NExcel.Enums.XlChartType.xlLine
                    && (series2?.FormulaLocal == "=SERIES(,'BẢNG CHIẾT TÍNH GIÁ THÀNH'!$B$3:$B$9,'BẢNG CHIẾT TÍNH GIÁ THÀNH'!$H$3:$H$9,2)" || series2?.FormulaLocal == "=SERIES('BẢNG CHIẾT TÍNH GIÁ THÀNH'!$H$2,'BẢNG CHIẾT TÍNH GIÁ THÀNH'!$B$3:$B$9,'BẢNG CHIẾT TÍNH GIÁ THÀNH'!$H$3:$H$9,2)");
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Q9()
        {
            var chart = Utils.Excel.GetChart(getSheet(), 1)?.Chart;
            return chart?.ChartTitle.Text == "Biểu đồ đường đơn giá";
        }
    }
}
