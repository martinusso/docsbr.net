using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEAmapaValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "03.012.345-9", "03.002.547-3" };

        private static string[] invalidValues = { "03.012.345-0", "03.002.547-4", "12.345.678-9" };

        public IEAmapaValidatorTests() : base(UF.AP, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEAmapaValidator(ie);
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithMoreDigitsThanAllowed()
        {
            IEAmapaValidator ieWithInvalidSize = new IEAmapaValidator("031234567-4");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithLessDigitsThanAllowed()
        {
            IEAmapaValidator ieWithInvalidSize = new IEAmapaValidator("0312345-1");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }
    }
}
