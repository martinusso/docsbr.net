using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Validation.IE;

namespace DocsBr.Tests
{
    [TestClass]
    public class IEMaranhaoValidatorTests : IEValidatorTests
    {
        //private static string[] validValues = {
        //    "12.074072-9", "12000038-5", "12.233602-0", "12404921-4",
        //    "12138560-4", "12479458-0", "12046931-6", "12708673-0",
        //    "12138560-4", "12996677-0", "12957307-8", "12565693-9",
        //    "12.524713-3", "12509156-7", "12358596-1", "12659067-2"
        //};
        private static string[] validValues = { "12.233602-0" };
        private static string[] invalidValues = { "12.074072-5", "12000038-0" };

        public IEMaranhaoValidatorTests()
            : base(UF.MA, validValues, invalidValues) { }

        protected override IIEValidator GetValidator(string ie)
        {
            return new IEMaranhaoValidator(ie);
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithMoreDigitsThanAllowed()
        {
            IEMaranhaoValidator ieWithInvalidSize = new IEMaranhaoValidator("123456789-0");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateIEWithLessDigitsThanAllowed()
        {
            IEMaranhaoValidator ieWithInvalidSize = new IEMaranhaoValidator("1234567-8");
            Assert.IsFalse(ieWithInvalidSize.IsValid());
        }

        [TestMethod]
        public void TestSouldInvalidateIEWhenNotBeginsWith12()
        {
            IEMaranhaoValidator ieWith11 = new IEMaranhaoValidator("110944020");
            Assert.IsFalse(ieWith11.IsValid());
        }
    }
}
