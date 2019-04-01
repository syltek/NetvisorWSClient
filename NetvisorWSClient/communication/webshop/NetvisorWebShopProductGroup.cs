using System.Collections.Specialized;

namespace NetvisorWSClient.communication.webshop
{
    public class NetvisorWebShopProductGroup
    {
        private NameValueCollection m_Names = new NameValueCollection();

        public void addNameWithCountryCode(string countryCode, string name)
        {
            m_Names.Add(countryCode, name);
        }

        public NameValueCollection Names
        {
            get
            {
                return m_Names;
            }
        }
    }
}
