using Microsoft.VisualBasic;
using System.Collections;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.collector
{

    public class NetvisorPayrollRatioLine
    {




        private decimal m_Amount;
        private string m_PayrollRatioNumber;
        private ArrayList m_dimensions = new ArrayList();

        public decimal Amount
        {
            get
            {
                return m_Amount;
            }
            set
            {
                m_Amount = value;
            }
        }

        public void setAmount(string amount)
        {
            m_Amount = decimal.Parse(amount);
        }

        public string PayrollRatioNumber
        {
            get
            {
                return m_PayrollRatioNumber;
            }
            set
            {
                m_PayrollRatioNumber = value;
            }
        }

        public ArrayList dimensions
        {
            get
            {
                return m_dimensions;
            }
        }

        public void addDimension(NetvisorDimension dimension)
        {
            m_dimensions.Add(dimension);
        }

        public void clearDimensions()
        {
            m_dimensions.Clear();
        }
    }
}
