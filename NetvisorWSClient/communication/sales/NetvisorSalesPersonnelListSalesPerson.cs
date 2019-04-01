namespace NetvisorWSClient.communication.sales
{
    public class NetvisorSalesPersonnelListSalesPerson
    {
        private int m_netvisorKey;
        private string m_firstName;
        private string m_lastName;
        private decimal m_provisionPercent;


        public string firstName
        {
            get
            {
                return m_firstName;
            }
            set
            {
                m_firstName = value;
            }
        }


        public string lastName
        {
            get
            {
                return m_lastName;
            }
            set
            {
                m_lastName = value;
            }
        }


        public decimal provisionPercent
        {
            get
            {
                return m_provisionPercent;
            }
            set
            {
                m_provisionPercent = value;
            }
        }


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
    }
}
