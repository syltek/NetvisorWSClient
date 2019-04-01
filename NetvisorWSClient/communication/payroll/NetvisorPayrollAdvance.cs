using System;

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorPayrollAdvance
    {
        public enum advancePaymentTypes : int
        {
            ispaid = 1,
            notpaid = 2
        }

        public enum advanceTypes : int
        {
            payroll = 1,
            tripExpence = 2
        }

        private string m_Description;
        private string m_EmployeeIdentifier;
        private DateTime m_PaymentDate;
        private double m_AdvanceSum;
        private advancePaymentTypes m_AdvancePaymentStatusType;
        private advanceTypes m_AdvanceType;


        public advanceTypes AdvanceType
        {
            get
            {
                return m_AdvanceType;
            }
            set
            {
                m_AdvanceType = value;
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


        public string EmployeeIdentifier
        {
            get
            {
                return m_EmployeeIdentifier;
            }
            set
            {
                m_EmployeeIdentifier = value;
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


        public double AdvanceSum
        {
            get
            {
                return m_AdvanceSum;
            }
            set
            {
                m_AdvanceSum = value;
            }
        }

        public advancePaymentTypes AdvancePaymentStatusType
        {
            get
            {
                return m_AdvancePaymentStatusType;
            }
            set
            {
                m_AdvancePaymentStatusType = value;
            }
        }
    }
}
