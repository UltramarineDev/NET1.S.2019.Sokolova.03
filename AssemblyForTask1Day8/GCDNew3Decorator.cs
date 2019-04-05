using System.Diagnostics;

namespace NumbersManipulations
{
    /// <summary>
    /// Abstract class GcdAlgorithmDecorator
    /// </summary>
    public abstract class GcdAlgorithmDecorator : IGcdAlgorithm
    {
        protected readonly IGcdAlgorithm _decoratee;

        protected GcdAlgorithmDecorator(IGcdAlgorithm decoratee)
        {
            _decoratee = decoratee;
        }

        public abstract int Calculate(int first, int second);
    }

    /// <summary>
    /// TimeGCDAlgorithmDecorator class
    /// </summary>
    public class TimeGCDAlgorithmDecorator : GcdAlgorithmDecorator
    {
        /// <summary>
        /// Gets Time measured
        /// </summary>
        public double Time { get; private set; }

        /// <summary>
        /// Constructor for TimeGCDAlgorithmDecorator class
        /// </summary>
        /// <param name="decoratee"></param>
        public TimeGCDAlgorithmDecorator(IGcdAlgorithm decoratee) : base(decoratee) { }

        /// <summary>
        /// Method overrides Calulate method
        /// </summary>
        /// <param name="first">first value</param>
        /// <param name="second">second value</param>
        /// <returns>algorithm execution time</returns>
        public override int Calculate(int first, int second)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var resultGCD = _decoratee.Calculate(first, second);

            stopWatch.Stop();
            Time = stopWatch.ElapsedMilliseconds;

            return resultGCD;
        }

    }
}
