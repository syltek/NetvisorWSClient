using Microsoft.VisualBasic;
using System;

namespace NetvisorWSClient.util
{
    public class FixedLengthFieldFormatter
    {
        public enum FiedType
        {
            TYPE_INT = 1,
            TYPE_FLOAT = 2,
            TYPE_STRING = 3
        }

        public static string FormatString(ref string value, int maxLength, bool stripOverflow = false)
        {
            if (Strings.Len(value) > maxLength)
            {
                if (stripOverflow)
                    value = Strings.Mid(value, 1, maxLength);
                else
                    throw new ApplicationException("Too long value in FormatString: " + value + ", maximun allowed: " + maxLength);
            }

            return string.Format("{0," + -maxLength + "}", value);
        }

        public static string FormatDouble(ref double value, int maxLength, int decimals)
        {

            // ensin pyöristetään haluttuihin desimaaleihin, sitten kerrotaan desimaalien määrällä
            // jonka jälkeen meillä on haluttu tulos

            value = Math.Round(value, decimals, MidpointRounding.AwayFromZero);

            if (Strings.Len(value.ToString()) > maxLength)
                throw new ApplicationException("Too long value in FormatInteger: " + value + ", maximun allowed: " + maxLength);

            int valueAsInteger = System.Convert.ToInt32(value * Math.Pow(10, decimals));

            return FormatInteger(ref valueAsInteger, maxLength);
        }

        public static string FormatInteger(ref UInt64 value, int maxLength)
        {
            if (Strings.Len(value.ToString()) > maxLength)
                throw new ApplicationException("Too long value in FormatInteger: " + value + ", maximun allowed: " + maxLength);

            return string.Format("{0," + maxLength + "}", value.ToString()).Replace(" ", "0");
        }
    }
}

