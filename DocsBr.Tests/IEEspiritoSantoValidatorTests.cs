using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEEspiritoSantoValidatorTests : IEValidatorTests
    {
        private static string[] validValues = 
        {
            "99999999-0", "082.260.66-4", "081.877.45-5",
            "395.333.85-7", "322.589.71-1", "916.453.75-8",
        };

        private static string[] invalidValues = 
        {
            "99999999-1", "082.260.66-5", "081.877.45-6",
            "395.333.85-8", "322.589.71-2", "916.453.75-9",
        };

        public IEEspiritoSantoValidatorTests()
            : base(UF.ES, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEEspiritoSantoValidator(ie);
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithMoreDigitsThanAllowed()
        {
            IEEspiritoSantoValidator ieWithInvalidSize = new IEEspiritoSantoValidator("123456789-7");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithLessDigitsThanAllowed()
        {
            IEEspiritoSantoValidator ieWithInvalidSize = new IEEspiritoSantoValidator("1234567-9");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }
    }
}
