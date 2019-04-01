using System.Collections;
using System;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorPurchaseOrder
    {
        private int m_netvisorKey;
        private string m_orderNumber;
        private string m_orderStatus;
        private DateTime m_orderDate;
        private string m_vendoridentifier;
        private string m_vendoridentifier_type;
        private string m_vendorName;
        private string m_vendorAddress;
        private string m_vendorPostNumber;
        private string m_vendorPostOffice;
        private string m_vendorCountryCode;
        private decimal m_orderAmount;
        private string m_deliveryName;
        private string m_deliveryAddress;
        private string m_deliveryPostNumber;
        private string m_deliveryPostOffice;
        private string m_deliveryCountryCode;
        private string m_comment;
        private string m_deliveryMethod;
        private string m_deliveryTerm;
        private int m_paymentTermNetDays;
        private int m_paymentTermDiscountDays;
        private double m_paymentTermDiscountPercent;
        private string m_paymentTermDescription;
        private string m_ourReference;
        private string m_privateComment;
        private string m_currencyCode;
        private double m_currencyExchangeRate;

        private ArrayList m_purchaseOrderLines = new ArrayList();
        private ArrayList m_purchaseOrderCommentLines = new ArrayList();

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

        public string orderNumber
        {
            get
            {
                return m_orderNumber;
            }
            set
            {
                m_orderNumber = value;
            }
        }

        public string orderStatus
        {
            get
            {
                return m_orderStatus;
            }
            set
            {
                m_orderStatus = value;
            }
        }

        public DateTime orderDate
        {
            get
            {
                return m_orderDate;
            }
            set
            {
                m_orderDate = value;
            }
        }

        public string vendorIdentifier
        {
            get
            {
                return m_vendoridentifier;
            }
            set
            {
                m_vendoridentifier = value;
            }
        }

        public string vendorIdentifier_type
        {
            get
            {
                return m_vendoridentifier_type;
            }
            set
            {
                m_vendoridentifier_type = value;
            }
        }

        public string vendorName
        {
            get
            {
                return m_vendorName;
            }
            set
            {
                m_vendorName = value;
            }
        }

        public string vendorAddressline
        {
            get
            {
                return m_vendorAddress;
            }
            set
            {
                m_vendorAddress = value;
            }
        }

        public string vendorPostnumber
        {
            get
            {
                return m_vendorPostNumber;
            }
            set
            {
                m_vendorPostNumber = value;
            }
        }

        public string vendorCity
        {
            get
            {
                return m_vendorPostOffice;
            }
            set
            {
                m_vendorPostOffice = value;
            }
        }

        public string vendorCountry
        {
            get
            {
                return m_vendorCountryCode;
            }
            set
            {
                m_vendorCountryCode = value;
            }
        }

        public string deliveryName
        {
            get
            {
                return m_deliveryName;
            }
            set
            {
                m_deliveryName = value;
            }
        }

        public string deliveryAddressLine
        {
            get
            {
                return m_deliveryAddress;
            }
            set
            {
                m_deliveryAddress = value;
            }
        }

        public string deliveryPostNumber
        {
            get
            {
                return m_deliveryPostNumber;
            }
            set
            {
                m_deliveryPostNumber = value;
            }
        }

        public string deliveryCity
        {
            get
            {
                return m_deliveryPostOffice;
            }
            set
            {
                m_deliveryPostOffice = value;
            }
        }

        public string deliveryCountry
        {
            get
            {
                return m_deliveryCountryCode;
            }
            set
            {
                m_deliveryCountryCode = value;
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

        public string deliveryMethod
        {
            get
            {
                return m_deliveryMethod;
            }
            set
            {
                m_deliveryMethod = value;
            }
        }

        public string deliveryTerm
        {
            get
            {
                return m_deliveryTerm;
            }
            set
            {
                m_deliveryTerm = value;
            }
        }

        public int paymentTermNetDays
        {
            get
            {
                return m_paymentTermNetDays;
            }
            set
            {
                m_paymentTermNetDays = value;
            }
        }

        public int paymentTermCashDiscountDays
        {
            get
            {
                return m_paymentTermDiscountDays;
            }
            set
            {
                m_paymentTermDiscountDays = value;
            }
        }

        public double paymentTermDiscountPercent
        {
            get
            {
                return m_paymentTermDiscountPercent;
            }
            set
            {
                m_paymentTermDiscountPercent = value;
            }
        }

        public string paymentTermDescription
        {
            get
            {
                return m_paymentTermDescription;
            }
            set
            {
                m_paymentTermDescription = value;
            }
        }

        public string ourReference
        {
            get
            {
                return m_ourReference;
            }
            set
            {
                m_ourReference = value;
            }
        }

        public string privateComment
        {
            get
            {
                return m_privateComment;
            }
            set
            {
                m_privateComment = value;
            }
        }

        public decimal amount
        {
            get
            {
                return m_orderAmount;
            }
            set
            {
                m_orderAmount = value;
            }
        }

        public string currency
        {
            get
            {
                return m_currencyCode;
            }
            set
            {
                m_currencyCode = value;
            }
        }

        public double currency_ExchangeRate
        {
            get
            {
                return m_currencyExchangeRate;
            }
            set
            {
                m_currencyExchangeRate = value;
            }
        }

        public ArrayList ProductLines
        {
            get
            {
                return m_purchaseOrderLines;
            }
        }

        public void addProductline(NetvisorPurchaseOrderLine line)
        {
            m_purchaseOrderLines.Add(line);
        }

        public void clearProductLines()
        {
            m_purchaseOrderLines.Clear();
        }

        public ArrayList CommentLines
        {
            get
            {
                return m_purchaseOrderCommentLines;
            }
        }

        public void addCommentLine(NetvisorPurchaseOrderCommentLine line)
        {
            m_purchaseOrderCommentLines.Add(line);
        }

        public void clearCommentLines()
        {
            m_purchaseOrderCommentLines.Clear();
        }
    }
}

