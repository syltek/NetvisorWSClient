using Microsoft.VisualBasic;

namespace NetvisorWSClient.communication.sales
{

    public class NetvisorProduct
    {




        public enum unitPriceTypes : int
        {
            net = 1,
            gross = 2
        }

        private int m_netvisorKey;
        private string m_productCode;
        private string m_productGroup;
        private string m_name;
        private string m_description;
        private decimal m_unitPrice;
        private unitPriceTypes m_unitPriceType;
        private string m_unit;
        private double m_unitWeight;
        private decimal m_purchaseprice;
        private string m_tariffHeading;
        private double m_comissionPercentage;
        private bool m_isActive;
        private bool m_isSalesproduct;
        private string m_defaultVatPercentage;
        private int m_DefaultDomesticAccountNumber;
        private int m_DefaultEuAccountNumber;
        private int m_DefaultOutsideEUAccountNumber;
        private decimal m_InventoryAmount;
        private decimal m_InventoryMidPrice;
        private decimal m_InventoryValue;
        private decimal m_InventoryReservedAmount;
        private decimal m_InventoryOrderedAmount;

        public NetvisorProduct()
        {
        }

        public void setUnitPrice(string price)
        {
            m_unitPrice = new decimal(double.Parse(price));
        }

        public void setPurchasePrice(string price)
        {
            m_purchaseprice = new decimal(double.Parse(price));
        }

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

        public string productGroup
        {
            get
            {
                return m_productGroup;
            }
            set
            {
                m_productGroup = value;
            }
        }

        public string name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
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

        public unitPriceTypes unitPriceType
        {
            get
            {
                return m_unitPriceType;
            }
            set
            {
                m_unitPriceType = value;
            }
        }

        public string unit
        {
            get
            {
                return m_unit;
            }
            set
            {
                m_unit = value;
            }
        }

        public double unitWeight
        {
            get
            {
                return m_unitWeight;
            }
            set
            {
                m_unitWeight = value;
            }
        }

        public decimal purchaseprice
        {
            get
            {
                return m_purchaseprice;
            }
            set
            {
                m_purchaseprice = value;
            }
        }

        public string tariffHeading
        {
            get
            {
                return m_tariffHeading;
            }
            set
            {
                m_tariffHeading = value;
            }
        }

        public double comissionPercentage
        {
            get
            {
                return m_comissionPercentage;
            }
            set
            {
                m_comissionPercentage = value;
            }
        }

        public bool isActive
        {
            get
            {
                return m_isActive;
            }
            set
            {
                m_isActive = value;
            }
        }

        public bool isSalesproduct
        {
            get
            {
                return m_isSalesproduct;
            }
            set
            {
                m_isSalesproduct = value;
            }
        }

        public string defaultVatPercentage
        {
            get
            {
                return m_defaultVatPercentage;
            }
            set
            {
                m_defaultVatPercentage = value;
            }
        }

        public decimal InventoryAmount
        {
            get
            {
                return m_InventoryAmount;
            }
            set
            {
                m_InventoryAmount = value;
            }
        }

        public decimal InventoryMidPrice
        {
            get
            {
                return m_InventoryMidPrice;
            }
            set
            {
                m_InventoryMidPrice = value;
            }
        }

        public decimal InventoryValue
        {
            get
            {
                return m_InventoryValue;
            }
            set
            {
                m_InventoryValue = value;
            }
        }

        public decimal InventoryReservedAmount
        {
            get
            {
                return m_InventoryReservedAmount;
            }
            set
            {
                m_InventoryReservedAmount = value;
            }
        }

        public decimal InventoryOrderedAmount
        {
            get
            {
                return m_InventoryOrderedAmount;
            }
            set
            {
                m_InventoryOrderedAmount = value;
            }
        }

        public int DefaultDomesticAccountNumber
        {
            get
            {
                return m_DefaultDomesticAccountNumber;
            }
            set
            {
                m_DefaultDomesticAccountNumber = value;
            }
        }

        public int DefaultEuAccountNumber
        {
            get
            {
                return m_DefaultEuAccountNumber;
            }
            set
            {
                m_DefaultEuAccountNumber = value;
            }
        }

        public int DefaultOutsideEUAccountNumber
        {
            get
            {
                return m_DefaultOutsideEUAccountNumber;
            }
            set
            {
                m_DefaultOutsideEUAccountNumber = value;
            }
        }
    }
}
