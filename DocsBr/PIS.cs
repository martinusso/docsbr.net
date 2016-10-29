using DocsBr.Utils;
using DocsBr.Validation;
using System;

namespace DocsBr
{
    public struct PIS
    {
        public string Numero { get; set; }

        public PIS(string pis)
            : this()
        {
            Numero = new OnlyNumbers(pis).ToString();
        }

        public static implicit operator string(PIS pis)
        {
            return pis.Numero;
        }

        public static implicit operator PIS(string pis)
        {
            if (pis == null)
                pis = "";

            return new PIS(pis);
        }

        public override string ToString()
        {
            return SemMascara();
        }

        public string ComMascara()
        {
            if (Numero == "")
                return "";

            string pattern = @"{0:000\.00000\.00\-0}";
            return String.Format(pattern, Convert.ToUInt64(Numero));
        }

        public string SemMascara()
        {
            return Numero;
        }

        public bool IsValid()
        {
            return new PISValidator(this.Numero).IsValid();
        }

        public bool Equals(PIS cnpj)
        {
            return Numero == cnpj.SemMascara();
        }
    }

    
}
