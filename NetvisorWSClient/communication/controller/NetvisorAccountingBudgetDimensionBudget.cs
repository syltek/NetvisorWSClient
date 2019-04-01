using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorAccountingBudgetDimensionBudget
    {




        private readonly List<NetvisorAccountingBudgetLockedDimension> m_lockedDimensionList = new List<NetvisorAccountingBudgetLockedDimension>();
        private readonly List<NetvisorAccountingBudgetDimension> m_budgetDimensionList = new List<NetvisorAccountingBudgetDimension>();

        private int m_AccountNumber;
        private int m_AccountGroup;
        private string m_AccountName;

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

        public ArrayList BudgetDimensionList
        {
            get
            {
                return ArrayList.Adapter(m_budgetDimensionList);
            }
        }

        public ArrayList LockedDimensionList
        {
            get
            {
                return ArrayList.Adapter(m_lockedDimensionList);
            }
        }

        public void addBudgetDimension(NetvisorAccountingBudgetDimension budgetDimension)
        {
            m_budgetDimensionList.Add(budgetDimension);
        }

        public void clearBudgetDimensionList()
        {
            m_budgetDimensionList.Clear();
        }

        public void addLockedDimension(NetvisorAccountingBudgetLockedDimension lockedDimension)
        {
            m_lockedDimensionList.Add(lockedDimension);
        }

        public void clearLockedDimensionList()
        {
            m_lockedDimensionList.Clear();
        }

        public NetvisorAccountingBudgetDimensionBudget()
        {
        }
    }
}
