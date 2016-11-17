using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE do Tocantins
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_TO.html
    /// </remarks>
    public class IETocantinsValidator : IIEValidator
    {
        private string inscEstadual;

        public IETocantinsValidator(string inscEstadual)
        {
            this.inscEstadual = new OnlyNumbers(inscEstadual).ToString();
        }

        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            if (!HasValid3rdAnd4thDigits()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return this.inscEstadual.Length == 11;
        }

        private bool HasValid3rdAnd4thDigits()
        {
            string[] validNumbers = {
                                        "01", // Produtor Rural (não possui CGC)
                                        "02", // Industria e Comércio
                                        "03", // Empresas Rudimentares
                                        "99", // Empresas do Cadastro Antigo (SUSPENSAS)
                                    };
            return validNumbers.Contains(this.inscEstadual.Substring(2, 2));
        }

        private bool HasValidCheckDigits()
        {
            string number = String.Concat(this.inscEstadual.Substring(0, 2), this.inscEstadual.Substring(4, 6));
            DigitoVerificador digitoVerificador = 
                new DigitoVerificador(number).ComMultiplicadoresDeAte(2, 9).Substituindo("0", 10, 11);
            return digitoVerificador.CalculaDigito() == this.inscEstadual.Substring(this.inscEstadual.Length - 1, 1);
        }
    }
}