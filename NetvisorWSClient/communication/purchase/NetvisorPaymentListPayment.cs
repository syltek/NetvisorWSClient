using System;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorPaymentListPayment
    {
        private int m_NetvisorKey;
        private string m_PayerName;
        private DateTime m_Date;
        private decimal m_HomeCurrencySum;
        private decimal m_ForeignCurrencySum;
        private string m_Reference;
        private int m_InvoiceKey;
        private string m_InvoiceNumber;
        private string m_invoiceURI;
        private int m_VoucherKey;
        private int m_VoucherNumber;
        private string m_voucherURI;

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

        public string PayerName
        {
            get
            {
                return m_PayerName;
            }
            set
            {
                m_PayerName = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return m_Date;
            }
            set
            {
                m_Date = value;
            }
        }

        public decimal HomeCurrencySum
        {
            get
            {
                return m_HomeCurrencySum;
            }
            set
            {
                m_HomeCurrencySum = value;
            }
        }

        public decimal ForeignCurrencySum
        {
            get
            {
                return m_ForeignCurrencySum;
            }
            set
            {
                m_ForeignCurrencySum = value;
            }
        }

        public string Reference
        {
            get
            {
                return m_Reference;
            }
            set
            {
                m_Reference = value;
            }
        }

        public int InvoiceKey
        {
            get
            {
                return m_InvoiceKey;
            }
            set
            {
                m_InvoiceKey = value;
            }
        }

        public string InvoiceNumber
        {
            get
            {
                return m_InvoiceNumber;
            }
            set
            {
                m_InvoiceNumber = value;
            }
        }

        public string invoiceURI
        {
            get
            {
                return m_invoiceURI;
            }
            set
            {
                m_invoiceURI = value;
            }
        }

        public int VoucherKey
        {
            get
            {
                return m_VoucherKey;
            }
            set
            {
                m_VoucherKey = value;
            }
        }

        public int VoucherNumber
        {
            get
            {
                return m_VoucherNumber;
            }
            set
            {
                m_VoucherNumber = value;
            }
        }

        public string voucherURI
        {
            get
            {
                return m_voucherURI;
            }
            set
            {
                m_voucherURI = value;
            }
        }
    }
}
