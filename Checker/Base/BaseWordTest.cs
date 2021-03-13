using NetOffice.WordApi;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Checker.Base
{
    abstract public class BaseWordTest: BaseTest
    {
        public Document Document { get; set; }
        public override List<bool> Points
        {
            get
            {
                if (this.Document == null) throw new Exception("Document not found");
                return base.Points;
            }

        }
    }
}
