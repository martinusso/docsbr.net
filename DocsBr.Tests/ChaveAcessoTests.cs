using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DocsBr.Tests
{
    [TestClass]
    public class ChaveAcessoTests
    {
        private int UF = 42;
        private int Ano = 1984;
        private int Mes = 09;
        private string CNPJ = "99999999000191";
        private string Modelo = "57";
        private string Serie = "1";
        private string Numero = "123456789";
        private string FormaEmissao = "1";
        private string CodigoNumerico = "12345678";

        #region Chave Acesso

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), ChaveAcesso.ChaveAcessoInvalida)]
        public void TestShouldThrowArgumentNullExceptionWhenPassNullAsChaveAcesso()
        {
            var ca = new ChaveAcesso(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.DigitoVerificadorInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassInvalidChaveAcesso()
        {
            var chaveAcesso = "52060433009911002506550120000007800267301610";
            var ca = new ChaveAcesso(chaveAcesso);
        }

        [TestMethod]
        public void TestShouldSetupValidChaveAcesso()
        {
            var chaveAcesso = "52060433009911002506550120000007800267301615";

            var ca = new ChaveAcesso(chaveAcesso);
            Assert.AreEqual<int>(52, ca.UF);
            Assert.AreEqual<string>("06", ca.Ano);
            Assert.AreEqual<string>("04", ca.Mes);
            Assert.AreEqual<string>("33009911002506", ca.CNPJ);
            Assert.AreEqual<string>("55", ca.Modelo);
            Assert.AreEqual<string>("012", ca.Serie);
            Assert.AreEqual<string>("000000780", ca.Numero);
            Assert.AreEqual<string>("0", ca.FormaEmissao);
            Assert.AreEqual<string>("26730161", ca.CodigoNumerico);
            Assert.AreEqual<string>("5", ca.DigitoVerificador);
    }

        [TestMethod]
        public void TestShouldValidatesChavesAcesso()
        {
            string[] validDocs =
            {
                "52060433009911002506550120000007800267301615",
                "42100484684182000157550010000000020108042108"
            };

            foreach (var chaveAcesso in validDocs)
            {
                var ca = new ChaveAcesso(chaveAcesso);
                Assert.AreEqual<string>(chaveAcesso, ca.ToString());
            }
        }
        #endregion

        #region UF

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.UFInvalida)]
        public void TestShouldThrowArgumentExceptionWhenPassInvalidUF()
        {
            var ca = new ChaveAcesso("AA", Ano, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.UFInvalida)]
        public void TestShouldThrowArgumentExceptionWhenPassInvalidCodeUF()
        {
            var ca = new ChaveAcesso(99, Ano, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);
        }

        #endregion

        #region Ano

        [TestMethod]
        public void TestShouldThrowArgumentExceptionWhenPassYearLessThan2Chars()
        {
            var ca = new ChaveAcesso(UF, 1, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);
            Assert.AreEqual<string>("01", ca.Ano);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.AnoInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassYearWith3Chars()
        {
            var ca = new ChaveAcesso(UF, 123, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        public void TestShouldReturn2LastDigitsWhenPassYearWith4Chars()
        {
            var ca = new ChaveAcesso(UF, 1234, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);
            Assert.AreEqual<string>("34", ca.Ano);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.AnoInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassYearMoreThan4Chars()
        {
            var ca = new ChaveAcesso(UF, 12345, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);
        }

        #endregion

        #region Mês

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.MesInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassInvalidMonth()
        {
            var ca = new ChaveAcesso(UF, Ano, 13, CNPJ, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);
        }

        #endregion

        #region CNPJ

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), ChaveAcesso.CnpjInvalido)]
        public void TestShouldThrowArgumentNullExceptionWhenPassNullAsCNPJ()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, null, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.CnpjInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassInvalidCNPJ()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, "99999999000291", Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        public void TestReturnCNPJWhenPassValidCNPJ()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);
            Assert.AreEqual<string>(CNPJ, ca.CNPJ);
        }

        #endregion

        #region Modelo

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), ChaveAcesso.ModeloInvalido)]
        public void TestShouldThrowArgumentNullExceptionWhenPassNullAsModelo()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, null, Serie, Numero, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.ModeloInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassModeloMore2Numbers()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, "123", Serie, Numero, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.ModeloInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassModeloWithAlphaChars()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, "A1", Serie, Numero, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        public void TestShouldReturnZeroPaddingWhenPassModeloLess2Chars()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, "1", Serie, Numero, FormaEmissao, CodigoNumerico);
            Assert.AreEqual<string>("01", ca.Modelo);
        }

        #endregion

        #region Série

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), ChaveAcesso.SerieInvalida)]
        public void TestShouldThrowArgumentNullExceptionWhenPassNullAsSerie()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, null, Numero, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.SerieInvalida)]
        public void TestShouldThrowArgumentExceptionWhenPassSerieMore3Numbers()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, "1234", Numero, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.SerieInvalida)]
        public void TestShouldThrowArgumentExceptionWhenPassSerieWithAlphaChars()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, "12E", Numero, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        public void TestShouldReturnZeroPaddingWhenPassSerieLess3Chars()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, "1", Numero, FormaEmissao, CodigoNumerico);
            Assert.AreEqual<string>("001", ca.Serie);
        }

        #endregion

        #region Número

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), ChaveAcesso.NumeroInvalido)]
        public void TestShouldThrowArgumentNullExceptionWhenPassNullAsNumero()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, null, FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.NumeroInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassNumeroMore9Numbers()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, "1234567890", FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.NumeroInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassNumeroWithAlphaChars()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, "12EA567B9", FormaEmissao, CodigoNumerico);
        }

        [TestMethod]
        public void TestShouldReturnZeroPaddingWhenPassNumeroLess9Digits()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, "123", FormaEmissao, CodigoNumerico);
            Assert.AreEqual<string>("000000123", ca.Numero);
        }

        #endregion

        #region Forma de Emissão

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), ChaveAcesso.FormaEmissaoInvalida)]
        public void TestShouldThrowArgumentNullExceptionWhenPassNullAsFormaEmissao()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, Numero, null, CodigoNumerico);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.FormaEmissaoInvalida)]
        public void TestShouldThrowArgumentExceptionWhenPassFormaEmissaoMore1Digit()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, Numero, "12", CodigoNumerico);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.FormaEmissaoInvalida)]
        public void TestShouldThrowArgumentExceptionWhenPassFormaEmissapWithAlphaChars()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, Numero, "A", CodigoNumerico);
        }

        #endregion

        #region Código Numérico
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), ChaveAcesso.CodigoNumericoInvalido)]
        public void TestShouldThrowArgumentNullExceptionWhenPassNullAsCodigoNumerico()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.CodigoNumericoInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassCodigoNumericoMore8Digits()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, "123456789");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ChaveAcesso.CodigoNumericoInvalido)]
        public void TestShouldThrowArgumentExceptionWhenPassCodigoNumericoWithAlphaChars()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, "12E45678");
        }

        [TestMethod]
        public void TestShouldReturnZeroPaddingWhenPassCodigoNumericoLess8Digits()
        {
            var ca = new ChaveAcesso(UF, Ano, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, "123");
            Assert.AreEqual<string>("00000123", ca.CodigoNumerico);
        }
        #endregion
    }
}