using System;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorSalesPayment
    {
        public const string CURRENCY_EURO = "EUR";

        public enum targetTypes : int
        {
            invoice = 1,
            order = 2
        }

        public enum targetIdentifierTypes : int
        {
            invoiceId = 1,
            invoiceNumber = 2,
            invoiceReferenceNumber = 3
        }

        public enum paymentMethodTypes : int
        {
            bankaccount = 1,
            alternative = 2
        }

        private decimal m_sum;
        private string m_currency;
        private DateTime m_paymentDate;
        private targetTypes m_targetType;
        private targetIdentifierTypes m_targetIdentifierType;
        private string m_targetIdentifier;
        private string m_sourceName;
        private int m_overrideAccountingAccountNumber;
        private int m_overrideSalesReceivablesAccountNumber;
        private paymentMethodTypes m_paymentMethodType;
        private string m_paymentMethod;

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

        public string currency
        {
            get
            {
                return m_currency;
            }
            set
            {
                m_currency = value;
            }
        }

        public DateTime paymentDate
        {
            get
            {
                return m_paymentDate;
            }
            set
            {
                m_paymentDate = value;
            }
        }

        public targetTypes targetType
        {
            get
            {
                return m_targetType;
            }
            set
            {
                m_targetType = value;
            }
        }

        public targetIdentifierTypes targetIdentifierType
        {
            get
            {
                return m_targetIdentifierType;
            }
            set
            {
                m_targetIdentifierType = value;
            }
        }

        public string targetIdentifier
        {
            get
            {
                return m_targetIdentifier;
            }
            set
            {
                m_targetIdentifier = value;
            }
        }

        public string sourceName
        {
            get
            {
                return m_sourceName;
            }
            set
            {
                m_sourceName = value;
            }
        }

        public int overrideAccountingAccountNumber
        {
            get
            {
                return m_overrideAccountingAccountNumber;
            }
            set
            {
                m_overrideAccountingAccountNumber = value;
            }
        }

        public int overrideSalesReceivablesAccountNumber
        {
            get
            {
                return m_overrideSalesReceivablesAccountNumber;
            }
            set
            {
                m_overrideSalesReceivablesAccountNumber = value;
            }
        }

        public bool doOverrideSalesRecivablesAccountNumber
        {
            get
            {
                return m_overrideSalesReceivablesAccountNumber > 0;
            }
        }

        public bool doOverrideAccountingAccountNumber
        {
            get
            {
                return m_overrideAccountingAccountNumber > 0;
            }
        }

        public paymentMethodTypes paymentMethodType
        {
            get
            {
                return m_paymentMethodType;
            }
            set
            {
                m_paymentMethodType = value;
            }
        }

        public string paymentMethod
        {
            get
            {
                return m_paymentMethod;
            }
            set
            {
                m_paymentMethod = value;
            }
        }
    }
}
