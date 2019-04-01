
namespace NetvisorWSClient.communication.sales
{
    public class NetvisorCustomerListCustomer
    {
        private string m_netvisorKey;
        private string m_name;
        private string m_code;
        private string m_organisationIdentifier;
        private string m_uri;

        public string netvisorKey
        {
            get
            {
                return m_netvisorKey;
            }
            set
            {
                m_netvisorKey = value;
            }
        }

        public string name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        public string code
        {
            get
            {
                return m_code;
            }
            set
            {
                m_code = value;
            }
        }

        public string organisationIdentifier
        {
            get
            {
                return m_organisationIdentifier;
            }
            set
            {
                m_organisationIdentifier = value;
            }
        }

        public string uri
        {
            get
            {
                return m_uri;
            }
            set
            {
                m_uri = value;
            }
        }
    }
}
