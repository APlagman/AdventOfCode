using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void TestDistanceAfterSteps()
        {
            Assert.AreEqual(3, Day11.DistanceAfterSteps("ne,ne,ne"));
            Assert.AreEqual(0, Day11.DistanceAfterSteps("ne,ne,sw,sw"));
            Assert.AreEqual(2, Day11.DistanceAfterSteps("ne,ne,s,s"));
            Assert.AreEqual(3, Day11.DistanceAfterSteps("se,sw,se,sw,sw"));
        }
    }
}