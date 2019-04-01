using Microsoft.VisualBasic;
using System.Collections;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorAccountingBudget
    {




        public enum ratioTypes : int
        {
            accountNumber = 1
        }

        private int m_ratio;
        private ratioTypes m_ratioType;
        private decimal m_sum;
        private int m_year;
        private int m_month;
        private string m_budgetVersion;
        private decimal m_vatClass;
        private ArrayList m_combinations = new ArrayList();

        public int ratio
        {
            get
            {
                return m_ratio;
            }
            set
            {
                m_ratio = value;
            }
        }

        public ratioTypes ratioType
        {
            get
            {
                return m_ratioType;
            }
            set
            {
                m_ratioType = value;
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

        public int year
        {
            get
            {
                return m_year;
            }
            set
            {
                m_year = value;
            }
        }

        public int month
        {
            get
            {
                return m_month;
            }
            set
            {
                m_month = value;
            }
        }

        public string budgetVersion
        {
            get
            {
                return m_budgetVersion;
            }
            set
            {
                m_budgetVersion = value;
            }
        }

        public decimal vatClass
        {
            get
            {
                return m_vatClass;
            }
            set
            {
                m_vatClass = value;
            }
        }

        public ArrayList combinations
        {
            get
            {
                return m_combinations;
            }
        }

        public void addCombination(NetvisorAccountingBudgetCombination combination)
        {
            m_combinations.Add(combination);
        }

        public void clearCombinations()
        {
            m_combinations.Clear();
        }
    }
}
