using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEPiauiValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "012345679", "16.907.872-8", "81.806.022-0", "19.301.656-7" };

        private static string[] invalidValues = { "01234567-0", "16.907.872-9", "81.806.022-1", "19.301.656-8" };

        public IEPiauiValidatorTests()
            : base(UF.PI, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEPiauiValidator(ie);
        }
    }
}