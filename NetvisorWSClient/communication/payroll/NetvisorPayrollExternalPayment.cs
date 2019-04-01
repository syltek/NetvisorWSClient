using System;

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorPayrollExternalPayment
    {
        private string m_Description;
        private DateTime m_PaymentDate;
        private string m_ExternalPaymentSum;
        private string m_IBAN;
        private string m_BIC;
        private string m_HETU;
        private string m_Realname;


        public string IBAN
        {
            get
            {
                return m_IBAN;
            }
            set
            {
                m_IBAN = value;
            }
        }


        public string BIC
        {
            get
            {
                return m_BIC;
            }
            set
            {
                m_BIC = value;
            }
        }


        public string HETU
        {
            get
            {
                return m_HETU;
            }
            set
            {
                m_HETU = value;
            }
        }


        public string Realname
        {
            get
            {
                return m_Realname;
            }
            set
            {
                m_Realname = value;
            }
        }


        public string Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                m_Description = value;
            }
        }


        public DateTime PaymentDate
        {
            get
            {
                return m_PaymentDate;
            }
            set
            {
                m_PaymentDate = value;
            }
        }


        public string ExternalPaymentSum
        {
            get
            {
                return m_ExternalPaymentSum;
            }
            set
            {
                m_ExternalPaymentSum = value;
            }
        }
    }
}
