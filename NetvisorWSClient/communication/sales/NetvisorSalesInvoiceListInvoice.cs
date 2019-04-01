using System;

namespace NetvisorWSClient.communication
{
    public class NetvisorSalesInvoiceListInvoice
    {
        private int m_netvisorKey;
        private string m_invoiceNumber;
        private DateTime m_invoiceDate;
        private string m_invoiceStatus;
        private string m_invoiceSubStatus;
        private string m_CustomerCode;
        private string m_customerName;
        private string m_referenceNumber;
        private decimal m_invoiceSum;
        private decimal m_openSum;
        private bool m_isInCollection;
        private string m_uri;

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

        public string invoiceNumber
        {
            get
            {
                return m_invoiceNumber;
            }
            set
            {
                m_invoiceNumber = value;
            }
        }

        public DateTime invoiceDate
        {
            get
            {
                return m_invoiceDate;
            }
            set
            {
                m_invoiceDate = value;
            }
        }

        public string invoiceStatus
        {
            get
            {
                return m_invoiceStatus;
            }
            set
            {
                m_invoiceStatus = value;
            }
        }

        public string invoiceSubStatus
        {
            get
            {
                return m_invoiceSubStatus;
            }
            set
            {
                m_invoiceSubStatus = value;
            }
        }

        public string CustomerCode
        {
            get
            {
                return m_CustomerCode;
            }
            set
            {
                m_CustomerCode = value;
            }
        }

        public string customerName
        {
            get
            {
                return m_customerName;
            }
            set
            {
                m_customerName = value;
            }
        }

        public string referenceNumber
        {
            get
            {
                return m_referenceNumber;
            }
            set
            {
                m_referenceNumber = value;
            }
        }

        public decimal invoiceSum
        {
            get
            {
                return m_invoiceSum;
            }
            set
            {
                m_invoiceSum = value;
            }
        }

        public decimal openSum
        {
            get
            {
                return m_openSum;
            }
            set
            {
                m_openSum = value;
            }
        }

        public bool isInCollection
        {
            get
            {
                return m_isInCollection;
            }
            set
            {
                m_isInCollection = value;
            }
        }

        public string uri
        {
            get
            {
                return m_uri;
            }
            set
            {
                m_uri = value;
            }
        }
    }
}

