using Microsoft.VisualBasic;
using System.Collections;
using System;
using NetvisorWSClient.util;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorInvoiceProductLine : INetvisorInvoiceLine
    {
        public enum productIdentifierTypes : int
        {
            EXTERNAL_IDENTIFIER = 1,
            NETVISOR_IDENTIFIER = 2
        }

        private string m_ProductIdentifier;
        private productIdentifierTypes m_ProductIdentifierType;
        private string m_ProductName;
        private decimal m_ProductUnitPrice;
        private decimal m_ProductVatPercentage;
        private VatCode.vatCodes m_productVatCode;
        private decimal m_DeliveredQuantity;
        private bool m_productUnitPriceIsGross;
        private int m_AccountingSuggestionAccountNumber;
        private decimal m_LineDiscountPercentage;
        private decimal? m_LineSum;
        private decimal? m_LineVatSum;
        private string m_lineText;
        private bool m_skipAccrual;

        private ArrayList m_dimensions = new ArrayList();

        public string ProductIdentifier
        {
            get
            {
                return m_ProductIdentifier;
            }
            set
            {
                m_ProductIdentifier = value;
            }
        }

        public productIdentifierTypes ProductIdentifierType
        {
            get
            {
                return m_ProductIdentifierType;
            }
            set
            {
                m_ProductIdentifierType = value;
            }
        }

        public string ProductName
        {
            get
            {
                return m_ProductName;
            }
            set
            {
                if (Strings.Len(value) > 200)
                    throw new ApplicationException("Invoiceline productname too long");
                else
                    m_ProductName = value;
            }
        }

        public decimal ProductUnitPrice
        {
            get
            {
                return m_ProductUnitPrice;
            }
            set
            {
                m_ProductUnitPrice = value;
            }
        }

        public decimal ProductVatPercentage
        {
            get
            {
                return m_ProductVatPercentage;
            }
            set
            {
                m_ProductVatPercentage = value;
            }
        }

        public VatCode.vatCodes productVatCode
        {
            get
            {
                return m_productVatCode;
            }
            set
            {
                m_productVatCode = value;
            }
        }

        public decimal DeliveredQuantity
        {
            get
            {
                return m_DeliveredQuantity;
            }
            set
            {
                m_DeliveredQuantity = value;
            }
        }

        public int AccountingSuggestionAccountNumber
        {
            get
            {
                return m_AccountingSuggestionAccountNumber;
            }
            set
            {
                m_AccountingSuggestionAccountNumber = value;
            }
        }

        public bool productUnitPriceIsGross
        {
            get
            {
                return m_productUnitPriceIsGross;
            }
            set
            {
                m_productUnitPriceIsGross = value;
            }
        }

        public decimal LineDiscountPercentage
        {
            get
            {
                return m_LineDiscountPercentage;
            }
            set
            {
                m_LineDiscountPercentage = value;
            }
        }

        public decimal? LineSum
        {
            get
            {
                return m_LineSum;
            }
            set
            {
                m_LineSum = value;
            }
        }

        public decimal? LineVatSum
        {
            get
            {
                return m_LineVatSum;
            }
            set
            {
                m_LineVatSum = value;
            }
        }

        public ArrayList dimensions
        {
            get
            {
                return m_dimensions;
            }
        }

        public string LineText
        {
            get
            {
                return m_lineText;
            }
            set
            {
                m_lineText = value;
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

        public void addDimension(NetvisorDimension dimension)
        {
            m_dimensions.Add(dimension);
        }
    }
}
