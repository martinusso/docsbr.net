using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IERondoniaValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "0000000062521-3", "0000000172158-5" };

        private static string[] invalidValues = { "101.62521-4", "00000101.62521-3", };

        public IERondoniaValidatorTests()
            : base(UF.RO, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IERondoniaValidator(ie);
        }
    }
}