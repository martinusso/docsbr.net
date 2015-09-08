using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IESergipeValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        { 
            "27123456-3", "44.250.767-4", "67.893.465-7", 
        };

        private static string[] invalidValues = 
        { 
            "27123456-0", "271234561-9",
        };

        public IESergipeValidatorTests()
            : base(UF.SE, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IESergipeValidator(ie);
        }
    }
}