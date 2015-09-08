using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocsBr.Tests
{
    [TestClass]
    public class IETests
    {
        [TestMethod]
        public void TestShouldCreateIEWithUFAsString()
        {
            IE ie = new IE("395.333.85-7", "ES");
            Assert.IsTrue(ie.IsValid());
        }

        [TestMethod]
        public void TestShouldCreateIEWithUFCode()
        {
            IE ie = new IE("395.333.85-7", 32);
            Assert.IsTrue(ie.IsValid());
        }
    }
}
