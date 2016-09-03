using System;
using DocsBr.Utils;

namespace DocsBr
{
    public static class CEP
    {
        public static string Formatar(string cep)
        {
            var unformattedCEP = new OnlyNumbers(cep).ToString();

            if (unformattedCEP.Length != 8)
            {
                return cep;
            }

            string pattern = @"{0:00\.000\-000}";
            return String.Format(pattern, Convert.ToUInt64(unformattedCEP));
        }
    }
}
