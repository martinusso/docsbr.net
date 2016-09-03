using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocsBr.Tests
{
    [TestClass]
    public class CEPTests
    {
        [TestMethod]
        public void TestShouldFormatCEP()
        {
            var expected = "12.345-678";
            var got = CEP.Formatar("12345678");

            Assert.AreEqual<string>(expected, got);
        }

        [TestMethod]
        public void TestShouldFormatCEPAlreadyFormatted()
        {
            var expected = "12.345-678";
            var got = CEP.Formatar("12.345-678");

            Assert.AreEqual<string>(expected, got);
        }

        [TestMethod]
        public void TestShouldFormatCEPWhenPassMoreThan8Numbers()
        {
            var expected = "123456789";
            var got = CEP.Formatar("123456789");

            Assert.AreEqual<string>(expected, got);
        }

        [TestMethod]
        public void TestShouldReturnSameNumbersWhenPassLessThan8Numbers()
        {
            var expected = "1234567";
            var got = CEP.Formatar("1234567");

            Assert.AreEqual<string>(expected, got);
        }

        [TestMethod]
        public void TestShouldReturnSameCharsWhenDontPassOnlyNumbers()
        {
            var expected = "12EA5678";
            var got = CEP.Formatar("12EA5678");

            Assert.AreEqual<string>(expected, got);
        }
    }
}
