using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEBahiaValidatorTest : IEValidatorTests
    {
        private static string[] validValues = 
        {
            "612345-57", "123456-63", "1000003-06", "1057652-04", "0635718-30", "0770288-84", "77.028.884",
        };

        private static string[] invalidValues = 
        {
            "612345-67", "123456-73", "1000003-16", "1057652-05", "0635718-31", "0770288-94", "77.028.880",
        };

        public IEBahiaValidatorTest()
            : base(UF.BA, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEBahiaValidator(ie);
        }
        
        [TestMethod]
        public void TestShouldInvalidateIEWithMoreDigitsThanAllowed()
        {
            IEBahiaValidator ieWithInvalidSize = new IEBahiaValidator("1234567884");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithLessDigitsThanAllowed()
        {
            IEBahiaValidator ieWithInvalidSize = new IEBahiaValidator("1234567");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }
    }
}
