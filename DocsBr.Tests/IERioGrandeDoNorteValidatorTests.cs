using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IERioGrandeDoNorteValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "20.040.040-1", "20.0.040.040-0", "20.5.276.231-0" };

        private static string[] invalidValues = { "20.040.040-0", "20.0.040.040-1", "99.999.99-4", "19.0.040.040-5" };

        public IERioGrandeDoNorteValidatorTests()
            : base(UF.RN, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IERioGrandeDoNorteValidator(ie);
        }
    }
}