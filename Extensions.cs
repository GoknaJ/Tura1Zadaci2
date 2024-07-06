using System;

namespace Tura1Zadaci2
{
    public static class StringExtensions
    {
        public static int BrojiRijeci(this string recenica)
        {
            if (string.IsNullOrWhiteSpace(recenica))
            {
                return 0;
            }

            return recenica.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
