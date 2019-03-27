using System;
using System.Collections.Generic;

namespace NumbersManipulations
{
    /// <summary>
    /// Class NumberFinder
    /// </summary>
    public class NumberFinder
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

            List<int> resultArray = new List<int>();
            List<int> listinitial = new List<int>();

            var numberCopy = number;
            while (numberCopy > 0)
            {
                listinitial.Add(numberCopy % 10);
                numberCopy = numberCopy / 10;
            }

            List<int> listOfDigits = new List<int>();

            for (int i = listinitial.Count - 1; i >= 0; i--)
            {
                listOfDigits.Add(listinitial[i]);
            }

            int resNumber = 0;
            for (int k = listOfDigits.Count - 1, q = 1; k >= 0; k--, q = q * 10)
            {
                resNumber += listOfDigits[k] * q;
            }

            resultArray.Add(resNumber);

            int listLength = listOfDigits.Count;

            while (NextSet(listOfDigits, listLength))
            {
                int result = 0;
                for (int k = listOfDigits.Count - 1, q = 1; k >= 0; k--, q = q * 10)
                {
                    result += listOfDigits[k] * q;
                }

                resultArray.Add(result);
            }

            resultArray.Sort();
            foreach (var a in resultArray)
            {
                if (a > number)
                {
                    return a;
                }
            }

            return null;
        }

        private static bool NextSet(List<int> list, int n)
        {
            int j = n - 2;
            while (j != -1 && list[j] >= list[j + 1])
            {
                j--;
            }
                
            if (j == -1)
            {
                return false;
            }
                
            int k = n - 1;
            while (list[j] >= list[k])
            {
                k--;
            }
                
            Swap(list, j, k);
            int l = j + 1, r = n - 1;
            while (l < r)
            {
                Swap(list, l++, r--);
            }
                
            return true;
        }

        private static void Swap(List<int> list, int i, int j)
        {
            int s = list[i];
            list[i] = list[j];
            list[j] = s;
        }
    }
}
