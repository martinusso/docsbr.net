using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEParanaValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        { 
            "123.45678-50", "099.00004-09", "826.01749-09", "902.33203-01", "738.00291-16",
        };

        private static string[] invalidValues = { "123.45678-00" };

        public IEParanaValidatorTests()
            : base(UF.PR, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEParanaValidator(ie);
        }
    }
}