using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEMinasGeraisValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "062.307.904/0081", "7029855470002", "0635438346878" };

        private static string[] invalidValues = { "062.307.904/0000", "7029855470012", "0635438346870" };

        public IEMinasGeraisValidatorTests()
            : base(UF.MG, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEMinasGeraisValidator(ie);
        }
    }
}