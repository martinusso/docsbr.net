using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEAcreValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        { 
            "01.004.823/001-12", "01.004.141/001-46", "01.001.349/001-77",
            "01.956.867/001-07", "01.379.333/036-16", "01.367.306/773-60",
            "01.658.566/892-98", "01.689.555/741-67"
        };

        private static string[] invalidValues = 
        {
            "12.345.678.901-07", "01.004.823/001-02"
        };

        public IEAcreValidatorTests()
            : base(UF.AC, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEAcreValidator(ie);
        }
        
        [TestMethod]
        public void TestShouldInvalidateIEWithMoreDigitsThanAllowed()
        {
            IEAcreValidator ieWithInvalidSize = new IEAcreValidator("012345678901-07");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithLessDigitsThanAllowed()
        {
            IEAcreValidator ieWithInvalidSize = new IEAcreValidator("0123456789-78");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }
    }
}