using System;
using NUnit.Framework;

namespace NumbersManipulations.Tests
{
    public class NumerFinderTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(124121133, ExpectedResult = 124121313)]
        [TestCase(int.MaxValue, ExpectedResult = null)]
        [TestCase(2000, ExpectedResult = null)]
        [TestCase(111111111, ExpectedResult = null)]
        public int? NextBiggerThanTests(int number)
            => NumberFinder.NextBiggerThan(number);

        [Test]
        public void InsertNumberMethod_InvalidValues_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => NumberFinder.NextBiggerThan(-1));
            Assert.Throws<ArgumentException>(() => NumberFinder.NextBiggerThan(-900));
        }
    }
}
