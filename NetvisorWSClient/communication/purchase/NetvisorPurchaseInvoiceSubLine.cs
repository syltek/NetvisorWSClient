
// 
// Revisio $Revision$
// 
// Ilmentää netvisoriin vietävän ostolaskun ali-/summarivin
// 

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorPurchaseInvoiceSubLine
    {
        public const int MAX_SUBLINEDESCRIPTION_LENGTH = 200;
        public const int MAX_PRODUCT_CODE_LENGTH = 50;
        public const int MAX_PRODUCT_NAME_LENGTH = 50;
        public const int MAX_PRODUCT_UNIT_NAME_LENGTH = 10;

        private string m_productCode;
        private string m_productName;
        private object m_orderedAmount;
        private object m_deliveredAmount;
        private string m_unitName;
        private object m_unitPrice;
        private object m_discountPercentage;
        private object m_vatPercent;
        private object m_lineSum;
        private object m_vatSum;
        private object m_lineSumWithoutVat;
        private string m_description;
        private int m_sort;


        public string productCode
        {
            get
            {
                return m_productCode;
            }
            set
            {
                m_productCode = value;
            }
        }


        public string productName
        {
            get
            {
                return m_productName;
            }
            set
            {
                m_productName = value;
            }
        }


        public object orderedAmount
        {
            get
            {
                return m_orderedAmount;
            }
            set
            {
                m_orderedAmount = value;
            }
        }


        public object deliveredAmount
        {
            get
            {
                return m_deliveredAmount;
            }
            set
            {
                m_deliveredAmount = value;
            }
        }


        public string unitName
        {
            get
            {
                return m_unitName;
            }
            set
            {
                m_unitName = value;
            }
        }


        public object unitPrice
        {
            get
            {
                return m_unitPrice;
            }
            set
            {
                m_unitPrice = value;
            }
        }


        public object discountPercentage
        {
            get
            {
                return m_discountPercentage;
            }
            set
            {
                m_discountPercentage = value;
            }
        }


        public object vatPercent
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


        public object lineSum
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


        public object vatSum
        {
            get
            {
                return m_vatSum;
            }
            set
            {
                m_vatSum = value;
            }
        }


        public object lineSumWithoutVat
        {
            get
            {
                return m_lineSumWithoutVat;
            }
            set
            {
                m_lineSumWithoutVat = value;
            }
        }


        public string description
        {
            get
            {
                return m_description;
            }
            set
            {
                m_description = value;
            }
        }


        public int sort
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
    }
}
