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

        [TestMethod]
        public void TestShouldReturnListOfCodes()
        {
            Assert.AreEqual<int>(27, DocsBr.Utils.UF.Codigos.Length);
            Assert.AreEqual<int>(11, DocsBr.Utils.UF.Codigos[0]);
            Assert.AreEqual<int>(12, DocsBr.Utils.UF.Codigos[1]);
            Assert.AreEqual<int>(13, DocsBr.Utils.UF.Codigos[2]);
            Assert.AreEqual<int>(14, DocsBr.Utils.UF.Codigos[3]);
            Assert.AreEqual<int>(15, DocsBr.Utils.UF.Codigos[4]);
            Assert.AreEqual<int>(16, DocsBr.Utils.UF.Codigos[5]);
            Assert.AreEqual<int>(17, DocsBr.Utils.UF.Codigos[6]);
            Assert.AreEqual<int>(21, DocsBr.Utils.UF.Codigos[7]);
            Assert.AreEqual<int>(22, DocsBr.Utils.UF.Codigos[8]);
            Assert.AreEqual<int>(23, DocsBr.Utils.UF.Codigos[9]);
            Assert.AreEqual<int>(24, DocsBr.Utils.UF.Codigos[10]);
            Assert.AreEqual<int>(25, DocsBr.Utils.UF.Codigos[11]);
            Assert.AreEqual<int>(26, DocsBr.Utils.UF.Codigos[12]);
            Assert.AreEqual<int>(27, DocsBr.Utils.UF.Codigos[13]);
            Assert.AreEqual<int>(28, DocsBr.Utils.UF.Codigos[14]);
            Assert.AreEqual<int>(29, DocsBr.Utils.UF.Codigos[15]);
            Assert.AreEqual<int>(31, DocsBr.Utils.UF.Codigos[16]);
            Assert.AreEqual<int>(32, DocsBr.Utils.UF.Codigos[17]);
            Assert.AreEqual<int>(33, DocsBr.Utils.UF.Codigos[18]);
            Assert.AreEqual<int>(35, DocsBr.Utils.UF.Codigos[19]);
            Assert.AreEqual<int>(41, DocsBr.Utils.UF.Codigos[20]);
            Assert.AreEqual<int>(42, DocsBr.Utils.UF.Codigos[21]);
            Assert.AreEqual<int>(43, DocsBr.Utils.UF.Codigos[22]);
            Assert.AreEqual<int>(50, DocsBr.Utils.UF.Codigos[23]);
            Assert.AreEqual<int>(51, DocsBr.Utils.UF.Codigos[24]);
            Assert.AreEqual<int>(52, DocsBr.Utils.UF.Codigos[25]);
            Assert.AreEqual<int>(53, DocsBr.Utils.UF.Codigos[26]);
        }

        [TestMethod]
        public void TestShouldReturnListOfAbbreviations()
        {
            Assert.AreEqual<int>(27, DocsBr.Utils.UF.Siglas.Length);
            Assert.AreEqual<string>("AC", DocsBr.Utils.UF.Siglas[0]);
            Assert.AreEqual<string>("AL", DocsBr.Utils.UF.Siglas[1]);
            Assert.AreEqual<string>("AM", DocsBr.Utils.UF.Siglas[2]);
            Assert.AreEqual<string>("AP", DocsBr.Utils.UF.Siglas[3]);
            Assert.AreEqual<string>("BA", DocsBr.Utils.UF.Siglas[4]);
            Assert.AreEqual<string>("CE", DocsBr.Utils.UF.Siglas[5]);
            Assert.AreEqual<string>("DF", DocsBr.Utils.UF.Siglas[6]);
            Assert.AreEqual<string>("ES", DocsBr.Utils.UF.Siglas[7]);
            Assert.AreEqual<string>("GO", DocsBr.Utils.UF.Siglas[8]);
            Assert.AreEqual<string>("MA", DocsBr.Utils.UF.Siglas[9]);
            Assert.AreEqual<string>("MG", DocsBr.Utils.UF.Siglas[10]);
            Assert.AreEqual<string>("MS", DocsBr.Utils.UF.Siglas[11]);
            Assert.AreEqual<string>("MT", DocsBr.Utils.UF.Siglas[12]);
            Assert.AreEqual<string>("PA", DocsBr.Utils.UF.Siglas[13]);
            Assert.AreEqual<string>("PB", DocsBr.Utils.UF.Siglas[14]);
            Assert.AreEqual<string>("PE", DocsBr.Utils.UF.Siglas[15]);
            Assert.AreEqual<string>("PI", DocsBr.Utils.UF.Siglas[16]);
            Assert.AreEqual<string>("PR", DocsBr.Utils.UF.Siglas[17]);
            Assert.AreEqual<string>("RJ", DocsBr.Utils.UF.Siglas[18]);
            Assert.AreEqual<string>("RN", DocsBr.Utils.UF.Siglas[19]);
            Assert.AreEqual<string>("RO", DocsBr.Utils.UF.Siglas[20]);
            Assert.AreEqual<string>("RR", DocsBr.Utils.UF.Siglas[21]);
            Assert.AreEqual<string>("RS", DocsBr.Utils.UF.Siglas[22]);
            Assert.AreEqual<string>("SC", DocsBr.Utils.UF.Siglas[23]);
            Assert.AreEqual<string>("SE", DocsBr.Utils.UF.Siglas[24]);
            Assert.AreEqual<string>("SP", DocsBr.Utils.UF.Siglas[25]);
            Assert.AreEqual<string>("TO", DocsBr.Utils.UF.Siglas[26]);
        }
    }
}
