using Microsoft.VisualBasic;
using System;

namespace NetvisorWSClient.util
{

    public class FinnishOrganisationIdentifier
    {




        private string m_identifier;

        public FinnishOrganisationIdentifier()
        {
        }

        public string Identifier
        {
            get
            {
                return m_identifier;
            }
            set
            {
                m_identifier = value;
            }
        }

        public FinnishOrganisationIdentifier(string identifier)
        {
            if (FinnishOrganisationIdentifier.isOrganisationIdentifierCorrect(identifier) == true)
                m_identifier = identifier;
            else
                throw new Exception("Your business ID is not in the correct format");
        }

        public string getHumanReadableFormat()
        {
            string machineReadableIdentifier = m_identifier.Replace("-", "").Replace(" ", "");
            string humanReadableIdentifier = FixedLengthFieldFormatter.FormatInteger(ref Strings.Left(machineReadableIdentifier, machineReadableIdentifier.Length - 1), 7) + "-" + Strings.Right(machineReadableIdentifier, 1);

            return humanReadableIdentifier;
        }

        public string getMachineReadableFormat()
        {
            string machineReadableIdentifier = "";

            machineReadableIdentifier = m_identifier.Replace("-", "").Replace(" ", "");
            machineReadableIdentifier = FixedLengthFieldFormatter.FormatInteger(ref Strings.Left(machineReadableIdentifier, machineReadableIdentifier.Length - 1), 7) + Strings.Right(machineReadableIdentifier, 1);

            return machineReadableIdentifier;
        }

        /// <summary>
        /// Tarkistaa onko suomalainen ytunnus oikein
        /// 1. Tunnuksen numeroita (7 kpl, tarvittaessa lisätään alkuun nolla; numeroita oli aikaisemmin kuusi,
        /// ja tätä vanhaa muotoa voi hyvin harvoin nähdä vieläkin) painotetaan vasemmalta lähtien kertoimilla 7, 9, 10, 5, 8, 4 ja 2.
        /// 2. Tulot lasketaan yhteen.
        /// 3. Summa jaetaan 11:llä.
        /// 4. Jos jakojäännös on 0, tarkistusnumero on 0.
        /// 5. Ei anneta tunnuksia, jotka tuottaisivat jakojäännöksen 1.
        /// 6. Jos jakojäännös on 2..10, tarkistusnumero on 11 miinus jakojäännös.
        /// </summary>
        public static bool isOrganisationIdentifierCorrect(string identifier)
        {
            bool ret = false;

            if (identifier.Length > 0)
            {
                if (identifier.Contains("-"))
                    identifier = identifier.Replace("-", "");

                identifier = identifier.Replace(" ", "");

                if (identifier.Length == 8)
                {
                    string businessID = Strings.Left(identifier, identifier.Length - 1);

                    if (Information.IsNumeric(businessID))
                    {

                        // tunnuksen vasemman puolen, osan ennen viivaa, on oltava seitsämän merkkiä. 
                        // jos ei ole lisätään etunollia tarpeeksi
                        businessID = FixedLengthFieldFormatter.FormatInteger(ref businessID, 7);

                        int[] multiplier = new[] { 7, 9, 10, 5, 8, 4, 2 };
                        int[] product = new int[7];

                        int i = 0;
                        do
                        {
                            product[i] = multiplier[i] * System.Convert.ToInt32(Strings.Mid(businessID, i + 1, 1));
                            i += 1;
                        }
                        while (i != businessID.Length);

                        int sum;
                        int check;

                        // lasketaan tulot yhteen
                        foreach (var i in product)
                            sum = sum + i;

                        check = sum % 11;

                        if (check >= 2 & check <= 10)
                            check = 11 - check;

                        // tarkastetaan onko tarkistussumma sama
                        if (System.Convert.ToString(check) == Strings.Right(identifier, 1))
                            ret = true;
                    }
                }
            }

            return ret;
        }
    }
}

