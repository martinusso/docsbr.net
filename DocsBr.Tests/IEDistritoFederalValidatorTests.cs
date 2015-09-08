using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEDistritoFederalValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        {
            "07300001001-09", "07.343.623/001-77", "07.451.530/001-68", 
            "07.389.634/001-01", "07.336.802/001-60", "07.346.779/001-46", 
            "07.548.137/001-52"
        };

        private static string[] invalidValues = 
        {
            "07300001001-10", "07.343.623/001-88", "07.451.530/001-79", 
            "07.389.634/001-12", "07.336.802/001-71", "07.346.779/001-57", 
            "07.548.137/001-63"
        };

        public IEDistritoFederalValidatorTests()
            : base(UF.DF, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEDistritoFederalValidator(ie);
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithMoreDigitsThanAllowed()
        {
            IEDistritoFederalValidator ieWithInvalidSize = new IEDistritoFederalValidator("123456789012-30");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithLessDigitsThanAllowed()
        {
            IEDistritoFederalValidator ieWithInvalidSize = new IEDistritoFederalValidator("1234567890-01");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }
    }
}
