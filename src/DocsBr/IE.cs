using System;
using DocsBr.Utils;
using DocsBr.Validation;

namespace DocsBr
{
    public struct IE
    {
        private UF enumUF;
        private string ie;

        public int CodigoUF
        {
            get { return enumUF.Codigo(); }
        }
        public string SiglaUF
        {
            get { return enumUF.Sigla(); }
        }

        public IE(string inscEstadual, int uf)
        {
            this.ie = inscEstadual;
            this.enumUF = (UF)uf;
        }

        public IE(string inscEstadual, string uf)
        {
            this.ie = inscEstadual;
            Enum.TryParse(uf, out this.enumUF);
        }

        public override string ToString()
        {
            return this.ie;
        }

        public string SemMascara()
        {
            return new OnlyNumbers(this.ie).ToString();
        }

        public bool IsValid()
        {
            IEValidator validatorIE = new IEValidator(ie, enumUF);
            return validatorIE.IsValid();
        }

        public bool Equals(IE inscEstadual)
        {
            return this.ie.Equals(inscEstadual.ToString())
                && this.CodigoUF.Equals(inscEstadual.CodigoUF);
        }
    }
}