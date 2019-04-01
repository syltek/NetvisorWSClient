using System;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorSalesPaymentListPayment
    {
        public struct OptionalLimitSalesPayments
        {
            public const string ParameterName = "limitbytype";
            public const string ExcludeCreditLoss = "excludecreditloss";
            public const string OnlyCreditLoss = "onlycreditloss";
        }

        public enum bankStatuses : int
        {
            ok = 1,
            failed = 2
        }

        public enum returnCodes : int
        {
            noAccountFound = 1,
            balanceIsExceeded = 2,
            noPaymentServiceAccount = 3,
            payerHasCancelled = 4,
            bankHasCancelled = 5,
            cancellationNotClearing = 6,
            authorizationIsMissing = 7,
            errorInDueDate = 8,
            formNotCorrect = 9
        }

        private int m_netvisorKey;
        private string m_name;
        private DateTime m_paymentDate;
        private decimal m_sum;
        private string m_referenceNumber;
        private decimal m_foreignCurrencyAmount;
        private string m_invoiceNumber;
        private bankStatuses m_bankStatus;
        private returnCodes m_returnCode;
        private string m_returnCodeDescription;

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

        public decimal foreignCurrencyAmount
        {
            get
            {
                return m_foreignCurrencyAmount;
            }
            set
            {
                m_foreignCurrencyAmount = value;
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

        public bankStatuses bankStatus
        {
            get
            {
                return m_bankStatus;
            }
            set
            {
                m_bankStatus = value;
            }
        }

        public returnCodes returnCode
        {
            get
            {
                return m_returnCode;
            }
            set
            {
                m_returnCode = value;
            }
        }

        public string returnCodeDescription
        {
            get
            {
                return m_returnCodeDescription;
            }
            set
            {
                m_returnCodeDescription = value;
            }
        }
    }
}
