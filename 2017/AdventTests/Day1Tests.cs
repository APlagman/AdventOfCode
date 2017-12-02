using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    // http://adventofcode.com/2017/day/1
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        public void TestAdjacentDigits()
        {
            Assert.AreEqual(Day1.SumIdenticalDigits("1122", 1), 3);
            Assert.AreEqual(Day1.SumIdenticalDigits("1111", 1), 4);
            Assert.AreEqual(Day1.SumIdenticalDigits("1234", 1), 0);
            Assert.AreEqual(Day1.SumIdenticalDigits("91212129", 1), 9);
        }

        [TestMethod]
        public void TestHalfwayDigits()
        {
            Assert.AreEqual(Day1.SumIdenticalDigits("1212", "1212".Length / 2), 6);
            Assert.AreEqual(Day1.SumIdenticalDigits("1221", "1221".Length / 2), 0);
            Assert.AreEqual(Day1.SumIdenticalDigits("123425", "123425".Length / 2), 4);
            Assert.AreEqual(Day1.SumIdenticalDigits("123123", "123123".Length / 2), 12);
            Assert.AreEqual(Day1.SumIdenticalDigits("12131415", "12131415".Length / 2), 4);
        }
    }
}
