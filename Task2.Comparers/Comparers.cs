using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Comparers
{
    public class RowSum : IComparer<double[]>
    {
        private double SortMethod(double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                checked
                {
                    sum += array[i];
                }
            }

            return sum;
        }

        public int Compare(double[] x, double[] y)
        {
            double sumX = SortMethod(x);
            double sumY = SortMethod(y);

            if (sumX > sumY)
                return 1;
            else if (sumX < sumY)
                return -1;
            else
                return 0;

        }
    }

    public class RowMaxNum : IComparer<double[]>
    {
        private double SortMethod(double[] array)
        {
            double max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }

        public int Compare(double[] x, double[] y)
        {
            double rowMaxNumX = SortMethod(x);
            double rowMaxNumY = SortMethod(y);

            if (rowMaxNumX > rowMaxNumY)
                return 1;
            else if (rowMaxNumX < rowMaxNumY)
                return -1;
            else
                return 0;
        }
    }


    public class RowMinNum : IComparer<double[]>
    {
        private double SortMethod(double[] array)
        {
            double min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }

        public int Compare(double[] x, double[] y)
        {
            double rowMinNumX = SortMethod(x);
            double rowMinNumY = SortMethod(y);

            if (rowMinNumX < rowMinNumY)
                return 1;
            else if (rowMinNumX > rowMinNumY)
                return -1;
            else
                return 0;
        }
    }

}
