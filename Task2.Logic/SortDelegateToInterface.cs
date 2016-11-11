using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    public static class SortDelegateToInterface
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


        public static void BubbleSort(double[][] array, Comparison<double[]> comparer, bool byAsc = true)
        {
            SortAdapter sa = new SortAdapter(comparer);
            BubbleSort(array, sa, byAsc);
        }
    }

    public class SortAdapter : IComparer<double[]>
    {
        private readonly Comparison<double[]> _comparer;

        public SortAdapter(Comparison<double[]> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(double[] x, double[] y)
        {
            return _comparer(x, y);
        }
    }

}
