using System;
using System.IO;
using System.IO.Compression;

namespace Checker
{
    public static class Utils
    {
        public static bool nearlyEqual(float a, float b, float epsilon = float.Epsilon)
        {
            File.AppendAllText(@"D:\test.txt", Convert.ToString(a) + " = " + Convert.ToString(b) + "\n");
            //return Convert.ToString(a) == Convert.ToString(b);
            float diff = Math.Abs(a - b);
            return diff <= epsilon;
        }

        public static class Excel
        {
            public static string RangeToString(NetOffice.ExcelApi.Range range)
            {
                if (range == null) return "";
                string str = "";
                foreach (var row in range.Rows)
                {
                    foreach (var col in row.Columns)
                    {
                        str += col.Value + ",";
                    }
                }
                return str;
            }

            public static NetOffice.ExcelApi.ChartObject GetChart(NetOffice.ExcelApi.Worksheet sheet, int index)
            {
                try
                {
                    return sheet.ChartObjects(index) as NetOffice.ExcelApi.ChartObject;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        
    }
}
