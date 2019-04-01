namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorDimensionNameDimensionDetail
    {
        private int m_netvisorKey;
        private string m_name;
        private bool m_IsHidden;
        private int m_sort;
        private int m_endSort;
        private int m_level;
        private int m_fatherID;

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

        public bool IsHidden
        {
            get
            {
                return m_IsHidden;
            }
            set
            {
                m_IsHidden = value;
            }
        }

        public int Level
        {
            get
            {
                return m_level;
            }
            set
            {
                m_level = value;
            }
        }

        public int Sort
        {
            get
            {
                return m_sort;
            }
            set
            {
                m_sort = value;
            }
        }

        public int EndSort
        {
            get
            {
                return m_endSort;
            }
            set
            {
                m_endSort = value;
            }
        }

        public int FatherID
        {
            get
            {
                return m_fatherID;
            }
            set
            {
                m_fatherID = value;
            }
        }

        public NetvisorDimensionNameDimensionDetail()
        {
        }
    }

    public class NetvisorDimenisonNameDimensionDetail : NetvisorDimensionNameDimensionDetail
    {

        // To support old misnamed class 

        public NetvisorDimenisonNameDimensionDetail() : base()
        {
        }
    }
}

