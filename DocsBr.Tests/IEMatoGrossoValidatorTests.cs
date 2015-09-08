using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEMatoGrossoValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
            {"0013000001-9", "13315986-8", "0013193686-7", "0013053551-6",
                "0013056071-5", "0013151173-4", "0013210747-3", "0013125061-2", 
                "130181528-1", "0064573571-0"};

        private static string[] invalidValues = 
            {"0013015257-0", "13315986-1", "0013193686-2", "0013053551-3",
                "0013056071-4", "0013151173-5", "0013210747-6", "0013125061-7", 
                "130181528-8", "0064573571-9"};

        public IEMatoGrossoValidatorTests()
            : base(UF.MT, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEMatoGrossoValidator(ie);
        }
    }
}