using System;
using System.Diagnostics;
using System.Threading;

namespace NumbersManipulations
{
    /// <summary>
    /// Class GCD
    /// </summary>
    public class GCD
    {
        /// <summary>
        /// Method calculates the greatest common divisor using Euclidean algorithm for two integers.
        /// </summary>
        /// <param name="first">first integer</param>
        /// <param name="second">second integer</param>
        /// <returns>GCD of two integers</returns>
        /// <exception cref="ArgumentException">Thrown when first and second numbers are zero.</exception>
        public static int EuclideanCalculation(int first, int second)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Invalid input values: both perameters can not be zero");
            }

            if (first == 0)
            {
                return Math.Abs(second);
            }

            if (second == 0)
            {
                return Math.Abs(first);
            }

            if (first < 0)
            {
                first = -first;
            }

            if (second < 0)
            {
                second = -second;
            }

            if (first == second)
            {
                return first;
            }

            if (first == 1 || second == 1)
            {
                return 1;
            }

            while (first != second)
            {
                if (first > second)
                {
                    first = first - second;
                }
                else
                {
                    second = second - first;
                }
            }

            return first;
        }

        /// <summary>
        /// Method calculates the greatest common divisor using Euclidean algorithm for multiple arguments.
        /// </summary>
        /// <param name="numbers">array of numbers</param>
        /// <returns>GCD of the array of numbers</returns>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int EuclideanCalculation(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException("Array is empty", nameof(numbers));
            }

            int gcd = numbers[0];
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                gcd = EuclideanCalculation(numbers[i], numbers[i + 1]);
            }

            return gcd;
        }

        /// <summary>
        /// Method calculates the GCD using Euclidean algorithm for two integers and determines the time required to complete the calculation.
        /// </summary>
        /// <param name="first">first integer</param>
        /// <param name="second">second integer</param>
        /// <param name="timeMeasured">measured time</param>
        /// <returns>GCD of two integers and determine the time for calculations</returns>
        public static int EuclideanCalculation(int first, int second, out double timeMeasured)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var resultGCD = EuclideanCalculation(first, second);
            stopWatch.Stop();
            timeMeasured = stopWatch.ElapsedMilliseconds;
            return resultGCD;
        }

        /// <summary>
        /// Method calculates the GCD using Euclidean algorithm for multiple arguments and determines the time required to complete the calculation.
        /// </summary>
        /// <param name="timeMeasured">measured tim</param>
        /// <param name="numbers">array of numbers</param>
        /// <returns>GCD of the array of numbers and determine the time for calculations</returns>
        public static int EuclideanCalculation(out double timeMeasured, params int[] numbers)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var resultGCD = EuclideanCalculation(numbers);
            stopWatch.Stop();
            timeMeasured = stopWatch.ElapsedMilliseconds;
            return resultGCD;
        }

        /// <summary>
        /// Method calculates the greatest common divisor using Binary GCD algorithm for two integers.
        /// </summary>
        /// <param name="first">first integer</param>
        /// <param name="second">second integer</param>
        /// <returns>GCD of two integers</returns>
        /// <exception cref="ArgumentException">Thrown when first and second numbers are zero.</exception>
        public static int BinaryGCDCalculation(int first, int second)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Invalid input values: both perameters can not be zero");
            }

            if (first == 0)
            {
                return Math.Abs(second);
            }

            if (second == 0)
            {
                return Math.Abs(first);
            }

            if (first < 0)
            {
                first = -first;
            }

            if (second < 0)
            {
                second = -second;
            }

            if (first == second)
            {
                return first;
            }

            if (first % 2 == 0 && second % 2 == 0)
            {
                return 2 * BinaryGCDCalculation(first / 2, second / 2);
            }

            if (first % 2 == 0 && second % 2 != 0)
            {
                return BinaryGCDCalculation(first / 2, second);
            }

            if (first % 2 != 0 && second % 2 == 0)
            {
                return BinaryGCDCalculation(first, second / 2);
            }

            if (first % 2 != 0 && second % 2 != 0 && second > first)
            {
                return BinaryGCDCalculation((second - first) / 2, first);
            }

            return BinaryGCDCalculation((second - first) / 2, second);           
        }

        /// <summary>
        /// Method calculates the greatest common divisor using Binary GCD algorithm for multiple arguments.
        /// </summary>
        /// <param name="numbers">array of numbers</param>
        /// <returns>GCD of the array of numbers</returns>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int BinaryGCDCalculation(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException("Array is empty", nameof(numbers));
            }

            int gcd = numbers[0];
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                gcd = BinaryGCDCalculation(numbers[i], numbers[i + 1]);
            }

            return gcd;
        }

        /// <summary>
        /// Method calculates the GCD using Binary GCD algorithm for two integers and determines the time required to complete the calculation.
        /// </summary>
        /// <param name="first">first integer</param>
        /// <param name="second">second integer</param>
        /// <param name="timeMeasured">measured time</param>
        /// <returns>GCD of two integers and determine the time for calculations</returns>
        public static int BinaryGCDCalculation(int first, int second, out double timeMeasured)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var resultGCD = BinaryGCDCalculation(first, second);
            stopWatch.Stop();
            timeMeasured = stopWatch.ElapsedMilliseconds;
            return resultGCD;
        }

        /// <summary>
        /// Method calculates the GCD using Binary GCD algorithm for multiple arguments and determines the time required to complete the calculation.
        /// </summary>
        /// <param name="timeMeasured">measured time</param>
        /// <param name="numbers">array of numbers</param>
        /// <returns>GCD of the array of numbers and determine the time for calculations</returns>
        public static int BinaryGCDCalculation(out double timeMeasured, params int[] numbers)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var resultGCD = BinaryGCDCalculation(numbers);
            stopWatch.Stop();
            timeMeasured = stopWatch.ElapsedMilliseconds;
            return resultGCD;
        }
    }
}
