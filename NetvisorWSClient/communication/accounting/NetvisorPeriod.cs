using System;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorPeriod
    {
        private int m_netvisorKey;
        private string m_Name;
        private DateTime m_beginDate;
        private DateTime m_endDate;

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

        public DateTime beginDate
        {
            get
            {
                return m_beginDate;
            }
            set
            {
                m_beginDate = value;
            }
        }

        public DateTime endDate
        {
            get
            {
                return m_endDate;
            }
            set
            {
                m_endDate = value;
            }
        }
    }
}
