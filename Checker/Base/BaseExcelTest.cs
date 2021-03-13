using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetOffice.ExcelApi;

namespace Checker.Base
{
    public abstract class BaseExcelTest: BaseTest
    {
        public Workbook Workbook { get; set; }

        public override List<bool> Points
        {
            get
            {
                if (this.Workbook == null) throw new Exception("Workbook not found");
                return base.Points;
            }

        }
    }
}
