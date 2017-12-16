using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day12Tests
    {
        [TestMethod]
        public void TestGroups()
        {
            var groups = Day12.Groups(new string[]
            {
                "0 <-> 2",
                "1 <-> 1",
                "2 <-> 0, 3, 4",
                "3 <-> 2, 4",
                "4 <-> 2, 3, 6",
                "5 <-> 6",
                "6 <-> 4, 5"
            });
            Assert.AreEqual(6, groups[0].Count);
            Assert.AreEqual(2, groups.Count);
        }
    }
}
