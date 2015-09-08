using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IECearaValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        {
            "06000001-5", "06.998.161-2", "06.864.509-0", "06.031.909-7", 
        };

        private static string[] invalidValues = 
        {
            "06000001-6", "06.998.161-3", "06.864.509-1", "06.031.909-8", 
        };

        public IECearaValidatorTests()
            : base(UF.CE, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IECearaValidator(ie);
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithMoreDigitsThanAllowed()
        {
            IECearaValidator ieWithInvalidSize = new IECearaValidator("123456789-7");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithLessDigitsThanAllowed()
        {
            IECearaValidator ieWithInvalidSize = new IECearaValidator("1234567-9");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }
    }
}
