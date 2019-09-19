using System;

namespace DoubleManipulations
{
    /// <summary>
    /// Newton Implementation class
    /// </summary>
    public class NewtonImplementation
    {
        /// <summary>
        /// Method calculate the n-th root of a given number using Newton method with a given accuracy
        /// </summary>
        /// <param name="number"> input number</param>
        /// <param name="grade">grade of the root</param>
        /// <param name="accuracy">given accuracy</param>
        /// <returns>the n-th root</returns>
        /// <exception cref="ArgumentException">Thrown when number is less than zero and grade is even.</exception>
        /// <exception cref="ArgumentException">Thrown when grade is less than zero.</exception>
        /// <exception cref="ArgumentException">Thrown when accuracy is negative</exception>
        public static double FindNthRoot(double number, int grade, double accuracy)
        {
            if (number < 0 && grade % 2 == 0)
            {
                throw new ArgumentException("Invalid input values");
            }

            if (grade < 0)
            {
                throw new ArgumentException("Grade should be positive integer", nameof(grade));
            }

            if (accuracy < 0)
            {
                throw new ArgumentException("Accurancy can not be negative", nameof(accuracy));
            }

            double previous = number / grade;
            double next = previous * (1.0 - (1 - number / Math.Pow(previous, grade)) / grade);
            while (Math.Abs(next - previous) >= accuracy)
            {
                previous = next;
                next = previous * (1.0 - (1 - number / Math.Pow(previous, grade)) / grade);
            }

            return Math.Round(next, 4);
        }
    }
}
