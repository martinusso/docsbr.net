using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Utils;
using DocsBr.Validation;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    public class IEValidatorTests
    {
        private UF uf;
        private string[] validValues;
        private string[] invalidValues;

        public IEValidatorTests(UF uf, string[] validValues, string[] invalidValues)
        {
            this.uf = uf;
            this.validValues = validValues;
            this.invalidValues = invalidValues;
        }

        protected virtual IIEValidator GetValidator(string ie) { return null; }

        [TestMethod]
        public void TestShouldValidateIE()
        {
            
            foreach(string s in validValues) 
            {
                var ieValidator = GetValidator(s);
                Assert.IsTrue(ieValidator.IsValid(), s);
            }
        }

        [TestMethod]
        public void TestShouldInvalidateIE()
        {
            foreach (string s in invalidValues)
            {
                var ieValidator = GetValidator(s);
                Assert.IsFalse(ieValidator.IsValid(), s);
            }
        }

        [TestMethod]
        public void TestShouldValidateIEByIEValidator()
        {
            IEValidator ieValidator = new IEValidator(validValues[0], uf);
            Assert.IsTrue(ieValidator.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEByIEValidator()
        {
            IEValidator ieValidator = new IEValidator(invalidValues[0], uf);
            Assert.IsFalse(ieValidator.IsValid());
        }
    }
}
