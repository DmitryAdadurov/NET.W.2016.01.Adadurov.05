using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2.Logic;
using Task2.Comparers;

namespace Task2.Logic.Tests
{
    [TestFixture]
    public class SortTests
    {
        

        [Test]
        public void SortTest_SumSort()
        {
            double[][] array = new double[][] { 
            new double[] { 20, 300, -12 },
            new double[] { 20, 300, -400, int.MaxValue },
            new double[] { 20, int.MinValue },
            new double[] { 20, 300, -12, 100, 0, 1594984465 },
            new double[] { 20 }
        };

        double[][] arraySumExpected = new double[][] { 
            new double[] { 20, 300, -400, int.MaxValue },           // sum: 
            new double[] { 20, 300, -12, 100, 0, 1594984465 },      // sum: 1 594 984 873
            new double[] { 20, 300, -12 },                          // sum: 308
            new double[] { 20 },                                     // sum: 20
            new double[] { 20, int.MinValue }
        };

            IComparer<double[]> sortMethod = new RowSum();

            //Sort.BubbleSort(array, sortMethod, byAsc: false);
            SortInterfaceViaDelegate.BubbleSort(array, sortMethod, byAsc: false);
            Assert.IsTrue(IsEqual(array, arraySumExpected));
        }

        [Test]
        public void SortTest_Delegate_SumSort()
        {
            double[][] array = new double[][] { 
            new double[] { 20, 300, -12 },
            new double[] { 20, 300, -400, int.MaxValue },
            new double[] { 20, int.MinValue },
            new double[] { 20, 300, -12, 100, 0, 1594984465 },
            new double[] { 20 }
        };

            double[][] arraySumExpected = new double[][] { 
            new double[] { 20, 300, -400, int.MaxValue },           // sum: 
            new double[] { 20, 300, -12, 100, 0, 1594984465 },      // sum: 1 594 984 873
            new double[] { 20, 300, -12 },                          // sum: 308
            new double[] { 20 },                                     // sum: 20
            new double[] { 20, int.MinValue }
        };

            SortMethodDelegate smd = new SortMethodDelegate(new RowSum().Compare);

            Sort.BubbleSort(array, smd, byAsc: false);
            Assert.IsTrue(IsEqual(array, arraySumExpected));
        }

        public delegate int SortMethodDelegate(double[] x, double[] y);

        [Test]
        public void SortTest_MaxRow()
        {

            double[][] array = new double[][] { 
            new double[] { 20, 300, -12 },
            new double[] { 20, 300, -400, int.MaxValue },
            new double[] { 20, int.MinValue },
            new double[] { 20, 300, -12, 100, 0, 1594984465 },
            new double[] { 20 }
        };


            double[][] arrayMaxExpected = new double[][] { 
            new double[] { 20, 300, -400, int.MaxValue },
            new double[] { 20, 300, -12, 100, 0, 1594984465 },
            new double[] { 20, 300, -12 },
            new double[] { 20, int.MinValue },
            new double[] { 20 }
        };

            IComparer<double[]> sortMethod = new RowMaxNum();

            Sort.BubbleSort(array, sortMethod, byAsc: false);
            Assert.IsTrue(IsEqual(array, arrayMaxExpected));
        }


        [Test]
        public void SortTest_MinRow()
        {
            double[][] array = new double[][] { 
            new double[] { 20, 300, -12 },
            new double[] { 20, 300, -400, int.MaxValue },
            new double[] { 20, int.MinValue },
            new double[] { 20, 300, -12, 100, 0, 1594984465 },
            new double[] { 20 }
        };


            double[][] arrayMinExpected = new double[][] { 
            new double[] { 20, int.MinValue },
            new double[] { 20, 300, -400, int.MaxValue },
            new double[] { 20, 300, -12 },
            new double[] { 20, 300, -12, 100, 0, 1594984465 },
            new double[] { 20 }
        };


            IComparer<double[]> sortMethod = new RowMinNum();

            Sort.BubbleSort(array, sortMethod, byAsc: false);
            Assert.IsTrue(IsEqual(array, arrayMinExpected));
        }


        private bool IsEqual(double[][] actual, double[][] expected)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                if (actual[i].Length != expected[i].Length)
                    return false;
                for (int j = 0; j < actual[i].Length; j++)
                {
                    if (actual[i][j] != expected[i][j])
                        return false;
                }
            }
            return true;
        }
    }
}
