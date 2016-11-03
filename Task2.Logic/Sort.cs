using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{

    public interface ISortMethod
    {
        double SortMethod(double[] array);
    }

    public class RowSum : ISortMethod
    {
        public double SortMethod(double[] array)
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
    }

    public class RowMaxNum : ISortMethod
    {
        public double SortMethod(double[] array)
        {
            double max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }
    }


    public class RowMinNum : ISortMethod
    {
        public double SortMethod(double[] array)
        {
            double min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }
    }

    public static class Sort
    {
        private delegate double SortMethod(double[] array);

        public static void BubbleSort(double[][] array, ISortMethod sortMethod, bool byAsc = true)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    double prevousRow = sortMethod.SortMethod(array[j]);
                    double currentRow = sortMethod.SortMethod(array[j + 1]);
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


        

        

        

        #endregion

    }
}
