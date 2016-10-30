using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    public static class Sort
    {
        private delegate double SortMethod(double[] array);

        public static void BubbleSort(double[][] array, bool byAsc = true, bool rowSum = false, bool rowMax = false, bool rowMin = false)
        {
            SortMethod sortMethod = RowSum;

            if (rowMax)
                sortMethod = RowMaxNum;

            if (rowMin)
                sortMethod = RowMinNum;

            for (int i = 0; i < array.Length - 1; i++)
            {
                double prevousRow = RowSum(array[i]);
                int swapPlace = i;
                for (int j = 1; j < array.Length; j++)
                {
                    if (byAsc)
                    {
                        if (sortMethod(array[j]) < prevousRow)
                            swapPlace = j;
                    }
                    else
                    {
                        if (sortMethod(array[j]) > prevousRow)
                            swapPlace = j;
                    }
                }

                if (swapPlace != i)
                {
                    double[] tempArray = array[swapPlace];
                    array[swapPlace] = array[i];
                    array[i] = tempArray;
                }

            }
        }


        #region Private Methods

        private static double RowSum(double[] array)
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

        private static double RowMaxNum(double[] array)
        {
            double max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }

        private static double RowMinNum(double[] array)
        {
            double min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }       

        #endregion

    }
}
