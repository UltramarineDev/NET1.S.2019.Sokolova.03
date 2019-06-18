using System;
using System.Collections.Generic;

namespace NumbersManipulations
{
    /// <summary>
    /// Class NumberFinderNew - another solution
    /// </summary>
    public class NumberFinderNew
    {
        /// <summary>
        /// Method finds the nearest largest integer consisting of the digits of the original number
        /// </summary>
        /// <param name="number">input integer number</param>
        /// <returns>returns the nearest largest integer consisting of the digits of the original number</returns>
        /// <exception cref="ArgumentException">Thrown when the input number is negative or zero</exception>
        public static int? NextBiggerThan(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Input number should be positive integer", nameof(number));
            }

            int numberCopy = number;
            List<int> digits = new List<int>();
            List<int> biggerDigits = new List<int>();
            do
            {
                int currentDigit = number % 10;
                number = number / 10;
                FindBiggerDigits(biggerDigits, digits, currentDigit);
                digits.Add(currentDigit);
            } while (biggerDigits.Count == 0 && number > 0);

            if (biggerDigits.Count == 0)
            {
                return null;
            }

            int nextDigit = Min(biggerDigits);
            number = number * 10 + nextDigit;
            digits.Remove(nextDigit);
            digits.Sort();

            foreach (var dig in digits)
            {
                number = number * 10 + dig;
            }

            if (number > numberCopy)
            {
                return number;
            }

            return null;
        }

        private static List<int> FindBiggerDigits(List<int> biggerDigits, List<int> digits, int currentDigit)
        {
            for (int i = 0; i < digits.Count; i++)
            {
                if (digits[i] > currentDigit)
                {
                    biggerDigits.Add(digits[i]);
                }
            }

            return biggerDigits;
        }

        private static int Min(List<int> biggerDigits)
        {
            int minElement = biggerDigits[0];
            for (int i = 0; i < biggerDigits.Count; i++)
            {
                if (biggerDigits[i] < minElement)
                {
                    minElement = biggerDigits[i];
                }
            }

            return minElement;
        }
    }
}
