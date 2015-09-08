using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEParaValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        { 
            "15999999-5", "15.229.851-7", "15.133.081-6", "15.143.772-6",
    		"15.191.809-0", "15.133.081-6", "15.105.561-0", "15.069.510-1",
            "15.002.934-9", "15.133.041-7", "15.887.063-8" 
        };

        private static string[] invalidValues = { "15999999-0" };

        public IEParaValidatorTests()
            : base(UF.PA, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEParaValidator(ie);
        }
    }
}