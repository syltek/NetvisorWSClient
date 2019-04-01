using System.Collections.Generic;
using System.Collections;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorAccountList
    {
        private List<NetvisorAccount> m_accountList = new List<NetvisorAccount>();
        private Hashtable m_companyDefaultAccounts = new Hashtable();

        public List<NetvisorAccount> accountList
        {
            get
            {
                return m_accountList;
            }
            set
            {
                m_accountList = value;
            }
        }

        public Hashtable companyDefaultAccounts
        {
            get
            {
                return m_companyDefaultAccounts;
            }
            set
            {
                m_companyDefaultAccounts = value;
            }
        }
    }
}
