using NUnit.Framework;

namespace Task1.Logic.Tests
{
    [TestFixture]
    public class CalculationsTests
    {

        static object[] TestNumbers = {
                                                       new object[] { 21, new int[] { 1071, 462 } },
                                                       new object[] { 20, new int[] { -20, 400 } },
                                                       new object[] { 1, new int[] { int.MaxValue, 1569 } },
                                                       new object[] { 6, new int[]{ 78, 294, 570, 36 } },
                                                       new object[] { 5, new int[] { 5, 0 } },
                                                       new object[] { 15, new int[] { 0, 15 } },
                                                       new object[] { 5, new int[] { -5, 10 } },
                                                       new object[] { 24, new int[] { 24, 24, 24, 24 } },
                                                   };

        [Test, TestCaseSource("TestNumbers")]
        public void EuclideanGCD(int expected, params int[] numbers)
        {
            int actual = Calculations.EuclideanGCD(numbers);
            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource("TestNumbers")]
        public void BinaryGCD(int expected, params int[] numbers)
        {
            int actual = Calculations.BinaryGCD(numbers);
            Assert.AreEqual(expected, actual);
        }
    }
}
