using System.Collections.Generic;
using System;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorAccountingPeriodList
    {
        private DateTime m_AccountingPeriodLockDate;
        private DateTime m_VatPeriodLockDate;
        private DateTime m_PurchaseLockDate;

        private List<NetvisorPeriod> m_periods = new List<NetvisorPeriod>();

        public DateTime AccountingPeriodLockDate
        {
            get
            {
                return m_AccountingPeriodLockDate;
            }
            set
            {
                m_AccountingPeriodLockDate = value;
            }
        }

        public DateTime VatPeriodLockDate
        {
            get
            {
                return m_VatPeriodLockDate;
            }
            set
            {
                m_VatPeriodLockDate = value;
            }
        }

        public DateTime PurchaseLockDate
        {
            get
            {
                return m_PurchaseLockDate;
            }
            set
            {
                m_PurchaseLockDate = value;
            }
        }

        public List<NetvisorPeriod> periods
        {
            get
            {
                return m_periods;
            }
            set
            {
                m_periods = value;
            }
        }
    }
}
