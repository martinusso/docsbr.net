using System;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE do Ceará
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_CE.html
    /// </remarks>
    public class IECearaValidator : IIEValidator
    {
        private string inscEstadual;

        public IECearaValidator(string inscEstadual)
        {
            this.inscEstadual = new OnlyNumbers(inscEstadual).ToString(); 
        }

        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return this.inscEstadual.Length == 9;
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 1);

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                        .ComMultiplicadoresDeAte(2, 9)
                                                        .Substituindo("0", 10, 11);
            return digitoVerificador.CalculaDigito() == this.inscEstadual.Substring(this.inscEstadual.Length - 1, 1);
        }
    }
}