using System;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorSalesInvoice
    {
        private string m_InvoiceNumber;
        private DateTime m_InvoiceDate;
        private double m_TotalSumWithTax;
        private double m_PaymentSum;

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

        public DateTime InvoiceDate
        {
            get
            {
                return m_InvoiceDate;
            }
            set
            {
                m_InvoiceDate = value;
            }
        }

        public double TotalSumWithTax
        {
            get
            {
                return m_TotalSumWithTax;
            }
            set
            {
                m_TotalSumWithTax = value;
            }
        }

        public double PaymentSum
        {
            get
            {
                return m_PaymentSum;
            }
            set
            {
                m_PaymentSum = value;
            }
        }
    }
}

