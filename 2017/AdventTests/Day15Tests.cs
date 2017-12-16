using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        public void TestMatchingPairs()
        {
            Assert.AreEqual(588, Day15.MatchingPairs(65, 8921, 40000000L));
        }

        [TestMethod]
        public void TestMatchingPairsWithMultiples()
        {
            Assert.AreEqual(309, Day15.MatchingPairsWithMultiples(65, 8921, 5000000L, 4, 8));
        }
    }
}