using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Checker
{
    public class Utils
    {
        public static bool nearlyEqual(float a, float b, float epsilon = float.Epsilon)
        {
            File.AppendAllText(@"D:\test.txt", Convert.ToString(a) + " = " + Convert.ToString(b) + "\n");
            //return Convert.ToString(a) == Convert.ToString(b);
            float diff = Math.Abs(a - b);
            return diff <= epsilon;
        }
    }
}
