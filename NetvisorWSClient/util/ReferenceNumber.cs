using Microsoft.VisualBasic;
using System;

namespace NetvisorWSClient.util
{
    public class ReferenceNumber
    {
        private string m_fullReferenceNumber;

        public ReferenceNumber(string referenceNumber, bool isFullReferenceNumber)
        {
            if (isReferenceNumberValid(referenceNumber, isFullReferenceNumber))
            {
                if (isFullReferenceNumber)
                    m_fullReferenceNumber = referenceNumber;
                else
                    m_fullReferenceNumber = referenceNumber + calculateCheckSum(referenceNumber);
            }
            else
                throw new ApplicationException("Invalid referencenumber: " + referenceNumber);
        }

        public string getMachineReadableFormat()
        {
            return m_fullReferenceNumber;
        }

        public string getHumanReadableFormat()
        {
            string formattedReferenceNumber = Constants.vbNullString;
            char[] reversedReferenceNumber = removeLeadingZeros(m_fullReferenceNumber).Replace(" ", "").ToCharArray();
            int counter;

            Array.Reverse(reversedReferenceNumber);
            foreach (string s in reversedReferenceNumber)
            {
                formattedReferenceNumber = s + formattedReferenceNumber;

                counter += 1;
                if (counter == 5)
                {
                    formattedReferenceNumber = " " + formattedReferenceNumber;
                    counter = 0;
                }
            }

            return formattedReferenceNumber.TrimStart();
        }

        private static short calculateCheckSum(string referenceNumberBody)
        {
            int[] multiplier = new[] { 7, 3, 1 };
            int position;
            char[] referenceNumberForCalculation = removeLeadingZeros(referenceNumberBody).Replace(" ", "").ToCharArray();
            int sum;

            Array.Reverse(referenceNumberForCalculation);
            foreach (string s in referenceNumberForCalculation)
            {
                sum += s * multiplier[position];

                position += 1;
                if (position > 2)
                    position = 0;
            }

            int nextTenth = sum;
            while (nextTenth % 10 != 0)
                nextTenth = nextTenth + 1;

            return nextTenth - sum;
        }

        public static bool isReferenceNumberValid(string referenceNumber, bool isFullReferenceNumber = true)
        {
            string referenceNumberForCheck = removeLeadingZeros(referenceNumber).Replace(" ", "");
            bool ret = true;

            if (!Information.IsNumeric(referenceNumberForCheck))
                ret = false;
            else if (!isFullReferenceNumber)
            {
                if (referenceNumberForCheck.Length < 3 | referenceNumberForCheck.Length > 19)
                    ret = false;
            }
            else if (referenceNumberForCheck.Length < 3 | referenceNumberForCheck.Length > 20)
                ret = false;
            else if (!(calculateCheckSum(referenceNumberForCheck.Substring(0, referenceNumberForCheck.Length - 1)) == Strings.Right(referenceNumberForCheck, 1)))
                ret = false;

            return ret;
        }

        private static string removeLeadingZeros(string referencenumber)
        {
            string formattedReferencenumber = referencenumber;

            if (formattedReferencenumber.Length > 0)
            {
                while (formattedReferencenumber.Substring(0, 1) == "0")
                    formattedReferencenumber = formattedReferencenumber.Substring(1);
            }

            return formattedReferencenumber;
        }
    }
}

