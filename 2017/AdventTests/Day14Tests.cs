using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day14Tests
    {
        [TestMethod]
        public void TestUsedSquares()
        {
            Assert.AreEqual(8108, Day14.UsedSquares("flqrgnkx"));
        }

        [TestMethod]
        public void TestNumberOfRegions()
        {
            Assert.AreEqual(1242, Day14.NumberOfRegions("flqrgnkx"));
        }
    }
}
