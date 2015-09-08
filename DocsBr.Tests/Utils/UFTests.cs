using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Utils;

namespace DocsBr.Tests
{
    [TestClass]
    public class UFTests
    {
        [TestMethod]
        public void TestShouldReturnDescription()
        {
            Assert.AreEqual("ESPÍRITO SANTO", UF.ES.GetDescricao().ToUpper());
        }

        [TestMethod]
        public void TestShouldReturnAcronym()
        {
            Assert.AreEqual("SP", UF.SP.GetSigla());
        }

        [TestMethod]
        public void TestShouldReturnCode()
        {
            Assert.AreEqual(53, UF.DF.GetCodigo());
        }
    }
}
