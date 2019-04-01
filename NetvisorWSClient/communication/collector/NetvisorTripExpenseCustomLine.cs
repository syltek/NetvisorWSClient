namespace NetvisorWSClient.communication.collector
{
    public class NetvisorTripExpenseCustomLine
    {
        private int m_netvisorKey;
        private string m_paymentReciever;
        private string m_expenseRatioName;
        private decimal m_unitAmount;
        private decimal m_unitSum;
        private decimal m_vatPercentage;
        private decimal m_lineSum;
        private string m_comment;
        private string m_lineStatus;

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

        public string paymentReciever
        {
            get
            {
                return m_paymentReciever;
            }
            set
            {
                m_paymentReciever = value;
            }
        }

        public string expenseRatioName
        {
            get
            {
                return m_expenseRatioName;
            }
            set
            {
                m_expenseRatioName = value;
            }
        }

        public decimal unitAmount
        {
            get
            {
                return m_unitAmount;
            }
            set
            {
                m_unitAmount = value;
            }
        }

        public decimal unitSum
        {
            get
            {
                return m_unitSum;
            }
            set
            {
                m_unitSum = value;
            }
        }

        public decimal vatPercentage
        {
            get
            {
                return m_vatPercentage;
            }
            set
            {
                m_vatPercentage = value;
            }
        }

        public decimal lineSum
        {
            get
            {
                return m_lineSum;
            }
            set
            {
                m_lineSum = value;
            }
        }

        public string comment
        {
            get
            {
                return m_comment;
            }
            set
            {
                m_comment = value;
            }
        }

        public string lineStatus
        {
            get
            {
                return m_lineStatus;
            }
            set
            {
                m_lineStatus = value;
            }
        }
    }
}
