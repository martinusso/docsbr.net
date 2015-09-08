using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IERoraimaValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        { 
            "24006628-1", "24001755-6", "24003429-0", "24001360-3", "24008266-8",
            "24006153-6", "24007356-2", "24005467-4", "24004145-5", "24001340-7",
        };

        private static string[] invalidValues = 
        { 
            "24006628-2", "24001755-7", "24003429-1", "24001360-4", "24008266-9",
            "24006153-7", "24007356-3", "24005467-5", "24004145-6", "24001340-8",
        };

        public IERoraimaValidatorTests()
            : base(UF.RR, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IERoraimaValidator(ie);
        }
    }
}