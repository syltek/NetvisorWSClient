using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorAccountingBudgetAccount
    {




        private readonly List<NetvisorAccountingBudgetMonth> m_monthList = new List<NetvisorAccountingBudgetMonth>();

        private int m_AccountNumber;
        private int m_AccountGroup;
        private string m_AccountName;

        public int AccountNumber
        {
            get
            {
                return m_AccountNumber;
            }
            set
            {
                m_AccountNumber = value;
            }
        }

        public int AccountGroup
        {
            get
            {
                return m_AccountGroup;
            }
            set
            {
                m_AccountGroup = value;
            }
        }

        public string AccountName
        {
            get
            {
                return m_AccountName;
            }
            set
            {
                m_AccountName = value;
            }
        }

        public ArrayList MonthList
        {
            get
            {
                return ArrayList.Adapter(m_monthList);
            }
        }

        public void addMonth(NetvisorAccountingBudgetMonth month)
        {
            m_monthList.Add(month);
        }

        public void clearMonthList()
        {
            m_monthList.Clear();
        }

        public NetvisorAccountingBudgetAccount()
        {
        }
    }
}
