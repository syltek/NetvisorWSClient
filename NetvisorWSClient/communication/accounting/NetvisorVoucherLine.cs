using System.Collections;
using NetvisorWSClient.util;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorVoucherLine
    {
        private decimal m_lineSum;
        private string m_lineDescription;
        private int m_accountNumber;
        private int m_vatPercent;
        private VatCode.vatCodes m_vatCode;
        private string m_vatCodeAbbreviation;
        private ArrayList m_voucherLineDimensions = new ArrayList();

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

        public string lineDescription
        {
            get
            {
                return m_lineDescription;
            }
            set
            {
                m_lineDescription = value;
            }
        }

        public int accountNumber
        {
            get
            {
                return m_accountNumber;
            }
            set
            {
                m_accountNumber = value;
            }
        }

        public int vatPercent
        {
            get
            {
                return m_vatPercent;
            }
            set
            {
                m_vatPercent = value;
            }
        }

        public VatCode.vatCodes vatCode
        {
            get
            {
                return m_vatCode;
            }
            set
            {
                m_vatCode = value;
            }
        }

        public string vatCodeAbbreviation
        {
            get
            {
                return m_vatCodeAbbreviation;
            }
            set
            {
                m_vatCodeAbbreviation = value;
            }
        }

        public ArrayList voucherLineDimensions
        {
            get
            {
                return m_voucherLineDimensions;
            }
            set
            {
                m_voucherLineDimensions = value;
            }
        }

        public void addVoucherLineDimension(NetvisorDimension dimension)
        {
            m_voucherLineDimensions.Add(dimension);
        }
    }
}

