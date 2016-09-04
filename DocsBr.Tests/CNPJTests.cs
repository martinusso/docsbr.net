using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocsBr.Tests
{
    [TestClass]
    public class CNPJTests
    {
        private static string[] formattedCNPJ = { "26.637.142/0001-58", "11.222.333/0001-81", "99.999.999/0001-91" };
        private static string[] unformattedCNPJ = { "26637142000158", "11222333000181", "99999999000191" };

        [TestMethod]
        public void TestShouldReturnUnformattedCNPJ()
        {
            CNPJ cnpj = formattedCNPJ[0];
            Assert.AreEqual<string>(unformattedCNPJ[0], cnpj);
            Assert.AreEqual<string>(unformattedCNPJ[0], cnpj.SemMascara());
        }

        [TestMethod]
        public void TestShouldReturnFormattedCNPJ()
        {
            CNPJ cnpj = unformattedCNPJ[0];
            Assert.AreEqual(formattedCNPJ[0], cnpj.ComMascara());
        }

        [TestMethod]
        public void TestShouldReturnEmptyCNPJ()
        {
            CNPJ cnpj = "";
            Assert.AreEqual("", cnpj.ToString());
        }

        [TestMethod]
        public void TestShouldValidateCNPJ()
        {
            foreach (CNPJ cnpj in formattedCNPJ)
            {
                Assert.IsTrue(cnpj.IsValid(), cnpj);
            }
        }

        [TestMethod]
        public void TestShouldInvalidateCNPJWhenCheckDigitInvalid()
        {
            CNPJ cnpj = "99.999.999/0001-00";
            Assert.IsFalse(cnpj.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateCNPJWhenEmpty()
        {
            CNPJ cnpj = "";
            Assert.IsFalse(cnpj.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateCNPJWhenRepeatedDigits()
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };

            foreach (CNPJ cnpj in invalidNumbers)
            {
                Assert.IsFalse(cnpj.IsValid());
            }
        }

        [TestMethod]
        public void TestShouldReturnEqualsWhenComparedFormattedAndUnformattedCNPJ()
        {
            CNPJ cnpjWithMask = formattedCNPJ[0];
            CNPJ cnpjWithoutMask = unformattedCNPJ[0];
            Assert.IsTrue(cnpjWithMask.Equals(cnpjWithoutMask));
        }

        [TestMethod]
        public void TestShouldReturnNotEqualsWhenComparedDifferentCNPJ()
        {
            CNPJ cnpj1 = formattedCNPJ[0];
            CNPJ cnpj2 = "99.999.999/0001-00";
            Assert.IsFalse(cnpj1.Equals(cnpj2));
        }

        [TestMethod]
        public void TestShouldReturnEmptyCNPJWhenPassNull()
        {
            CNPJ cnpj = null;
            Assert.AreEqual<string>("", cnpj);
            Assert.AreEqual<string>("", cnpj.ComMascara());
        }

        [TestMethod]
        public void TestShouldReturnEmptyCNPJWhenPassLessThan14Numbers()
        {
            CNPJ cnpj = "12345";
            Assert.AreEqual<string>("12345", cnpj);
            Assert.AreEqual<string>("00.000.000/0123-45", cnpj.ComMascara());
        }

        [TestMethod]
        public void TestShouldReturnEmptyCNPJWhenPassLessThan14Chars()
        {
            CNPJ cnpj = "12E45";
            Assert.AreEqual<string>("1245", cnpj);
            Assert.AreEqual<string>("00.000.000/0012-45", cnpj.ComMascara());
        }
    }
}
