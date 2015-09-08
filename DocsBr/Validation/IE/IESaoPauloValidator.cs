using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE de São Paulo
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_SP.html
    /// </remarks>
    public class IESaoPauloValidator : IIEValidator
    {
        private string inscEstadual;
        private bool isProdutorRural;

        public IESaoPauloValidator(string inscEstadual)
        {
            this.isProdutorRural = (inscEstadual.Substring(0, 1).ToUpper() == "P");
            this.inscEstadual = new OnlyNumbers(inscEstadual).ToString();
        }

        public bool IsValid()
        {
            if (this.isProdutorRural)
            {
                return HasValidIEProdutorRural();
            }
            return HasValidIENormal();
        }

        private bool HasValidIENormal()
        {
            if (!IsSizeValidIENormal()) return false;
            return HasValidCheckDigitsNormal();
        }

        private bool IsSizeValidIENormal()
        {
            return this.inscEstadual.Length == 12;
        }

        private bool HasValidCheckDigitsNormal()
        {
            string posicaoNove = this.inscEstadual.Substring(8, 1);
            string posicaoDoze = this.inscEstadual.Substring(11, 1);

            string numeroParaPrimeiroDigito = this.inscEstadual.Substring(0, 8);
            string primeiroDigito = GetPrimeiroDigitoVerificador(numeroParaPrimeiroDigito);

            string numeroParaSegundoDigito = String.Concat(this.inscEstadual.Substring(0, 8),
                                                primeiroDigito,
                                                this.inscEstadual.Substring(9, 2));
            string segundoDigito = GetSegundoDigitoVerificador(numeroParaSegundoDigito);

            return primeiroDigito.Equals(posicaoNove)
                && segundoDigito.Equals(posicaoDoze);
        }

        private string GetPrimeiroDigitoVerificador(string numero)
        {
            return new DigitoVerificador(numero)
                        .ComMultiplicadores(1, 3, 4, 5, 6, 7, 8, 10)
                        .InvertendoMultiplicadores()
                        .Substituindo("0", 10)
                        .Substituindo("1", 11)
                        .SemComplementarDoModulo()
                        .CalculaDigito();
        }

        private string GetSegundoDigitoVerificador(string numero)
        {
            return new DigitoVerificador(numero)
                        .ComMultiplicadoresDeAte(2, 10)
                        .Substituindo("0", 10)
                        .Substituindo("1", 11)
                        .SemComplementarDoModulo()
                        .CalculaDigito();
        }

        private bool HasValidIEProdutorRural()
        {
            if (!IsSizeValidIEProdutorRural()) return false;
            return HasValidCheckDigitsProdutorRural();
        }

        private bool IsSizeValidIEProdutorRural()
        {
            return this.inscEstadual.Length == 13;
        }

        private bool HasValidCheckDigitsProdutorRural()
        {
            string numero = this.inscEstadual.Substring(0, 8);
            string primeiroDigito = GetPrimeiroDigitoVerificador(numero);
            return primeiroDigito.Equals(this.inscEstadual.Substring(8, 1));
        }
    }
}