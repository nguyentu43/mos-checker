using System;
using System.Collections.Generic;
using System.Reflection;

namespace Checker.Base
{
    abstract public class BaseTest
    {
        public abstract int QuestionCount { get; }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public virtual List<bool> Points
        {
            get
            {
                List<bool> points = new List<bool>();
                for (int i = 1; i <= this.QuestionCount; ++i)
                {
                    MethodInfo methodInfo = this.GetType().GetMethod("Q" + i.ToString());
                    bool result = false;
                    try
                    {
                        result = ((bool)methodInfo.Invoke(this, null));
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);
                    }
                    finally
                    {
                        points.Add(result);
                    }
                }
                return points;
            }
        }
    }
}
