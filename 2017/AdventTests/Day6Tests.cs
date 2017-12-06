using System;
using AdventSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTests
{
    [TestClass]
    public class Day6Tests
    {
        [TestMethod]
        public void TestRedistributionCycles()
        {
            Assert.AreEqual(5, Day6.RedistributionCycles(new int[] { 0, 2, 7, 0 }));
            Assert.AreEqual(4, Day6.CycleLength(new int[] { 0, 2, 7, 0 }));
        }
    }
}
