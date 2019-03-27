using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="accurancy">given accuracy</param>
        /// <returns>the n-th root</returns>
        /// <exception cref="ArgumentException">Thrown when number is less than zero and grade is even.</exception>
        /// <exception cref="ArgumentException">Thrown when grade is less than zero.</exception>
        /// <exception cref="ArgumentException">Thrown when accuracy is negative</exception>
        public static double FindNthRoot(double number, int grade, double accurancy)
        {
            if (number < 0 && grade % 2 == 0)
            {
                throw new ArgumentException("Invalid input values");
            }

            if (grade < 0)
            {
                throw new ArgumentException("Grade should be positive integer", nameof(grade));
            }

            if (accurancy < 0)
            {
                throw new ArgumentException("Accurancy can not be negative", nameof(accurancy));
            }

            if (accurancy >= 1)
            {
                accurancy = 0.0001;
            }

            double previous = number / grade;
            double next = previous * (1.0 - (1 - number / Math.Pow(previous, grade)) / grade);
            while (Math.Abs(next - previous) >= accurancy)
            {
                previous = next;
                next = previous * (1.0 - (1 - number / Math.Pow(previous, grade)) / grade);
            }

            return Math.Round(next, 4);
        }
    }
}
