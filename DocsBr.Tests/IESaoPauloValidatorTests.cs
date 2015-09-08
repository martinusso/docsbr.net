using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IESaoPauloValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "110.042.490.114", "110.042.490.114", "P-011000424.3/002" };

        private static string[] invalidValues = { "110.042.490.110", "A-011000424.3/002", "P-111000424.3/002", };

        public IESaoPauloValidatorTests()
            : base(UF.SP, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IESaoPauloValidator(ie);
        }
    }
}