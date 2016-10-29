using DocsBr.Utils;
using System;
using System.Linq;

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

    class SUFRAMAValidator
    {
        private string rawSUFRAMA;

        public SUFRAMAValidator(string suframa)
        {
            rawSUFRAMA = new OnlyNumbers(suframa).ToString();
        }

        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            if (!IsSSValid()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return new[] { 8, 9 }.Contains(rawSUFRAMA.Length);
        }

        private bool IsSSValid()
        {
            return rawSUFRAMA.Substring(0, 2) != "00";
        }

        private bool HasValidCheckDigits()
        {
            string number = rawSUFRAMA.Substring(0, rawSUFRAMA.Length - 1);

            var digitoVerificador = new DigitoVerificador(number)
                                        .ComMultiplicadoresDeAte(2, 9)
                                        .Substituindo("0", 10, 11);
            return digitoVerificador.CalculaDigito() == rawSUFRAMA[rawSUFRAMA.Length - 1].ToString();
        }
    }
}
