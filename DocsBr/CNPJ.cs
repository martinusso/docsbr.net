using System;
using DocsBr.Utils;
using DocsBr.Validation;

namespace DocsBr
{
    public struct CNPJ
    {
        public string Numero { get; set; }

        public CNPJ(string cnpj)
            : this()
        {
            this.Numero = new OnlyNumbers(cnpj).ToString();
        }

        public static implicit operator string (CNPJ cnpj)
        {
            return cnpj.Numero;
        }

        public static implicit operator CNPJ(string cnpj)
        {
            if (cnpj == null)
                cnpj = "";

            return new CNPJ(cnpj);
        }

        public override string ToString()
        {
            return SemMascara();
        }

        public string ComMascara()
        {
            if (this.Numero == "")
                return "";

            string pattern = @"{0:00\.000\.000\/0000\-00}";
            return String.Format(pattern, Convert.ToUInt64(this.Numero));
        }

        public string SemMascara()
        {
            return this.Numero;
        }

        public bool IsValid()
        {
            return new CNPJValidator(this.Numero).IsValid();
        }

        public bool Equals(CNPJ cnpj)
        {
            return this.Numero == cnpj.SemMascara();
        }
    }
}