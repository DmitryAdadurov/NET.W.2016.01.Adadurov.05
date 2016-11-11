using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public class Calculations
    {
        public static int EuclideanGCD(params int[] numbers)
        {
            int? temp = CheckArray(numbers, FindGCD);

            if (temp != null)
                return Convert.ToInt32(temp);

            return Iterator(FindGCD, numbers);
        }


        public static int BinaryGCD(params int[] numbers)
        {
            int? temp = CheckArray(numbers, BinaryFindGCD);

            if (temp != null)
                return Convert.ToInt32(temp);

            return Iterator(BinaryFindGCD, numbers);
        }

        #region Private Methods

        private static int Iterator(Func<int, int, int> method, int[] numbers)
        {
            int gcd = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                gcd = method(gcd, numbers[i]);
            }
            return gcd;
        }

        private static int BinaryFindGCD(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

            int shift;

            if (first == 0)
                return second;

            if (second == 0)
                return first;


            for (shift = 0; ((first | second) & 1) == 0; ++shift)
            {
                first >>= 1;
                second >>= 1;
            }


            while ((first & 1) == 0)
                first >>= 1;


            do
            {
                while ((second & 1) == 0)
                    second >>= 1;
                if (first > second)
                {
                    int t = second;
                    second = first;
                    first = t;
                }
                second = second - first;
            } while (second != 0);


            return first << shift;

        }


        private static int FindGCD(int first, int second)
        {
            if (first == 0 && second == 0)
                throw new ArgumentException();


            if (first < second)
            {
                int temp = first;
                first = second;
                second = temp;
            }

            if (first == 0)
                return Math.Abs(second);

            if (second == 0)
                return first;

            int remainder, q;

            do
            {
                remainder = first % second;
                q = first / second;
                first = second;
                second = remainder;
            } while (remainder != 0);

            return Math.Abs(first);
        }


        private static int? CheckArray(int[] numbers, Func<int, int, int> cm)
        {
            if (numbers == null)
                throw new ArgumentNullException();

            if (numbers.Length == 0)
                throw new ArgumentException();

            if (numbers.Length == 1)
                return numbers[0];

            if (numbers.Length == 2)
                return cm(numbers[0], numbers[1]);

            return null;
        }

        #endregion


    }
}
