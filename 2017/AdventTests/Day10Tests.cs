using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void TestTwistAndFindProduct()
        {
            Assert.AreEqual(12, Day10.TwistAndFindProduct("3,4,1,5", 5));
        }

        [TestMethod]
        public void TestKnotHash()
        {
            Assert.AreEqual("a2582a3a0e66e6e86e3812dcb672a272", Day10.KnotHash(""));
            Assert.AreEqual("33efeb34ea91902bb2f59c9920caa6cd", Day10.KnotHash("AoC 2017"));
            Assert.AreEqual("3efbe78a8d82f29979031a4aa0b16a9d", Day10.KnotHash("1,2,3"));
            Assert.AreEqual("63960835bcdc130f0b66d7ff4f6a5a8e", Day10.KnotHash("1,2,4"));
        }
    }
}
