using System;
using NUnit.Framework;


namespace NumbersManipulations.Tests
{
    public class GCDTests
    {
        [TestCase(5, 0, ExpectedResult = 5)]
        [TestCase(0, 15, ExpectedResult = 15)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        public int EuclideanCalculationTests(int first, int second)
            => GCD.EuclideanCalculation(first, second);

        public int BinaryGCDCalculationTests(int first, int second)
            => GCD.BinaryGCDCalculation(first, second);

        [Test]
        public void EuclideanCalculationMethod_OrdinaryValues_CalculationTimeNotNull()
        {
            double time = 0;
            int resultGCD = GCD.EuclideanCalculation(5, 0, out time);
            Assert.NotNull(time);
        }

        [Test]
        public void BinaryGCDCalculationMethod_TwoIntegers_CalculationTimeNotNull()
        {
            double time = 0;
            int resultGCD = GCD.BinaryGCDCalculation(5, 0, out time);
            Assert.NotNull(time);
        }

        [Test]
        public void EuclideanCalculationMethod_TwoIntegers_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.EuclideanCalculation(0, 0));
        }

        [Test]
        public void BinaryGCDCalculationMethod_InvalidValues_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.BinaryGCDCalculation(0, 0));
        }

        [TestCase(new int[] { 0, 15 }, ExpectedResult = 15)]
        [TestCase(new int[] { 0, 1, 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { 24, 24, 6 }, ExpectedResult = 6)]
        [TestCase(new int[] { 15, 30, 7 }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, 1, 0, 1, 0 }, ExpectedResult = 1)]
        public int EuclideanCalculationTests(int[] numbers)
            => GCD.EuclideanCalculation(numbers);

        public int BinaryGCDCalculationTests(int[] numbers)
            => GCD.BinaryGCDCalculation(numbers);

        [Test]
        public void EuclideanCalculationMethod_ArrayOfIntegers_CalculationTimeNotNull()
        {
            double time = 0;
            int resultGCD = GCD.EuclideanCalculation(out time, new int[] { 0, 1, 0, 1, 0 });
            Assert.NotNull(time);
        }

        [Test]
        public void BinaryGCDCalculationMethod_ArrayOgIntegers_CalculationTimeNotNull()
        {
            double time = 0;
            int resultGCD = GCD.BinaryGCDCalculation(out time, new int[] { 0, 1, 0, 1, 0 });
            Assert.NotNull(time);
        }

        [Test]
        public void EuclideanCalculationMethod_EmptyArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.EuclideanCalculation(new int[] { }));
        }

        [Test]
        public void BinaryGCDCalculationMethod_EmptyArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.BinaryGCDCalculation(new int[] { }));
        }
    }
}
