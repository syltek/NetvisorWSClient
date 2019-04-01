using System.Collections;
using NetvisorWSClient.communication.common;

// 
// 
// 
// Revisio $Revision$
// 
// Ilmentää netvisoriin vietävän ostolaskun rivin
// 

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorPurchaseInvoiceLine
    {
        public const int MAX_LINEDESCRIPTION_LENGTH = 200;
        public const int MAX_PRODUCT_CODE_LENGTH = 50;
        public const int MAX_PRODUCT_NAME_LENGTH = 50;
        public const int MAX_PRODUCT_UNIT_NAME_LENGTH = 10;

        private string m_productCode;
        private string m_productName;
        private decimal m_orderedAmount;
        private decimal m_deliveredAmount;
        private string m_unitName;
        private decimal m_unitPrice;
        private decimal m_discountPercentage;
        private decimal m_vatPercent;
        private string m_vatCode;
        private decimal m_lineSum;
        private decimal m_vatSum;
        private decimal m_lineSumWithoutVat;
        private string m_description;
        private int m_sort;
        private ArrayList m_Dimensions = new ArrayList();
        private int m_netvisorKey;
        private string m_accountNumberSuggestion;

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

        public ArrayList Dimensions
        {
            get
            {
                return m_Dimensions;
            }
        }

        public void addDimension(NetvisorDimension dimension)
        {
            m_Dimensions.Add(dimension);
        }

        public void clearDimensions()
        {
            m_Dimensions.Clear();
        }

        public decimal vatSum
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

        public decimal lineSumWithoutVat
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

        public string ProductCode
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

        public string ProductName
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

        public decimal OrderedAmount
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

        public decimal DeliveredAmount
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

        public string UnitName
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

        public decimal UnitPrice
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

        public decimal DiscountPercentage
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

        public decimal VatPercent
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

        public string VatCode
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

        public decimal LineSum
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

        public string Description
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

        public string accountNumberSuggestion
        {
            get
            {
                return m_accountNumberSuggestion;
            }
            set
            {
                m_accountNumberSuggestion = value;
            }
        }
    }
}
