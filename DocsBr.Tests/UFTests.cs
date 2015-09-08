using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocsBr.Tests
{
    [TestClass]
    public class UFTests
    {
        [TestMethod]
        public void TestShouldReturnUFName()
        {
            Assert.AreEqual("ESPÍRITO SANTO", UF.ES.Nome().ToUpper());
        }

        [TestMethod]
        public void TestShouldReturnUFAcronym()
        {
            Assert.AreEqual("SP", UF.SP.Sigla());
        }

        [TestMethod]
        public void TestShouldReturnUFCode()
        {
            Assert.AreEqual(53, UF.DF.Codigo());
        }
    }
}
