
namespace NetvisorWSClient.communication.webshop
{
    public class NetvisorWebShopCustomer
    {
        private string m_OrganisationIdentifier;
        private string m_Name;
        private string m_Address;
        private string m_PostNumber;
        private string m_City;
        private string m_Phone;
        private string m_Email;
        private string m_ProductListURI;

        public string OrganisationIdentifier
        {
            get
            {
                return m_OrganisationIdentifier;
            }
            set
            {
                m_OrganisationIdentifier = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public string Address
        {
            get
            {
                return m_Address;
            }
            set
            {
                m_Address = value;
            }
        }

        public string PostNumber
        {
            get
            {
                return m_PostNumber;
            }
            set
            {
                m_PostNumber = value;
            }
        }

        public string City
        {
            get
            {
                return m_City;
            }
            set
            {
                m_City = value;
            }
        }

        public string Phone
        {
            get
            {
                return m_Phone;
            }
            set
            {
                m_Phone = value;
            }
        }

        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
            }
        }

        public string ProductListURI
        {
            get
            {
                return m_ProductListURI;
            }
            set
            {
                m_ProductListURI = value;
            }
        }
    }
}
