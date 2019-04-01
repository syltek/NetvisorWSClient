using Microsoft.VisualBasic;
using System.IO;

namespace NetvisorWSClient.util
{
    public class FinnishBankAccountNumber : IBankAccountNumber
    {
        private string m_accountNumber;

        public FinnishBankAccountNumber(string accountNumber)
        {
            m_accountNumber = accountNumber;

            if (FinnishBankAccountNumber.isAccountNumberCorrect(accountNumber) == false)
            {
                throw new InvalidDataException("Finnish accountnumber is not valid");
                m_accountNumber = Constants.vbNullString;
            }
        }

        private FinnishBankAccountNumber(string accountNumber, bool noAccountnumberCheck)
        {
            m_accountNumber = accountNumber;
        }

        /// <summary>
        /// Täydentää luokan alustuksen yhteydessä saamansa tilinumeron nollilla
        /// 14-merkkiseen muotoon. Jättää välimerkin.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public string getHumanReadableLongFormat()
        {
            return modifyAccountNumberIntoLongFormat(true);
        }

        /// <summary>
        /// Täydentää luokan alustuksen yhteydessä saaman tilinumeron nollilla
        /// 14-merkkiseen muotoon ilman välimerkkiä
        /// </summary>
        /// <returns>Tilinumeron pitkässä muodossa</returns>
        public string getMachineReadableLongFormat()
        {
            return modifyAccountNumberIntoLongFormat(false);
        }

        /// <summary>
        /// Muokkaa tilinumeron pitkään muotoon.
        /// Käytetään getMachineReadableLongFormat ja getHumanReadableLongFormat funktioista
        /// </summary>
        /// <param name="leaveSeparatorLine">Määrää jätetäänkö väliviiva. True jättää, false ei</param>
        /// <returns>Palauttaa muokatun tilinumeron</returns>
        private string modifyAccountNumberIntoLongFormat(bool leaveSeparatorLine)
        {
            string numIn = m_accountNumber;
            numIn = numIn.Replace(" ", "");
            numIn = numIn.Replace("-", "");

            if (Strings.Len(numIn) < 8)
                return numIn;

            string numOut;
            if (numIn.Length == 14)
                numOut = numIn;
            else
            {
                string beginPart = numIn.Substring(0, 6);
                string endPart = numIn.Substring(6);

                bool isAktiaOrOPAccountNumber = System.Convert.ToString(beginPart.Substring(0, 1)) == "4" | System.Convert.ToString(beginPart.Substring(0, 1)) == "5";

                if (isAktiaOrOPAccountNumber)
                {
                    numOut = beginPart;
                    numOut = numOut + endPart.Substring(0, 1);

                    int i;
                    var loopTo = (8 - endPart.Length);
                    for (i = 1; i <= loopTo; i++)
                        numOut = numOut + "0";

                    numOut = numOut + endPart.Substring(1);
                }
                else
                {
                    numOut = beginPart;

                    int i;
                    var loopTo1 = (8 - endPart.Length);
                    for (i = 1; i <= loopTo1; i++)
                        numOut = numOut + "0";

                    numOut = numOut + endPart;
                }
            }

            if (leaveSeparatorLine == true)
                numOut = numOut.Substring(0, 6) + "-" + numOut.Substring(6);

            return numOut;
        }

        /// <summary>
        /// Testaa onko luokan alustuksen yhteydessä saatu tilinumero oikeassa muodossa
        /// Tarkistettava numero voi olla joko pitkässä tai lyhyessä muodossa
        /// </summary>
        /// <returns>True jos tilinumero ok, false jos ei</returns>
        public static bool isAccountNumberCorrect(string accountNumberToCheck)
        {
            string accNumber = accountNumberToCheck;

            if (!(accNumber == Constants.vbNullString))
            {
                accNumber = accNumber.Replace(" ", "");
                accNumber = accNumber.Replace("-", "");
            }
            else
                return false;

            if (accNumber.Length < 8)
                return false;

            if (Information.IsNumeric(accNumber))
            {
                if (accNumber.Length != 14)
                {
                    FinnishBankAccountNumber objFinnishBankAccountNumber = new FinnishBankAccountNumber(accNumber, true);
                    try
                    {
                        accNumber = objFinnishBankAccountNumber.getMachineReadableLongFormat();
                    }
                    catch
                    {
                        return false;
                    }
                }

                long sum;
                long product;
                float weight = 2;
                long nextTenth;
                int ownCheckSum;
                int checkSum = System.Convert.ToInt32(accNumber.Substring(accNumber.Length - 1));
                accNumber = accNumber.Substring(0, accNumber.Length - 1);

                int i;
                for (i = accNumber.Length; i >= 1; i += -1)
                {
                    product = weight * System.Convert.ToInt32(accNumber.Substring(i - 1, 1));

                    if (Strings.Len(product.ToString()) == 2)
                    {
                        sum = sum + System.Convert.ToInt32(Strings.Mid(product.ToString(), 1, 1));
                        sum = sum + System.Convert.ToInt32(Strings.Mid(product.ToString(), 2, 1));
                    }
                    else
                        sum = sum + product;

                    if (weight == 2)
                        weight = 1;
                    else
                        weight = 2;
                }

                nextTenth = sum;
                while (nextTenth % 10 != 0)
                    nextTenth = nextTenth + 1;
                ownCheckSum = nextTenth - sum;

                if (ownCheckSum == checkSum)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}

