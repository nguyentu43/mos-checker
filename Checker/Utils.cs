using System;
using System.IO;
using System.IO.Compression;

namespace Checker
{
    public static class Utils
    {
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

            public static string GetThemeXmlContent(string filePath)
            {
                string xml = "";
                using (var archive = ZipFile.Open(filePath, ZipArchiveMode.Update))
                {
                    foreach(var entry in archive.Entries)
                    {
                        if(entry.Name == "theme1.xml")
                        {
                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {
                                xml = reader.ReadToEnd();
                            }
                        }
                    }
                }
                return xml;
            }
        }
        
    }
}
