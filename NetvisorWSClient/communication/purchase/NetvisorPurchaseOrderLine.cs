using System.Collections;
using System;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorPurchaseOrderLine
    {
        private string m_productCode;
        private string m_productCode_type;
        private string m_productName;
        private string m_vendorCode;
        private decimal m_orderedAmount;
        private decimal m_deliveredAmount;
        private decimal m_unitPrice;
        private decimal m_rowSum;
        private decimal m_freightRate;
        private int m_accountingAccountSuggestion;
        private decimal m_vatPercent;
        private string m_vatCode;
        private DateTime m_deliveryDate;
        private string m_inventoryPlace;
        private string m_inventoryPlace_type;

        private ArrayList m_Dimensions = new ArrayList();

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

        public string productCode_type
        {
            get
            {
                return m_productCode_type;
            }
            set
            {
                m_productCode_type = value;
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

        public string vendorProductCode
        {
            get
            {
                return m_vendorCode;
            }
            set
            {
                m_vendorCode = value;
            }
        }

        public decimal orderedAmount
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

        public decimal deliveredAmount
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

        public decimal unitPrice
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

        public decimal lineSum
        {
            get
            {
                return m_rowSum;
            }
            set
            {
                m_rowSum = value;
            }
        }

        public decimal freightRate
        {
            get
            {
                return m_freightRate;
            }
            set
            {
                m_freightRate = value;
            }
        }

        public int accountingSuggestion
        {
            get
            {
                return m_accountingAccountSuggestion;
            }
            set
            {
                m_accountingAccountSuggestion = value;
            }
        }

        public decimal vatPercent
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

        public DateTime DeliveryDate
        {
            get
            {
                return m_deliveryDate;
            }
            set
            {
                m_deliveryDate = value;
            }
        }

        public string inventoryPlace
        {
            get
            {
                return m_inventoryPlace;
            }
            set
            {
                m_inventoryPlace = value;
            }
        }

        public string inventoryPlace_type
        {
            get
            {
                return m_inventoryPlace_type;
            }
            set
            {
                m_inventoryPlace_type = value;
            }
        }

        public ArrayList dimensions
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
    }
}

