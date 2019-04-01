using Microsoft.VisualBasic;
using System;

namespace NetvisorWSClient.util
{
    public class FinnishPersonalIdentificationNumber
    {
        private string m_PersonalID;

        public FinnishPersonalIdentificationNumber(string personalID)
        {
            if (!FinnishPersonalIdentificationNumber.isPersonalIdCorrect(personalID))
                throw new ApplicationException("Henkilötunnus ei ole oikeassa muodossa");

            m_PersonalID = personalID.ToUpper();
        }

        public string getHumanReadableLongFormat()
        {
            if (m_PersonalID.Contains("-") | m_PersonalID.Contains("+") | m_PersonalID.Substring(0, m_PersonalID.Length - 1).Contains("A"))

                return m_PersonalID;
            else
                return m_PersonalID.Substring(0, 6) + "-" + m_PersonalID.Substring(6, 4);
        }

        public string getMachineReadableLongFormat()
        {
            if (m_PersonalID.Contains("-") | m_PersonalID.Contains("+") | m_PersonalID.Substring(0, m_PersonalID.Length - 1).Contains("A"))

                return m_PersonalID.Substring(0, 6) + m_PersonalID.Substring(7, 4);
            else
                return m_PersonalID;
        }

        /// <summary>
        /// Tarkastaa onko henkilötunnus oikeanlainen
        /// </summary>
        /// <returns>True jos oikein, false jos väärin</returns>
        public static bool isPersonalIdCorrect(string personalID)
        {
            string chars = "0123456789ABCDEFHJKLMNPRSTUVWXY";

            string ownCheckSum;
            string checkSum;

            if (Strings.Len(personalID) != 11)
                return false;

            personalID = personalID.ToUpper();

            // Lasketaan tarkisteen järjestysnumero syntymäajasta ja henkilötunnuksen henkilönumerosta
            ownCheckSum = Conversion.Val(Strings.Left(personalID, 6) + Strings.Mid(personalID, 8, 3)) % 31 + 1;

            // Otetaan omaksi tarkistenumeroksi merkki chars merkkijonosta järjestysnumeron mukaan
            ownCheckSum = Strings.Mid(chars, ownCheckSum, 1);
            checkSum = Strings.Right(personalID, 1);

            if (ownCheckSum == checkSum)
                return true;
            else
                return false;
        }
    }
}

