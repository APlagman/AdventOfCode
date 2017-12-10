using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day8Tests
    {
        [TestMethod]
        public void TestMaximumValueAfterRegisterInstructions()
        {
            Assert.AreEqual(1, Day8.MaximumValueAfterRegisterInstructions(new[]
            {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            }));
        }

        [TestMethod]
        public void TestMaximumValueDuringRegisterInstructions()
        {
            Assert.AreEqual(10, Day8.MaximumValueDuringRegisterInstructions(new[]
            {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            }));
        }
    }
}
