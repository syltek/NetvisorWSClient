
namespace NetvisorWSClient.communication.sales
{
    public class NetvisorInvoiceAccrualEntry
    {
        private int m_month;
        private int m_year;
        private decimal m_sum;

        public NetvisorInvoiceAccrualEntry()
        {
        }

        public NetvisorInvoiceAccrualEntry(int month, int year, decimal sum)
        {
            m_month = month;
            m_year = year;
            m_sum = sum;
        }

        public int month
        {
            get
            {
                return m_month;
            }
            set
            {
                m_month = value;
            }
        }

        public int year
        {
            get
            {
                return m_year;
            }
            set
            {
                m_year = value;
            }
        }

        public decimal sum
        {
            get
            {
                return m_sum;
            }
            set
            {
                m_sum = value;
            }
        }
    }
}
