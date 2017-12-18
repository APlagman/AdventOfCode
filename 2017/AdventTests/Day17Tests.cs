using AdventSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTests
{
    [TestClass]
    public class Day17Tests
    {
        [TestMethod]
        public void TestCircularInsertAndFindNext()
        {
            Assert.AreEqual(638, Day17.CircularInsertAndFindNext(3, 2017));
        }
    }
}
