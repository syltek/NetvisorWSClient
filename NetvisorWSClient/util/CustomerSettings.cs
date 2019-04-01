using Microsoft.VisualBasic;

namespace NetvisorWSClient.util
{

    public class CustomerSettings
    {




        public const string InterfaceLanguage_Finnish = "FI";
        public const string InterfaceLanguage_English = "EN";
        public const string InterfaceLanguage_Swedish = "SE";

        private string m_customerIdentifier;
        private string m_customerPrivateKey;
        private string m_customerLanguage;

        public CustomerSettings()
        {
        }

        public CustomerSettings(string customerIdentifier, string customerPrivateKey, string customerLanguage)
        {
            m_customerIdentifier = customerIdentifier;
            m_customerPrivateKey = customerPrivateKey;
            m_customerLanguage = customerLanguage;
        }

        public string CustomerIdentifier
        {
            get
            {
                return m_customerIdentifier;
            }
            set
            {
                m_customerIdentifier = value;
            }
        }

        public string CustomerPrivateKey
        {
            get
            {
                return m_customerPrivateKey;
            }
            set
            {
                m_customerPrivateKey = value;
            }
        }

        public string CustomerLanguage
        {
            get
            {
                return m_customerLanguage;
            }
            set
            {
                m_customerLanguage = value;
            }
        }
    }
}

