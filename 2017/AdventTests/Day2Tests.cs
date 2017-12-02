using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void TestRange()
        {
            Assert.AreEqual(8, Day2.Range("5 1 9 5"));
            Assert.AreEqual(4, Day2.Range("7 5 3  "));
            Assert.AreEqual(6, Day2.Range("2 4 6 8"));
        }

        [TestMethod]
        public void TestDivision()
        {
            Assert.AreEqual(4, Day2.DivideMultiplesIn("5 9 2 8"));
            Assert.AreEqual(3, Day2.DivideMultiplesIn("9 4 7 3"));
            Assert.AreEqual(2, Day2.DivideMultiplesIn("3 8 6 5"));
        }
    }
}
