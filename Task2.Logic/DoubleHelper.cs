using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task2.Logic
{
    public static class DoubleHelper
    {
        public static double[] Swap(this double[] x, ref double[] y)
        {
            double[] temp = y;
            y = x;
            return temp;
        }
    }
}
