using System.Collections;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorDimensionName
    {
        private int m_netvisorKey;
        private string m_name;
        private bool m_IsHidden;
        private int m_linkType;
        private ArrayList m_details = new ArrayList();

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

        public int LinkType
        {
            get
            {
                return m_linkType;
            }
            set
            {
                m_linkType = value;
            }
        }

        public ArrayList DimensionDetails
        {
            get
            {
                return m_details;
            }
            set
            {
                m_details = value;
            }
        }
    }
}

