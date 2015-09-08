using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation
{
    public class CPFValidator
    {
        private static int sizeCPF = 11;
        private string rawCPF;

        public CPFValidator(string cpf)
        {
            this.rawCPF = new OnlyNumbers(cpf).ToString();
        }

        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            if (HasRepeatedDigits()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return this.rawCPF.Length == sizeCPF;
        }

        private bool HasRepeatedDigits()
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
            return invalidNumbers.Contains(this.rawCPF);
        }

        private bool HasValidCheckDigits()
        {
            string number = this.rawCPF.Substring(0, sizeCPF - 2);
            var digitoVerificador = new DigitoVerificador(number)
                                        .ComMultiplicadoresDeAte(2, 11)
                                        .Substituindo("0", 10, 11);
            string firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            string secondDigit = digitoVerificador.CalculaDigito();

            return String.Concat(firstDigit, secondDigit) == this.rawCPF.Substring(sizeCPF - 2, 2);
        }
    }
}