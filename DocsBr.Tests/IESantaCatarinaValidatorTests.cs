using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IESantaCatarinaValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "251.040.852", "214562549", "241603331" };

        private static string[] invalidValues = { "251.040.850", };

        public IESantaCatarinaValidatorTests()
            : base(UF.SC, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IESantaCatarinaValidator(ie);
        }
    }
}