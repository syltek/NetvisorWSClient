using System;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorPurchaseInvoiceListInvoice
    {
        private int m_NetvisorKey;
        private string m_invoiceNumber;
        private DateTime m_invoiceDate;
        private string m_vendor;
        private decimal m_sum;
        private decimal m_payments;
        private decimal m_openSum;
        private string m_Uri;


        public string Uri
        {
            get
            {
                return m_Uri;
            }
            set
            {
                m_Uri = value;
            }
        }


        public int NetvisorKey
        {
            get
            {
                return m_NetvisorKey;
            }
            set
            {
                m_NetvisorKey = value;
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

        public string vendor
        {
            get
            {
                return m_vendor;
            }
            set
            {
                m_vendor = value;
            }
        }

        public decimal sum
        {
            get
            {
                return m_sum;
            }
            set
            {
                m_sum = value;
            }
        }

        public decimal payments
        {
            get
            {
                return m_payments;
            }
            set
            {
                m_payments = value;
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
    }
}
