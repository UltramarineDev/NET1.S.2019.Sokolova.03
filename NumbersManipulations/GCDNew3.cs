using System;

namespace NumbersManipulations
{
    /// <summary>
    /// IGcdAlgorithm interface
    /// </summary>
    public interface IGcdAlgorithm
    {
        int Calculate(int first, int second);
    }

    /// <summary>
    /// EuclideanGcdAlgorithm class
    /// </summary>
    public class EuclideanGcdAlgorithm : IGcdAlgorithm
    {
        /// <summary>
        /// Method calculates the greatest common divisor using Euclidean algorithm for two integers.
        /// </summary>
        /// <param name="first">first integer</param>
        /// <param name="second">second integer</param>
        /// <returns>GCD of two integers</returns>
        /// <exception cref="ArgumentException">Thrown when first and second numbers are zero.</exception>
        public int Calculate(int first, int second)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Invalid input values: both perameters can not be zero");
            }

            if (first < 0)
            {
                first = -first;
            }

            if (second < 0)
            {
                second = -second;
            }

            if (first == 0)
            {
                return Math.Abs(second);
            }

            if (second == 0)
            {
                return Math.Abs(first);
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
    }

    /// <summary>
    /// BinaryGcdAlgorithm class
    /// </summary>
    public class BinaryGcdAlgorithm : IGcdAlgorithm
    {
        /// <summary>
        /// Method calculates the greatest common divisor using Binary GCD algorithm for two integers.
        /// </summary>
        /// <param name="first">first integer</param>
        /// <param name="second">second integer</param>
        /// <returns>GCD of two integers</returns>
        /// <exception cref="ArgumentException">Thrown when first and second numbers are zero.</exception
        public int Calculate(int first, int second)
        {
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

            if (first % 2 == 0 && second % 2 == 0)
            {
                return 2 * Calculate(first / 2, second / 2);
            }

            if (first % 2 == 0 && second % 2 != 0)
            {
                return Calculate(first / 2, second);
            }

            if (first % 2 != 0 && second % 2 == 0)
            {
                return Calculate(first, second / 2);
            }

            if (first % 2 != 0 && second % 2 != 0 && second > first)
            {
                return Calculate((second - first) / 2, first);
            }

            return Calculate((second - first) / 2, second);
        }
    }
}
