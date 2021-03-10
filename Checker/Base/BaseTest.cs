using NetOffice.WordApi;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Checker.Base
{
    abstract public class BaseTest
    {
        public Document Document { get; set; }
        public virtual List<bool> Points
        {
            get
            {
                if (this.Document == null) throw new Exception("Document not found");
                List<bool> points = new List<bool>();
                for (int i = 1; i <= this.QuestionCount; ++i)
                {
                    MethodInfo methodInfo = this.GetType().GetMethod("Q" + i.ToString());
                    bool result = false;
                    try
                    {
                        result = ((bool)methodInfo.Invoke(this, null));
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        points.Add(result);
                    }
                }
                return points;
            }

        }
        public abstract int QuestionCount { get; }
    }
}
