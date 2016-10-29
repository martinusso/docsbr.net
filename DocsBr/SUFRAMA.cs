using DocsBr.Utils;
using DocsBr.Validation;
using System;

namespace DocsBr
{
    public struct SUFRAMA
    {
        public string Inscricao { get; set; }

        public SUFRAMA(string suframa)
            : this()
        {
            Inscricao = new OnlyNumbers(suframa).ToString();
        }

        public static implicit operator string(SUFRAMA suframa)
        {
            return suframa.Inscricao;
        }

        public static implicit operator SUFRAMA(string suframa)
        {
            if (suframa == null)
                suframa = "";

            return new SUFRAMA(suframa);
        }

        public override string ToString()
        {
            return SemMascara();
        }

        public string ComMascara()
        {
            if (Inscricao.Trim() == "")
                return "";

            string pattern = Inscricao.Length == 9 ? @"{0:00\.0000\.00\-0}" : @"{0:00\.000\.00\-0}";
            return String.Format(pattern, Convert.ToUInt64(this.Inscricao));
        }

        public string SemMascara()
        {
            return Inscricao.Trim();
        }

        public bool IsValid()
        {
            return new SUFRAMAValidator(this.Inscricao).IsValid();
        }

        public bool Equals(CNPJ cnpj)
        {
            return Inscricao.Trim() == cnpj.SemMascara();
        }
    }
}
