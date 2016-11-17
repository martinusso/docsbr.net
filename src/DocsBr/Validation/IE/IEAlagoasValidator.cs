using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    public class IEAlagoasValidator : IIEValidator
    {
        private string inscEstadual;

        public IEAlagoasValidator(string inscEstadual)
        {
            this.inscEstadual = new OnlyNumbers(inscEstadual).ToString(); 
        }

        public bool IsValid()
        {
            if (!IsCompanyTypeValid()) return false;
            return HasValidCheckDigits();
        }

        private bool IsCompanyTypeValid()
        {
            /*
             * X – Tipo de empresa (
             *  0-Normal, 
             *  3-Produtor Rural, 
             *  5-Substituta, 
             *  7- Micro-Empresa Ambulante, 
             *  8-Micro-Empresa)
             */
            string[] validTypes = {"0", "3", "5", "7", "8"};
            string number = this.inscEstadual.Substring(2, 1);
            return validTypes.Contains(number);
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 1);

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                    .Substituindo("0", 10, 11);
            return digitoVerificador.CalculaDigito() == this.inscEstadual.Substring(this.inscEstadual.Length - 1, 1);
        }
    }
}
