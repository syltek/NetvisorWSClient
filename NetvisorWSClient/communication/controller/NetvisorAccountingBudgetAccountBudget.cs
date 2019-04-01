using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorAccountingBudgetAccountBudget
    {




        private readonly List<NetvisorAccountingBudgetAccount> m_budgetAccountList = new List<NetvisorAccountingBudgetAccount>();
        private readonly List<NetvisorAccountingBudgetLockedDimension> m_lockedDimensionList = new List<NetvisorAccountingBudgetLockedDimension>();
        private string m_Method;

        public string Method
        {
            get
            {
                return m_Method;
            }
            set
            {
                m_Method = value;
            }
        }

        public ArrayList BudgetAccountList
        {
            get
            {
                return ArrayList.Adapter(m_budgetAccountList);
            }
        }

        public ArrayList LockedDimensionList
        {
            get
            {
                return ArrayList.Adapter(m_lockedDimensionList);
            }
        }

        public void addBudgetAccount(NetvisorAccountingBudgetAccount budgetAccount)
        {
            m_budgetAccountList.Add(budgetAccount);
        }

        public void clearBudgetAccountList()
        {
            m_budgetAccountList.Clear();
        }

        public void addLockedDimension(NetvisorAccountingBudgetLockedDimension lockedDimension)
        {
            m_lockedDimensionList.Add(lockedDimension);
        }

        public void clearLockedDimensionList()
        {
            m_lockedDimensionList.Clear();
        }

        public NetvisorAccountingBudgetAccountBudget()
        {
        }
    }
}
