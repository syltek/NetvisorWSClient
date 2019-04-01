namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorAccount
    {
        private int m_NetvisorKey;
        private string m_Number;
        private string m_Name;
        private string m_AccountType;
        private int m_FatherNetvisorKey;
        private bool m_IsActive;
        private bool m_IsCumulative;
        private int m_Sort;
        private int m_EndSort;
        private bool m_IsNaturalNegative;

        public int NetvisorKey
        {
            get
            {
                return m_NetvisorKey;
            }
            set
            {
                m_NetvisorKey = value;
            }
        }

        public string Number
        {
            get
            {
                return m_Number;
            }
            set
            {
                m_Number = value;
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

        public string AccountType
        {
            get
            {
                return m_AccountType;
            }
            set
            {
                m_AccountType = value;
            }
        }

        public int FatherNetvisorKey
        {
            get
            {
                return m_FatherNetvisorKey;
            }
            set
            {
                m_FatherNetvisorKey = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return m_IsActive;
            }
            set
            {
                m_IsActive = value;
            }
        }

        public bool IsCumulative
        {
            get
            {
                return m_IsCumulative;
            }
            set
            {
                m_IsCumulative = value;
            }
        }

        public int Sort
        {
            get
            {
                return m_Sort;
            }
            set
            {
                m_Sort = value;
            }
        }

        public int EndSort
        {
            get
            {
                return m_EndSort;
            }
            set
            {
                m_EndSort = value;
            }
        }

        public bool IsNaturalNegative
        {
            get
            {
                return m_IsNaturalNegative;
            }
            set
            {
                m_IsNaturalNegative = value;
            }
        }
    }
}
