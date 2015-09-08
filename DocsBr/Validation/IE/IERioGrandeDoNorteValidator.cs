using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE do Rio Grande do Norte
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_RN.html
    /// </remarks>
    public class IERioGrandeDoNorteValidator : IIEValidator
    {
        private string inscEstadual;

        public IERioGrandeDoNorteValidator(string inscEstadual)
        {
            this.inscEstadual = new OnlyNumbers(inscEstadual).ToString();
        }

        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            if (!BeginsCorrectly()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return this.inscEstadual.Length == 9
                || this.inscEstadual.Length == 10;
        }

        private bool BeginsCorrectly()
        {
            return this.inscEstadual.Substring(0, 2) == "20";
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 1);

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                    .ComMultiplicadoresDeAte(2, 10)
                                                    .Substituindo("0", 10, 11);
            return digitoVerificador.CalculaDigito() == this.inscEstadual.Substring(this.inscEstadual.Length - 1, 1);
        }
    }
}