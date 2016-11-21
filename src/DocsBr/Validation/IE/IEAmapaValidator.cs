using System;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE do Amapá
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_AP.html
    /// </remarks>
    public class IEAmapaValidator : IIEValidator
    {
        private string inscEstadual;

        public IEAmapaValidator(string inscEstadual)
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
            return this.inscEstadual.Length == 9;
        }

        private bool IsFirstDigitsValid()
        {
            return this.inscEstadual.Substring(0, 2) == "03";
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 1);

            /*
             * Define-se dois valores, p e d, de acordo com as seguintes faixas de Inscrição Estadual:
             * De 03000001 a 03017000 => p = 5 e d = 0
             * De 03017001 a 03019022 => p = 9 e d = 1
             * De 03019023 em diante ===>p = 0 e d = 0
             */
            string p = "0";
            string d = "0";
            int ie = Convert.ToInt32(number);
            if (ie <= 03017000)
            {
                p = "5";
                d = "0";
            }
            else if (ie >= 03017001 && ie <= 03019022)
            {
                p = "9";
                d = "1";
            }

            number += p;

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                        .ComMultiplicadoresDeAte(1, 9)
                                                        .Substituindo("0", 10)
                                                        .Substituindo(d, 11);

            return digitoVerificador.CalculaDigito() == this.inscEstadual.Substring(this.inscEstadual.Length - 1, 1);
        }
    }
}