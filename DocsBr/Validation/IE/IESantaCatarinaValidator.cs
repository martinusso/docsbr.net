using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE de Santa Catarina
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_SC.html
    /// </remarks>
    public class IESantaCatarinaValidator : IIEValidator
    {
        private string inscEstadual;

        public IESantaCatarinaValidator(string inscEstadual)
        {
            this.inscEstadual = new OnlyNumbers(inscEstadual).ToString();
        }

        public bool IsValid()
        {
            return HasValidCheckDigits();
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