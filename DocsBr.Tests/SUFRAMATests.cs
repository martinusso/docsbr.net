using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocsBr.Tests
{
    [TestClass]
    public class SUFRAMATests
    {
        private static string[] validValues =
        {
            "55.0309.01-2", "100698107", "11.1279.10-0", "100955100", "10.1040.10-5", "101362102",
            "10.0695.10-8", "101160100", "60.0215.10-5", "111266106", "10.0170.10-2", "101416105",
            "10.1200.10-2", "110344103", "11.1273.10-2", "100480101", "10.0628.10-9", "100394108",
            "10.1289.10-3", "101139101", "10.0880.10-0", "100826105", "11.0410.10-6", "100764100",
            "11.0425.10-3", "100965105",
        };

        private static string[] invalidValues =
        {
            "1103441", "000965100", "100965100", "1009651000",
        };

        [TestMethod]
        public void TestShouldValidateSUFRAMA()
        {
            foreach (SUFRAMA suframa in validValues)
            {
                Assert.IsTrue(suframa.IsValid(), suframa);
            }
        }

        [TestMethod]
        public void TestShouldInvalidateSUFRAMA()
        {
            foreach (SUFRAMA suframa in invalidValues)
            {
                Assert.IsFalse(suframa.IsValid(), suframa);
            }
        }

        [TestMethod]
        public void TestShouldReturnUnformattedSUFRAMA()
        {
            SUFRAMA suframa = "55.0309.01-2";
            Assert.AreEqual<string>("550309012", suframa);
            Assert.AreEqual<string>("550309012", suframa.SemMascara());
        }

        [TestMethod]
        public void TestShouldReturnFormattedSUFRAMA()
        {
            SUFRAMA suframa = "100698107";
            Assert.AreEqual("10.0698.10-7", suframa.ComMascara());

            suframa = "12345678";
            Assert.AreEqual("12.345.67-8", suframa.ComMascara());
        }

        [TestMethod]
        public void TestShouldReturnEmptySUFRAMA()
        {
            SUFRAMA suframa = "";
            Assert.AreEqual("", suframa.ToString());
        }

        [TestMethod]
        public void TestShouldInvalidateSUFRAMAWhenEmpty()
        {
            SUFRAMA suframa = "";
            Assert.IsFalse(suframa.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateSUFRAMAWhenRepeatedDigits()
        {
            string[] invalidNumbers =
            {
                "000000000",
                "111111111",
                "222222222",
                "333333333",
                "444444444",
                "555555555",
                "666666666",
                "777777777",
                "888888888",
                "999999999"
            };

            foreach (SUFRAMA suframa in invalidNumbers)
            {
                Assert.IsFalse(suframa.IsValid(), suframa);
            }
        }

        [TestMethod]
        public void TestShouldReturnEqualsWhenComparedFormattedAndUnformattedSUFRAMA()
        {
            SUFRAMA suframaWithMask = "55.0309.01-2";
            SUFRAMA suframaWithoutMask = "550309012";
            Assert.IsTrue(suframaWithMask.Equals(suframaWithoutMask));
        }

        [TestMethod]
        public void TestShouldReturnNotEqualsWhenComparedDifferentSUFRAMA()
        {
            SUFRAMA suframa1 = "550309012";
            SUFRAMA suframa2 = "550309010";
            Assert.IsFalse(suframa1.Equals(suframa2));
        }

        [TestMethod]
        public void TestShouldReturnEmptySUFRAMAWhenPassNull()
        {
            SUFRAMA suframa = null;
            Assert.AreEqual<string>("", suframa);
            Assert.AreEqual<string>("", suframa.ComMascara());
        }
    }
}
