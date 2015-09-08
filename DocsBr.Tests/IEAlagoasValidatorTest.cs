using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEAlagoasValidatorTest : IEValidatorTests
    {
        private static string[] validValues = 
        { 
            "24.076.739-0", "24.089.826-5", "24.099.991-6", "24.067.173-2",
            "24.079.990-9", "24.089.451-0", "24.080.152-0", "24.092.497-5", 
            "24.088.932-0", "24.097.262-7", "24.086.162-0", "24.097.871-4", 
            "24.085.016-5", "24.073.874-8", "24.071.760-0", "24.065.706-3",
        };

        private static string[] invalidValues =
        { 
            "24.076.739-1", "24.103.644-5", "24.102.358-0", "999456789-1"
        };

        public IEAlagoasValidatorTest() : base(UF.AL, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEAlagoasValidator(ie);
        }
    }
}