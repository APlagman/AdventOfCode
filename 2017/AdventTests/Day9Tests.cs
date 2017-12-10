using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day9Tests
    {
        [TestMethod]
        public void TestScoreOfStream()
        {
            Assert.AreEqual(1, Day9.ScoreOfStream("{}").Score);
            Assert.AreEqual(6, Day9.ScoreOfStream("{{{}}}").Score);
            Assert.AreEqual(5, Day9.ScoreOfStream("{{},{}}").Score);
            Assert.AreEqual(16, Day9.ScoreOfStream("{{{},{},{{}}}}").Score);
            Assert.AreEqual(1, Day9.ScoreOfStream("{<a>,<a>,<a>,<a>}").Score);
            Assert.AreEqual(9, Day9.ScoreOfStream("{{<ab>},{<ab>},{<ab>},{<ab>}}").Score);
            Assert.AreEqual(9, Day9.ScoreOfStream("{{<!!>},{<!!>},{<!!>},{<!!>}}").Score);
            Assert.AreEqual(3, Day9.ScoreOfStream("{{<a!>},{<a!>},{<a!>},{<ab>}}").Score);
        }

        [TestMethod]
        public void TestStreamGarbageCount()
        {
            Assert.AreEqual(0, Day9.ScoreOfStream("<>").GarbageCount);
            Assert.AreEqual(17, Day9.ScoreOfStream("<random characters>").GarbageCount);
            Assert.AreEqual(3, Day9.ScoreOfStream("<<<<>").GarbageCount);
            Assert.AreEqual(2, Day9.ScoreOfStream("<{!>}>").GarbageCount);
            Assert.AreEqual(0, Day9.ScoreOfStream("<!!>").GarbageCount);
            Assert.AreEqual(0, Day9.ScoreOfStream("<!!!>>").GarbageCount);
            Assert.AreEqual(10, Day9.ScoreOfStream("<{o\"i!a,<{i<a>").GarbageCount);
        }
    }
}
