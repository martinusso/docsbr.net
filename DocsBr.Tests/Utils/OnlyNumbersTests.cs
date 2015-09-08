using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Utils;

namespace DocsBr.Tests
{
    [TestClass]
    public class OnlyNumbersTests
    {
        [TestMethod]
        public void TestShouldReturnNumbers()
        {
            OnlyNumbers only = new OnlyNumbers("1$2@3aA-4%5!6/7?8#9*0 ");
            Assert.AreEqual("1234567890", only.ToString());
        }

        [TestMethod]
        public void TestShouldReturnEmpty()
        {
            OnlyNumbers only = new OnlyNumbers("");
            Assert.AreEqual("", only.ToString());
        }
    }
}
