using System;

namespace DocsBr.Utils
{
    public static class UF
    {
        public static DocsBr.UF ToEnum(string uf)
        {
            return (DocsBr.UF) Enum.Parse(typeof(DocsBr.UF), uf, true);
        }
    }
}
