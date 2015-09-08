using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocsBr.Utils;

namespace DocsBr.Tests.Core
{
    [TestClass]
    public class DigitoVerificadorTests
    {
        [TestMethod]
        public void TestShouldReturnCheckDigitOfCNPJ()
        {
            string cnpj = "999999990001";

            DigitoVerificador digitoVerificador = new DigitoVerificador(cnpj)
                                                        .ComMultiplicadoresDeAte(2, 9)
                                                        .Substituindo("0", 10, 11);
            string firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            string secondDigit = digitoVerificador.CalculaDigito();
            Assert.AreEqual("91", String.Concat(firstDigit, secondDigit));
        }

        [TestMethod]
        public void TestShouldReturnCheckDigitOfCPF()
        {
            string cpf = "123456789";
            int lastMultiplier = 11;

            DigitoVerificador digitoVerificador = new DigitoVerificador(cpf)
                                                    .ComMultiplicadoresDeAte(2, lastMultiplier)
                                                    .Substituindo("0", 10, 11);
            string firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            string secondDigit = digitoVerificador.CalculaDigito();
            Assert.AreEqual("09", String.Concat(firstDigit, secondDigit));
        }

        [TestMethod]
        public void TestShouldReturnCheckDigitOfEmptyNumber()
        {
            string cnpj = "";
            int lastMultiplier = 11;

            DigitoVerificador digitoVerificador = new DigitoVerificador(cnpj)
                .ComMultiplicadoresDeAte(2, lastMultiplier).Substituindo("0", 0, 1);
            Assert.AreEqual("", digitoVerificador.CalculaDigito());
        }
    }
}