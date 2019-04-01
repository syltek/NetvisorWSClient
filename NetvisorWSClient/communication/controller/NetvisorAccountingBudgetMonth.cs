using Microsoft.VisualBasic;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorAccountingBudgetMonth
    {




        private double m_sum;
        private double m_vat;
        private int m_year;
        private int m_month;

        public double Sum
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

        public int Year
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

        public int Month
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

        public double VAT
        {
            get
            {
                return m_vat;
            }
            set
            {
                m_vat = value;
            }
        }

        public NetvisorAccountingBudgetMonth()
        {
        }
    }
}
