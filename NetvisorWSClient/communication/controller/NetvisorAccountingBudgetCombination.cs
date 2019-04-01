using Microsoft.VisualBasic;
using System.Collections;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorAccountingBudgetCombination
    {




        private decimal m_combinationSum;
        private ArrayList m_dimensions = new ArrayList();

        public decimal combinationSum
        {
            get
            {
                return m_combinationSum;
            }
            set
            {
                m_combinationSum = value;
            }
        }

        public ArrayList dimensions
        {
            get
            {
                return m_dimensions;
            }
        }

        public void addDimension(NetvisorDimension dimension)
        {
            m_dimensions.Add(dimension);
        }

        public void clearDimensions()
        {
            m_dimensions.Clear();
        }
    }
}
