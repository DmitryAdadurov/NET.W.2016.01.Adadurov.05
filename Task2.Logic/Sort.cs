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
                for (int j = 0; j < array.Length - 1; j++)
                {
                    double prevousRow = sortMethod(array[j]);
                    double currentRow = sortMethod(array[j + 1]);
                    if (byAsc)
                    {
                        if (currentRow < prevousRow)
                        {
                            double[] tempArray = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = tempArray;
                        }
                    }
                    else
                    {
                        if (currentRow > prevousRow)
                        {
                            double[] tempArray = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = tempArray;
                        }
                    }
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
