using Microsoft.VisualBasic;

namespace NetvisorWSClient.util
{

    public class PartnerSettings
    {




        private string m_clientName;
        private string m_partnerIdentifier;
        private string m_partnerPrivateKey;

        public PartnerSettings()
        {
        }

        public PartnerSettings(string clientName, string partnerIdentifier, string partnerPrivateKey)
        {
            m_clientName = clientName;
            m_partnerIdentifier = partnerIdentifier;
            m_partnerPrivateKey = partnerPrivateKey;
        }

        public string ClientName
        {
            get
            {
                return m_clientName;
            }
            set
            {
                m_clientName = value;
            }
        }

        public string PartnerIdentifier
        {
            get
            {
                return m_partnerIdentifier;
            }
            set
            {
                m_partnerIdentifier = value;
            }
        }

        public string PartnerPrivateKey
        {
            get
            {
                return m_partnerPrivateKey;
            }
            set
            {
                m_partnerPrivateKey = value;
            }
        }
    }
}
