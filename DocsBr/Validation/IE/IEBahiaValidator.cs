using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE da Bahia
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_BA.html
    /// Para Inscrições cujo primeiro dígito é 0, 1, 2, 3, 4, 5, 8 cálculo pelo módulo 10.
    /// Para Inscrições cujo primeiro dígito é 6, 7, 9 cálculo pelo módulo 11.
    /// </remarks>
    public class IEBahiaValidator : IIEValidator
    {
        private string inscEstadual;

        public IEBahiaValidator(string inscEstadual)
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
            return this.inscEstadual.Length == 8
                || this.inscEstadual.Length == 9;
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 2);
            int mod = GetMod();

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                        .Modulo(mod)
                                                        .ComMultiplicadoresDeAte(2, 9)
                                                        .Substituindo("0", 10, 11);
            string secondDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(secondDigit);
            string firstDigit = digitoVerificador.CalculaDigito();
            
            return String.Concat(firstDigit, secondDigit) == this.inscEstadual.Substring(this.inscEstadual.Length - 2, 2);
        }

        private int GetMod()
        {
            string[] numerosComMod10 = {"0", "1", "2", "3", "4", "5", "8"};
            string verificador;
            if (this.inscEstadual.Length == 8) 
            {
                verificador = this.inscEstadual.Substring(0, 1);
            }
            else 
            {
                verificador = this.inscEstadual.Substring(1, 1);
            }
            return numerosComMod10.Contains(verificador) ? 10 : 11;
        }
    }
}
