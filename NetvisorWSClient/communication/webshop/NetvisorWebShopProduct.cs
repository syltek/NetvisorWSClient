using System.Collections;
using System.Collections.Specialized;

namespace NetvisorWSClient.communication.webshop
{
    public class NetvisorWebShopProduct
    {
        private NameValueCollection m_Names = new NameValueCollection();
        private NameValueCollection m_Descriptions = new NameValueCollection();
        private ArrayList m_ProductGroups = new ArrayList();
        private ArrayList m_ProductVariants = new ArrayList();

        public void addNameWithCountryCode(string countryCode, string name)
        {
            m_Names.Add(countryCode, name);
        }

        public void addDescriptionWithCountryCode(string countryCode, string description)
        {
            m_Descriptions.Add(countryCode, description);
        }

        public void addProductGroup(NetvisorWebShopProductGroup productGroup)
        {
            m_ProductGroups.Add(productGroup);
        }

        public void addProductVariant(NetvisorWebShopProductVariant productVariant)
        {
            m_ProductVariants.Add(productVariant);
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

        public ArrayList ProductGroups
        {
            get
            {
                return m_ProductGroups;
            }
        }

        public ArrayList ProductVariants
        {
            get
            {
                return m_ProductVariants;
            }
        }
    }
}
