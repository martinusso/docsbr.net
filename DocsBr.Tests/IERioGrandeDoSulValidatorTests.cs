using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IERioGrandeDoSulValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "224/3658792", "050/0068836" };

        private static string[] invalidValues = { "224/3658793" };

        public IERioGrandeDoSulValidatorTests()
            : base(UF.RS, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IERioGrandeDoSulValidator(ie);
        }
    }
}