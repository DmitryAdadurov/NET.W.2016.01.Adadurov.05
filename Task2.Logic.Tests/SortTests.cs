using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2.Logic;

namespace Task2.Logic.Tests
{
    [TestFixture]
    public class SortTests
    {

        private static double[][] array = new double[][] { 
            new double[] { 20, 300, -12 },
            new double[] { 20, 300, -400, int.MaxValue },
            new double[] { 20, int.MinValue },
            new double[] { 20, 300, -12, 100, 0, 1594984465 },
            new double[] { 20 }
        };

        private static double[][] arraySumExpected = new double[][] { 
            new double[] { 20, 300, -400, int.MaxValue },           // sum: 
            new double[] { 20, 300, -12, 100, 0, 1594984465 },      // sum: 1 594 984 873
            new double[] { 20, 300, -12 },                          // sum: 308
            new double[] { 20 },                                     // sum: 20
            new double[] { 20, int.MinValue }
        };

        private static double[][] array3 = new double[][] { 
            new double[] { 20, 300, -12 },
            new double[] { 20, 300, -12, int.MaxValue },
            new double[] { 20, int.MinValue },
            new double[] { 20, 300, -12, 100, 0, 1594984465 },
            new double[] { 20 }
        };

        private static double[][] array4 = new double[][] { 
            new double[] { 20, 300, -12 },
            new double[] { 20, 300, -12, int.MaxValue },
            new double[] { 20, int.MinValue },
            new double[] { 20, 300, -12, 100, 0, 1594984465 },
            new double[] { 20 }
        };

        [Test]
        public void SortTest()
        {
            Sort.BubbleSort(array, byAsc: false, rowSum: true);
            Assert.IsTrue(IsEqual(array, arraySumExpected));
        }

        public bool IsEqual(double[][] actual, double[][] expected)
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
