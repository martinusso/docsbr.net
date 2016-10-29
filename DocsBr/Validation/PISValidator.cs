using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation
{
    public class PISValidator
    {
        private string rawPIS;
        public PISValidator(string pis)
        {
            rawPIS = new OnlyNumbers(pis).ToString();
        }

        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            if (HasRepeatedDigits()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return rawPIS.Length == 11;
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
            return invalidNumbers.Contains(rawPIS);
        }

        private bool HasValidCheckDigits()
        {
            string number = rawPIS.Substring(0, rawPIS.Length - 1);

            var digitoVerificador = new DigitoVerificador(number)
                                        .ComMultiplicadoresDeAte(2, 9)
                                        .Substituindo("0", 10, 11);

            return digitoVerificador.CalculaDigito() == rawPIS[rawPIS.Length - 1].ToString();
        }
    }
}
