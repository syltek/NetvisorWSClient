using Microsoft.VisualBasic;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorAccountingBudgetLockedDimension
    {




        private string m_dimensionName;
        private string m_dimensionItemName;

        public string DimensionName
        {
            get
            {
                return m_dimensionName;
            }
            set
            {
                m_dimensionName = value;
            }
        }

        public string DimensionItemName
        {
            get
            {
                return m_dimensionItemName;
            }
            set
            {
                m_dimensionItemName = value;
            }
        }

        public NetvisorAccountingBudgetLockedDimension()
        {
        }
    }
}
