using Microsoft.VisualBasic;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorAccountingBudgetAccountListAccount
    {




        private int m_netvisorKey;
        private string m_name;
        private int m_number;
        private int m_group;
        private int m_type;


        public int NetvisorKey
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

        public string Name
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

        public int Number
        {
            get
            {
                return m_number;
            }
            set
            {
                m_number = value;
            }
        }

        public int Group
        {
            get
            {
                return m_group;
            }
            set
            {
                m_group = value;
            }
        }

        public int Type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
            }
        }

        public NetvisorAccountingBudgetAccountListAccount()
        {
        }
    }
}


