using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEGoiasValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        { 
            "10.987.654-7", "10.103.119-1", "15.368.273-6", 
            "15.368.273-6", "110944020", "110944021" 
        };

        private static string[] invalidValues = { "10.987.654-8", "10.103.119-2", "15.368.273-7", "12.345.678-9" };

        public IEGoiasValidatorTests()
            : base(UF.GO, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEGoiasValidator(ie);
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithMoreDigitsThanAllowed()
        {
            IEGoiasValidator ieWithInvalidSize = new IEGoiasValidator("103456789-3");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithLessDigitsThanAllowed()
        {
            IEGoiasValidator ieWithInvalidSize = new IEGoiasValidator("1034567-1");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }
    }
}
