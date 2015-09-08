using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEPernambucoValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        { 
            "0321418-40", 
            "18.1.001.0000004-9" 
        };

        private static string[] invalidValues = { "0321418-00", "18.1.001.0000004-0" };

        public IEPernambucoValidatorTests()
            : base(UF.PE, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEPernambucoValidator(ie);
        }
    }
}