using System;
using System.Collections.Specialized;

namespace NetvisorWSClient.communication.webshop
{
    public class NetvisorWebShopProductVariant
    {
        private NameValueCollection m_Names = new NameValueCollection();
        private NameValueCollection m_Descriptions = new NameValueCollection();
        private string m_variantIdentifier;
        private string m_imageURI;
        private DateTime m_lastChangeDate;
        private decimal m_price;

        public void addNameWithCountryCode(string countryCode, string name)
        {
            m_Names.Add(countryCode, name);
        }

        public void addDescriptionWithCountryCode(string countryCode, string description)
        {
            m_Descriptions.Add(countryCode, description);
        }

        public string variantIdentifier
        {
            get
            {
                return m_variantIdentifier;
            }
            set
            {
                m_variantIdentifier = value;
            }
        }

        public string imageURI
        {
            get
            {
                return m_imageURI;
            }
            set
            {
                m_imageURI = value;
            }
        }

        public DateTime lastChangeDate
        {
            get
            {
                return m_lastChangeDate;
            }
            set
            {
                m_lastChangeDate = value;
            }
        }

        public decimal price
        {
            get
            {
                return m_price;
            }
            set
            {
                m_price = value;
            }
        }

        public NameValueCollection Names
        {
            get
            {
                return m_Names;
            }
        }

        public NameValueCollection Descriptions
        {
            get
            {
                return m_Descriptions;
            }
        }
    }
}
