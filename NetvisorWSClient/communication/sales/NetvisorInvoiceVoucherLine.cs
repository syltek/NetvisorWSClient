using System.Collections;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorInvoiceVoucherLine
    {
        public enum lineSumTypes : int
        {
            NET = 1,
            GROSS = 2
        }

        private decimal m_lineSum;
        private lineSumTypes m_lineSumType;
        private int m_AccountNumber;
        private decimal m_vatClass;
        private string m_vatCode;
        private string m_lineDescription;
        private bool m_skipAccrual;

        private string m_dimensionName;
        private string m_dimensionItem;

        private ArrayList m_dimensions = new ArrayList();

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

        public int AccountNumber
        {
            get
            {
                return m_AccountNumber;
            }
            set
            {
                m_AccountNumber = value;
            }
        }

        public decimal vatClass
        {
            get
            {
                return m_vatClass;
            }
            set
            {
                m_vatClass = value;
            }
        }

        public string vatCode
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

        public lineSumTypes LineSumType
        {
            get
            {
                return m_lineSumType;
            }
            set
            {
                m_lineSumType = value;
            }
        }

        public string LineDescription
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

        public string dimensionName
        {
            get
            {
                return m_dimensionName;
            }
            set
            {
                m_dimensionName = value;
            }
        }

        public string dimensionItem
        {
            get
            {
                return m_dimensionItem;
            }
            set
            {
                m_dimensionItem = value;
            }
        }

        public bool skipAccrual
        {
            get
            {
                return m_skipAccrual;
            }
            set
            {
                m_skipAccrual = value;
            }
        }

        public ArrayList Dimensions
        {
            get
            {
                return m_dimensions;
            }
        }

        public void addDimension(common.NetvisorDimension netvisorDimension)
        {
            m_dimensions.Add(netvisorDimension);
        }
    }
}

