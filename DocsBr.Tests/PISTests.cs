using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocsBr.Tests
{
    [TestClass]
    public class PISTests
    {
        private static string[] validNumbers = { "161.83161.83-8", "595.69595.69-0", "963.82963.82-7", "310.02666.69-3", "62241377790", "17367122299" };
        private static string[] invalidNumbers = { "12345678901", "315.02666.69-7", "62241377791", };

        [TestMethod]
        public void TestShouldValidatePIS()
        {
            foreach (PIS pis in validNumbers)
            {
                Assert.IsTrue(pis.IsValid(), pis);
            }
        }

        [TestMethod]
        public void TestShouldNotValidatePIS()
        {
            foreach (PIS pis in invalidNumbers)
            {
                Assert.IsFalse(pis.IsValid(), pis);
            }
        }

        [TestMethod]
        public void TestShouldInvalidatePISWhenEmpty()
        {
            PIS pis = "";
            Assert.IsFalse(pis.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidatePISWhenRepeatedDigits()
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
 
            foreach (PIS pis in invalidNumbers)
            {
                Assert.IsFalse(pis.IsValid(), pis);
            }
        }

        [TestMethod]
        public void TestShouldReturnEqualsWhenComparedFormattedAndUnformattedPIS()
        {
            PIS pisWithMask = "595.69595.69-0";
            PIS pisWithoutMask = "59569595690";
            Assert.IsTrue(pisWithMask.Equals(pisWithoutMask));
        }
 
        [TestMethod]
        public void TestShouldReturnNotEqualsWhenComparedDifferentPIS()
        {
            PIS pis1 = "96382963820";
            PIS pis2 = "96382963827";
            Assert.IsFalse(pis1.Equals(pis2));
        }
 
        [TestMethod]
        public void TestShouldReturnEmptyPISWhenPassNull()
        {
            PIS pis = null;
            Assert.AreEqual<string>("", pis);
            Assert.AreEqual<string>("", pis.ComMascara());
        }
    }
}
