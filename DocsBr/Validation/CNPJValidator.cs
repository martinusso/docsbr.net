using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation
{
    public class CNPJValidator
    {
        private static int sizeCNPJ = 14;
        private string rawCNPJ;

        public CNPJValidator(string cnpj)
        {
            this.rawCNPJ = new OnlyNumbers(cnpj).ToString();
        }

        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            if (HasRepeatedDigits()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return this.rawCNPJ.Length == sizeCNPJ;
        }

        private bool HasRepeatedDigits()
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(this.rawCNPJ);
        }

        private bool HasValidCheckDigits()
        {
            string number = this.rawCNPJ.Substring(0, sizeCNPJ - 2);

            var digitoVerificador = new DigitoVerificador(number)
                                        .ComMultiplicadoresDeAte(2, 9)
                                        .Substituindo("0", 10, 11);
            string firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            string secondDigit = digitoVerificador.CalculaDigito();

            return String.Concat(firstDigit, secondDigit) == this.rawCNPJ.Substring(sizeCNPJ - 2, 2);
        }
    }
}