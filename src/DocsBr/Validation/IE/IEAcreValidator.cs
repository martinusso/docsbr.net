using System;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE do Acre
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_AC.html
    /// </remarks>
    public class IEAcreValidator : IIEValidator
    {
        private string inscEstadual;

        public IEAcreValidator(string inscEstadual)
        {
            this.inscEstadual = new OnlyNumbers(inscEstadual).ToString(); 
        }

        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            if (!IsFirstDigitsValid()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return this.inscEstadual.Length == 13;
        }

        private bool IsFirstDigitsValid()
        {
            return this.inscEstadual.Substring(0, 2) == "01";
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 2);

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                    .ComMultiplicadoresDeAte(2, 9)
                                                    .Substituindo("0", 10, 11);
            string firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            string secondDigit = digitoVerificador.CalculaDigito();

            return String.Concat(firstDigit, secondDigit) == this.inscEstadual.Substring(this.inscEstadual.Length - 2, 2);
        }
    }
}