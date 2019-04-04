using System;
using NUnit.Framework;

namespace NumbersManipulations.Tests
{
    public class GCDNewTests
    {
        [TestCase(5, 0, ExpectedResult = 5)]
        [TestCase(0, 15, ExpectedResult = 15)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        public int CalculateByEuclideanTests(int first, int second)
            => GCDAlgorithms.CalculateByEuclidean(first, second);

        [TestCase(5, 0, ExpectedResult = 5)]
        [TestCase(0, 15, ExpectedResult = 15)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        public int CalculateBySteinTests(int first, int second)
            => GCDAlgorithms.CalculateByStein(first, second);

        [Test]
        public void EuclideanCalculationMethod_OrdinaryValues_CalculationTimeNotNull()
        {
            long time = 0;
            int resultGCD = GCDAlgorithms.CalculateByEuclideanAndTime(5, 0, out time);
            Assert.NotNull(time);
        }

        [Test]
        public void BinaryGCDCalculationMethod_OrdinaryValues_CalculationTimeNotNull()
        {
            long time = 0;
            int resultGCD = GCDAlgorithms.CalculateBySteinAndTime(5, 0, out time);
            Assert.NotNull(time);
        }

        [Test]
        public void EuclideanCalculationMethod_TwoIntegers_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.CalculateByEuclidean(0, 0));
        }

        [Test]
        public void BinaryGCDCalculationMethod_InvalidValues_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.CalculateByStein(0, 0));
        }
    }
}
