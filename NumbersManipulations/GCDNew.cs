using System;
using System.Diagnostics;

namespace NumbersManipulations
{
    internal abstract class GCDNew
    {
        public int Calculate(int first, int second)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Invalid input values: both perameters can not be zero");
            }

            return CalculateInitial(first, second);
        }

        public int Calculate(int first, int second, out long timeMeasured)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Invalid input values: both perameters can not be zero");
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var resultGCD = Calculate(first, second);

            stopWatch.Stop();
            timeMeasured = stopWatch.ElapsedMilliseconds;

            return resultGCD;
        }

        protected abstract int CalculateInitial(int first, int second);
    }

    internal class EuclideanAlgorithm : GCDNew
    {
        protected override int CalculateInitial(int first, int second)
        {
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

    internal class BinaryGCDAlgorithm : GCDNew
    {
        protected override int CalculateInitial(int first, int second)
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
                return 2 * CalculateInitial(first / 2, second / 2);
            }

            if (first % 2 == 0 && second % 2 != 0)
            {
                return CalculateInitial(first / 2, second);
            }

            if (first % 2 != 0 && second % 2 == 0)
            {
                return CalculateInitial(first, second / 2);
            }

            if (first % 2 != 0 && second % 2 != 0 && second > first)
            {
                return CalculateInitial((second - first) / 2, first);
            }

            return CalculateInitial((second - first) / 2, second);
        }
    }

    public static class GCDAlgorithms
    {
        public static int CalculateByEuclidean(int first, int second)
        => CalculateWith2Params(first, second, new EuclideanAlgorithm());

        public static int CalculateByStein(int first, int second)
        => CalculateWith2Params(first, second, new BinaryGCDAlgorithm());

        public static int CalculateByEuclideanAndTime(int first, int second, out long time)
        => CalculateWith2ParamsAndTime(first, second, out time, new EuclideanAlgorithm());

        public static int CalculateBySteinAndTime(int first, int second, out long time)
       => CalculateWith2ParamsAndTime(first, second, out time, new BinaryGCDAlgorithm());

        private static int CalculateWith2Params(int first, int second, GCDNew gCD)
        => gCD.Calculate(first, second);

        private static int CalculateWith2ParamsAndTime(int first, int second, out long timeMeasured, GCDNew gCD)
        => gCD.Calculate(first, second, out timeMeasured);
    }
}
