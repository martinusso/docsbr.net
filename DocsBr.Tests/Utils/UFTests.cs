using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocsBr.Tests.Utils
{
    [TestClass]
    public class UFTests
    {
        [TestMethod]
        public void TestShouldConvertStringToUFEnum()
        {
            Assert.AreEqual(UF.ES, DocsBr.Utils.UF.ToEnum("eS"));
            Assert.AreEqual(UF.SP, DocsBr.Utils.UF.ToEnum("sp"));
            Assert.AreEqual(UF.MG, DocsBr.Utils.UF.ToEnum("Mg"));
        }

    }
}
