﻿using System;
using System.Linq;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE de Maranhão
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL:
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_MA.html
    /// </remarks>
    public class IEMaranhaoValidator : IIEValidator
    {
        private string inscEstadual;

        public IEMaranhaoValidator(string inscEstadual)
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
            return this.inscEstadual.Substring(0, 2) == "12";
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 1);

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                        .ComMultiplicadoresDeAte(2, 9)
                                                        .Substituindo("0", 11, 10);

            return digitoVerificador.CalculaDigito() == this.inscEstadual.Substring(this.inscEstadual.Length - 1, 1);
        }
    }
}