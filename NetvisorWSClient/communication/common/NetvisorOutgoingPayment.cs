using System;
using NetvisorWSClient.util;

namespace NetvisorWSClient.communication.common
{
    public class NetvisorOutgoingPayment
    {
        public enum BankPaymentMessageTypes
        {
            FINNISH_REFERENCE = 1,
            FREETEXT = 2
        }

        private FinnishOrganisationIdentifier m_RecipientOrganizationCode;
        private string m_RecipientName;
        private FinnishBankAccountNumber m_SourceBankAccountNumber;
        private string m_DestinationBankName;
        private string m_DestinationBankBranch;
        private FinnishBankAccountNumber m_DestinationBankAccountNumber;
        private DateTime m_DueDate;
        private decimal m_Amount;
        private BankPaymentMessageTypes m_BankPaymentMessageType;
        private string m_BankPaymentMessage;

        public FinnishOrganisationIdentifier RecipientOrganizationCode
        {
            get
            {
                return m_RecipientOrganizationCode;
            }
            set
            {
                m_RecipientOrganizationCode = value;
            }
        }

        public string RecipientName
        {
            get
            {
                return m_RecipientName;
            }
            set
            {
                m_RecipientName = value;
            }
        }

        public FinnishBankAccountNumber SourceBankAccountNumber
        {
            get
            {
                return m_SourceBankAccountNumber;
            }
            set
            {
                m_SourceBankAccountNumber = value;
            }
        }

        public string DestinationBankName
        {
            get
            {
                return m_DestinationBankName;
            }
            set
            {
                m_DestinationBankName = value;
            }
        }

        public string DestinationBankBranch
        {
            get
            {
                return m_DestinationBankBranch;
            }
            set
            {
                m_DestinationBankBranch = value;
            }
        }

        public FinnishBankAccountNumber DestinationBankAccountNumber
        {
            get
            {
                return m_DestinationBankAccountNumber;
            }
            set
            {
                m_DestinationBankAccountNumber = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return m_DueDate;
            }
            set
            {
                m_DueDate = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return m_Amount;
            }
            set
            {
                m_Amount = value;
            }
        }


        public BankPaymentMessageTypes BankPaymentMessageType
        {
            get
            {
                return m_BankPaymentMessageType;
            }
            set
            {
                m_BankPaymentMessageType = value;
            }
        }

        public string BankPaymentMessage
        {
            get
            {
                return m_BankPaymentMessage;
            }
            set
            {
                m_BankPaymentMessage = value;
            }
        }
    }
}

