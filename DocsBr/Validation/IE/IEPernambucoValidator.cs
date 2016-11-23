using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE do Pernambuco
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_PE.html
    /// </remarks>
    public class IEPernambucoValidator : IIEValidator
    {
        private string inscEstadual;

        public IEPernambucoValidator(string inscEstadual)
        {
            this.inscEstadual = new OnlyNumbers(inscEstadual).ToString();
        }

        public bool IsValid()
        {
            // validação antiga
            bool IsValidacaoAntiga = this.inscEstadual.Length == 14;
            if (IsValidacaoAntiga) 
            {
                return HasValidOldRules();
            }
            // validação nova
            if (!IsSizeValid()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return this.inscEstadual.Length == 9;
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

        private bool HasValidOldRules()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 1);
            // necessário para permitir os multiplicadores 1..9
            number = String.Concat(number, "0");

            DigitoVerificador digitoVerificador = 
                new DigitoVerificador(number).ComMultiplicadoresDeAte(1, 9).Substituindo("0", 10, 11);
            return digitoVerificador.CalculaDigito() == this.inscEstadual.Substring(this.inscEstadual.Length - 1, 1);
        }
    }
}