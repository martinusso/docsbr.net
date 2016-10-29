using DocsBr.Utils;
using System.Linq;

namespace DocsBr.Validation
{
    class SUFRAMAValidator
    {
        private string rawSUFRAMA;

        public SUFRAMAValidator(string suframa)
        {
            rawSUFRAMA = new OnlyNumbers(suframa).ToString();
        }

        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            if (!IsSSValid()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return new[] { 8, 9 }.Contains(rawSUFRAMA.Length);
        }

        private bool IsSSValid()
        {
            return rawSUFRAMA.Substring(0, 2) != "00";
        }

        private bool HasValidCheckDigits()
        {
            string number = rawSUFRAMA.Substring(0, rawSUFRAMA.Length - 1);

            var digitoVerificador = new DigitoVerificador(number)
                                        .ComMultiplicadoresDeAte(2, 9)
                                        .Substituindo("0", 10, 11);
            return digitoVerificador.CalculaDigito() == rawSUFRAMA[rawSUFRAMA.Length - 1].ToString();
        }
    }
}
