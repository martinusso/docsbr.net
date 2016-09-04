using System;
using DocsBr.Utils;
using DocsBr.Validation;

namespace DocsBr
{
    public struct CPF
    {
        public string Numero { get; set; }

        public CPF(string cpf)
            : this()
        {
            this.Numero = new OnlyNumbers(cpf).ToString();
        }

        public static implicit operator string (CPF cpf)
        {
            return cpf.Numero;
        }

        public static implicit operator CPF(string cpf)
        {
            if (cpf == null)
                cpf = "";

            return new CPF(cpf);
        }

        public override string ToString()
        {
            return SemMascara();
        }

        public string ComMascara()
        {
            if (this.Numero == "")
                return "";

            string pattern = @"{0:000\.000\.000\-00}";
            return String.Format(pattern, Convert.ToUInt64(this.Numero));
        }

        public string SemMascara()
        {
            return this.Numero;
        }

        public bool IsValid()
        {
            return new CPFValidator(this.Numero).IsValid();
        }

        public bool Equals(CPF cpf)
        {
            return this.Numero == cpf.SemMascara();
        }
    }
}