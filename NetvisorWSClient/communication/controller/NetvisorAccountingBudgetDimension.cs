using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorAccountingBudgetDimension
    {




        private readonly List<NetvisorAccountingBudgetMonth> m_monthList = new List<NetvisorAccountingBudgetMonth>();

        private string m_DimensionName;
        private string m_DimensionItemName;

        public string DimensionName
        {
            get
            {
                return m_DimensionName;
            }
            set
            {
                m_DimensionName = value;
            }
        }

        public string DimensionItemName
        {
            get
            {
                return m_DimensionItemName;
            }
            set
            {
                m_DimensionItemName = value;
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

        public NetvisorAccountingBudgetDimension()
        {
        }
    }
}
