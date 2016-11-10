using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    public static class Sort
    {
        public static void BubbleSort(double[][] array, IComparer<double[]> sortMethod, bool byAsc = true)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (sortMethod.Compare(array[j], array[j+1]) < 0)
                    {
                        array[j] = array[j].Swap(ref array[j + 1]);
                    }
                }

            }

            if (byAsc)
                array = array.Reverse().ToArray();
        }


        public static void BubbleSort(double[][] array, Delegate sortMethod, bool byAsc = true)
        {
            if (sortMethod.Target is IComparer<double[]>)
                BubbleSort(array, sortMethod.Target as IComparer<double[]>, byAsc);
        }
    }
}
