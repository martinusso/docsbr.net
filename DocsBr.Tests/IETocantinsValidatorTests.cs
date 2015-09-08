using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IETocantinsValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        { 
            "29.01.022783-6", "29.01.040634-0", "29.01.385.524-2", "29.01.032.038-0", "29.01.074.854-2"
        };

        private static string[] invalidValues = 
        { 
            "29 01 022783 0", "29.04.022783-6", "29.022783-6", 
        };

        public IETocantinsValidatorTests()
            : base(UF.TO, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IETocantinsValidator(ie);
        }
    }
}