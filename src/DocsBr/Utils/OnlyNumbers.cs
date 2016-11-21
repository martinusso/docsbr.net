using System;

namespace DocsBr.Utils
{
    public class OnlyNumbers
    {
        private string value;

        public OnlyNumbers(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            string onlyNumber = "";
            foreach (char s in this.value)
            {
                if (Char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}
