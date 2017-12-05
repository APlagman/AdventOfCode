using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day5Tests
    {
        [TestMethod]
        public void TestNumberOfSteps()
        {
            Assert.AreEqual(5, Day5.NumberOfSteps(new int[] { 0, 3, 0, 1, -3 }));
        }

        [TestMethod]
        public void TestNumberOfStepsVersion2()
        {
            Assert.AreEqual(10, Day5.NumberOfStepsVersion2(new int[] { 0, 3, 0, 1, -3 }));
        }
    }
}
