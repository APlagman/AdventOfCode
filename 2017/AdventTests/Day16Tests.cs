using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        public void TestDance()
        {
            Assert.AreEqual("baedc", Day16.Dance('e', new string[] { "s1", "x3/4", "pe/b" }));
        }
    }
}
