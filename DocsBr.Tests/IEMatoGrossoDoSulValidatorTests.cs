using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEMatoGrossoDoSulValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "28.322.235-2", "28.301.273-0",
            "28.288.890-0", "28.226.590-2", "28.296.665-0",
            "28.303.740-7", "28.306.701-2", "28.071.810-1",
            "28.311.591-2","28.098.983-0", "28.316.487-5",
            "28.639.242-9","28.330.011-6", "28.211.197-2" };

        private static string[] invalidValues = { "28.322.235-3", "28.301.273-1",
            "28.288.890-1", "28.226.590-3", "28.296.665-1",
            "28.303.740-8", "28.306.701-3", "28.071.810-2",
            "28.311.591-3","28.098.983-1", "28.316.487-6",
            "28.639.242-0","28.330.011-7", "28.211.197-3",
            "123456780"};

        public IEMatoGrossoDoSulValidatorTests()
            : base(UF.MS, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEMatoGrossoDoSulValidator(ie);
        }
    
        [TestMethod]
        public void TestShouldInvalidateIEWithMoreDigitsThanAllowed()
        {
            IEMatoGrossoDoSulValidator ieWithInvalidSize = new IEMatoGrossoDoSulValidator("2812345678");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithLessDigitsThanAllowed()
        {
            IEMatoGrossoDoSulValidator ieWithInvalidSize = new IEMatoGrossoDoSulValidator("28123456");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }
    }
}