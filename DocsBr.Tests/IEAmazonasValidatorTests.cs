using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEAmazonasValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        {
            "04.345.678-2", "04.193.980-8", "06.200.021-7",	"07.000.507-9", "04.104.862-8"
        };

        private static string[] invalidValues = 
        {
            "04.345.678-3", "04.193.980-9", "06.200.021-8",	"07.000.507-0", "04.104.862-9"
        };

        public IEAmazonasValidatorTests()
            : base(UF.AM, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEAmazonasValidator(ie);
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithMoreDigitsThanAllowed()
        {
            IEAmazonasValidator ieWithInvalidSize = new IEAmazonasValidator("123456789-7");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithLessDigitsThanAllowed()
        {
            IEAmazonasValidator ieWithInvalidSize = new IEAmazonasValidator("1234567-9");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }
    }
}