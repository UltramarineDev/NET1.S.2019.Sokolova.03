using System;
using NUnit.Framework;

namespace DoubleManipulations.Tests
{
    public class NewtonImplementationTests
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.01, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.01, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRootTests(double number, int grade, double accurancy)
        => NewtonImplementation.FindNthRoot(number, grade, accurancy);

        [Test]
        public void FindNthRoot_InvalidValues_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => NewtonImplementation.FindNthRoot(-0.01, 2, 0.0001));
            Assert.Throws<ArgumentException>(() => NewtonImplementation.FindNthRoot(0.001, -2, 0.0001));
            Assert.Throws<ArgumentException>(() => NewtonImplementation.FindNthRoot(0.01, 2, -0.0001));
        }
    }
}
