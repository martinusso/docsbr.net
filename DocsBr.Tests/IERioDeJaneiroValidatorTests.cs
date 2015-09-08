using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IERioDeJaneiroValidatorTests : IEValidatorTests
    {
        private static string[] validValues = { "99.999.99-3", "78045302" };

        private static string[] invalidValues = { "99.999.99-0", "78045304", "19.301.656-1" };

        public IERioDeJaneiroValidatorTests()
            : base(UF.RJ, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IERioDeJaneiroValidator(ie);
        }
    }
}