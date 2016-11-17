using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE de Roraima
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_RR.html
    /// </remarks>
    public class IERoraimaValidator : IIEValidator
    {
        private string inscEstadual;

        public IERoraimaValidator(string inscEstadual)
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
            return this.inscEstadual.Length == 9;
        }

        private bool BeginsCorrectly()
        {
            return this.inscEstadual.Substring(0, 2) == "24";
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 1);

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                    .Modulo(9)
                                                    .ComMultiplicadoresDeAte(1, 8)
                                                    .InvertendoMultiplicadores()
                                                    .SemComplementarDoModulo();
            return digitoVerificador.CalculaDigito() == this.inscEstadual.Substring(this.inscEstadual.Length - 1, 1);
        }
    }
}