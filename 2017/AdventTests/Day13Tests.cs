using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public void TestSeverity()
        {
            Firewall firewall = new Firewall();
            firewall.AddLayer(0, 3);
            firewall.AddLayer(1, 2);
            firewall.AddLayer(4, 4);
            firewall.AddLayer(6, 4);
            Assert.AreEqual(24, firewall.Pass().Severity);
        }

        [TestMethod]
        public void TestMinimumDelay()
        {
            Firewall firewall = new Firewall();
            firewall.AddLayer(0, 3);
            firewall.AddLayer(1, 2);
            firewall.AddLayer(4, 4);
            firewall.AddLayer(6, 4);
            Assert.AreEqual(10, firewall.MinimumDelay());
        }
    }
}
