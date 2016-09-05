using System;

namespace DocsBr.Utils
{
    public static class UF
    {
        public static DocsBr.UF ToEnum(string uf)
        {
            return (DocsBr.UF) Enum.Parse(typeof(DocsBr.UF), uf, true);
        }

        public static int[] Codigos
        {
            get
            {
                return new int[] { 11, 12, 13, 14, 15, 16, 17, 21, 22, 23, 24, 25, 26, 27, 28, 29, 31, 32, 33, 35, 41, 42, 43, 50, 51, 52, 53 };
            }
        }

        public static string[] Siglas
        {
            get
            {
                return new string[] { "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO" };
            }
        }
    }
}
