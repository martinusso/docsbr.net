using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEParaibaValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "06000001-5", "16.000.001-7" };

        private static string[] invalidValues = { "06000001-0", "16.000.001-0", "123456789-7" };

        public IEParaibaValidatorTests()
            : base(UF.PB, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEParaibaValidator(ie);
        }
    }
}