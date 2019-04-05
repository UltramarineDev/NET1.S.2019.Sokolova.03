using NUnit.Framework;

namespace NumbersManipulations.Tests
{
    public class GCDNew3DecoratorTests
    {
        [TestCase(5, 0, ExpectedResult = 5)]
        [TestCase(0, 15, ExpectedResult = 15)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        public int CalculateByEuclideanTest(int first, int second)
        {
            var timeGCDAlgorithmDecorator = new TimeGCDAlgorithmDecorator(new EuclideanGcdAlgorithm());

            var result = timeGCDAlgorithmDecorator.Calculate(first, second);
            return result;
        }

        [TestCase(5, 0, ExpectedResult = 5)]
        [TestCase(0, 15, ExpectedResult = 15)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        public int CalculateBySteinTest(int first, int second)
        {
            var timeGCDAlgorithmDecorator = new TimeGCDAlgorithmDecorator(new BinaryGcdAlgorithm());

            var result = timeGCDAlgorithmDecorator.Calculate(first, second);
            return result;
        }

        [Test]
        public void EuclideanCalculationMethod_OrdinaryValues_CalculationTimeNotNull()
        {
            var timeGCDAlgorithmDecorator = new TimeGCDAlgorithmDecorator(new EuclideanGcdAlgorithm());

            var result = timeGCDAlgorithmDecorator.Calculate(5432, 22);
            Assert.GreaterOrEqual(timeGCDAlgorithmDecorator.Time, 0.0);
        }

        [Test]
        public void BinaryGCDCalculationMethod_OrdinaryValues_CalculationTimeNotNull()
        {
            var timeGCDAlgorithmDecorator = new TimeGCDAlgorithmDecorator(new BinaryGcdAlgorithm());

            var result = timeGCDAlgorithmDecorator.Calculate(5432, 22);
            Assert.GreaterOrEqual(timeGCDAlgorithmDecorator.Time, 0.0);
        }

    }
}
