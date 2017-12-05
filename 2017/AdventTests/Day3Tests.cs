using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void TestSquareRootOfNextOddPerfectSquare()
        {
            Assert.AreEqual(3, Day3.SquareRootOfNextOddPerfectSquare(8));
            Assert.AreEqual(1, Day3.SquareRootOfNextOddPerfectSquare(1));
            Assert.AreEqual(5, Day3.SquareRootOfNextOddPerfectSquare(23));
            Assert.AreEqual(5, Day3.SquareRootOfNextOddPerfectSquare(14));
        }

        [TestMethod]
        public void TestStepsToCenter()
        {
            Assert.AreEqual(0, Day3.StepsToCenter(1));
            Assert.AreEqual(3, Day3.StepsToCenter(12));
            Assert.AreEqual(2, Day3.StepsToCenter(23));
            Assert.AreEqual(31, Day3.StepsToCenter(1024));
        }

        [TestMethod]
        public void TestNextInSpiral()
        {
            Assert.AreEqual(2, Day3.NextInSpiral(1));
            Assert.AreEqual(4, Day3.NextInSpiral(2));
            Assert.AreEqual(5, Day3.NextInSpiral(4));
            Assert.AreEqual(10, Day3.NextInSpiral(5));
            Assert.AreEqual(11, Day3.NextInSpiral(10));
            Assert.AreEqual(23, Day3.NextInSpiral(11));
            Assert.AreEqual(25, Day3.NextInSpiral(23));
            Assert.AreEqual(26, Day3.NextInSpiral(25));
            Assert.AreEqual(54, Day3.NextInSpiral(26));
            Assert.AreEqual(57, Day3.NextInSpiral(54));
            Assert.AreEqual(133, Day3.NextInSpiral(122));
            Assert.AreEqual(304, Day3.NextInSpiral(147));
        }
    }
}
