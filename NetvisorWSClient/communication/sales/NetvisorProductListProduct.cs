namespace NetvisorWSClient.communication.sales
{
    public class NetvisorProductListProduct
    {
        private int m_netvisorKey;
        private string m_productCode;
        private string m_name;
        private decimal m_unitPrice;
        private string m_uri;

        public int netvisorKey
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

        public string productCode
        {
            get
            {
                return m_productCode;
            }
            set
            {
                m_productCode = value;
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

        public decimal unitPrice
        {
            get
            {
                return m_unitPrice;
            }
            set
            {
                m_unitPrice = value;
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
